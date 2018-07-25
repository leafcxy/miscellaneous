/// <reference path="../../shipxyAPI.js" />
/// <reference path="../../shipxyMap.js" />
/// <reference path="myApp.js" />
/// <reference path="view.js" />
(function () {
    var map = null, util = null, view = null, service = null,
    searchMaxCount = 100, //查询结果最大返回数
    searchOj = null, //API查询工具对象
    trackObj = null, //API轨迹工具对象512522
    trackObjs = [], //缓存轨迹列表
    regionObj = null, //API区域对象
    regionData = [], //区域内的船舶数据，源数据
    regionIdHash = {}, //区域内船舶数据的id索引，哈希表
    regionShipList = {}, //区域内船舶Ship对象列表
    filterData = null, //存储筛选出来的船舶
    initialized = false, //区域船舶数据是否初始化完毕
    controlShowType = 'current', //当前是否显示历史船舶ais数据
    refeshCount=0,//删除页面所有船舶的计数
    tracksColor = [0x0000ff, 0x6600FF, 0x3399CC, 0x660066, 0x663300, 0x009933, 0x339900, 0xFF9999, 0xFF99FF, 0x339999];
    //初始化区域
    var initShips = function () {
        //var region = new shipxyAPI.Region(); //区域范围
        ////区域范围数据
        //region.data = [{ lat: 20.33, lng: 110.17, lat: 20.33, lng: 110.33, lat: 20, lng: 110.33, lat: 20, lng: 110.17 }];
        //// 当前测试区域为 山东半岛附近   ，请根据业务需要修改您的需要监控的区域。
        //// 或者联系我们商务 帮您来划定区域。 
        //regionObj = new shipxyAPI.AutoShips(region, shipxyAPI.Ships.INIT_REGION); //API区域对象
        //regionObj.getShips(regionCallback); //调用API的请求批量船舶数据接口
        //regionObj.setAutoUpdateInterval(360); //调用API的设置自动更新间隔=30秒
        //regionObj.startAutoUpdate(regionCallback); //调用API的开启自动更新
        ///***画出多边形区域***/
        //var opts = new shipxyMap.PolygonOptions();
        //opts.zoomlevels = [1, 9];
        //opts.zIndex = shipxyMap.ZIndexConst.MAP_LAYER; //多边形区域绘制在Map层，船舶层之下，以防止船舶被遮盖
        //var polygon = new shipxyMap.Polygon('myRegion1', region.data, opts);
        //map.addOverlay(polygon);
        //map.locateOverlay(polygon, 10); //初始化定位到10级
        $.ajax({
            type: "POST",
            url: "/Common/MapOCX/GetAllShipAisInfo",
            data: { if_supervision: if_supervision },
            dataType: "json",
            beforeSend: function (data) {
            },
            success: function (data) {
                if (data != false) {
                    var newdata = service.convertToApiDate(data);
                    regionCallback(0, newdata);
                }
            },
            error: function (data) {
                alertBox("当前时间未接收到船舶Ais数据，如有疑问，请与管理员核实！");
            },
            complete: function (data) {
            }

        });
        var vInterval = setInterval(
            function ()
            {
                if (controlShowType != 'current' && controlShowType != 'currenting')
                {//如果开启了查询船舶历史实时位置的情况下，则暂时不显示实时监控
                    return;
                }
                $.ajax({
                    type: "POST",
                    url: "/Common/MapOCX/GetAllShipAisInfo",
                    data: { if_supervision: if_supervision },
                    dataType: "json",
                    beforeSend: function (data) {
                    },
                    success: function (data) {
                        if (data != false)
                        {
                            var newdata = service.convertToApiDate(data);
                            regionCallback(0, newdata);
                        }
                    },
                    error: function (data) {
                        alertBox("获取船舶Ais数据失败，请与管理员联系！");
                    },
                    complete: function (data) {
                    }

                });
            },10000);
    };
    
    //数据请求返回
    var regionCallback = function (status, data) {
        if (status == 0) {//成功
            if (controlShowType != 'currenting' && controlShowType != 'trackPlaying') {
                //如果是查询历史的情况下，则清空regionIdHash，重新装载
                regionIdHash = {};
                regionData = [];
                map.removeOverlayByType(shipxyMap.OverlayType.SHIP); //删除所有船舶
                map.removeOverlayByType(shipxyMap.OverlayType.TRACK); //删除所有轨迹  
                if (controlShowType == "current") {//航迹回放第二次之后不删除原来地图数据
                    controlShowType = "currenting";
                }
                if (controlShowType == "trackPlay") {//航迹回放第二次之后不删除原来地图数据
                    controlShowType = "trackPlaying";
                }
            }
            if (refeshCount == 60)
            {//每十分钟删除一次页面所有船舶，重新加载，确保超出监控范围或断开ais数据的船舶不会长久留在页面上
                map.removeOverlayByType(shipxyMap.OverlayType.SHIP);
                refeshCount = 0;
            }
            
            var datas = data;
            if (datas && datas.length > 0) {
                var i = 0, len = datas.length, d;
                for (; i < len; i++) {
                    d = datas[i];
                    if (regionIdHash[d.shipId]) {//更新的，通过Id哈希表映射判断
                        var sd = regionIdHash[d.shipId];
                        for (var k in d) {//更新该船的数据内容
                            sd[k] = d[k];
                        }
                    } else {//新增的
                        regionIdHash[d.shipId] = d;
                        regionData.push(d);
                    }
                }
                //未初始化，区域列表显示全部船舶，一旦初始化完毕，不会自动刷新列表，只有当在点击刷新按钮和筛选的时候才会手动刷新列表
                //if (!initialized) {
                //    view.showList('regionlist', regionData, true);
                //    initialized = true;
                //}
                //当有筛选船舶数据，优先显示筛选的船舶
                showShips(filterData || regionData);
            }
        } else {//错误
            errorTip(status);
        }
    };

    

    /*转换时间，计算差值 返回相差秒数 */
    function comptime(beginTime, endTime) {
        var secondNum = parseInt((endTime - beginTime * 1000) / 1000);//计算时间戳差值
        return secondNum;
        //if (secondNum >= 0 && secondNum < 60) {
        //    return secondNum + '秒前';
        //}
        //else if (secondNum >= 60 && secondNum < 3600) {
        //    var nTime = parseInt(secondNum / 60);
        //    return nTime + '分钟前';
        //}
        //else if (secondNum >= 3600 && secondNum < 3600 * 24) {
        //    var nTime = parseInt(secondNum / 3600);
        //    return nTime + '小时前';
        //}
        //else {
        //    var nTime = parseInt(secondNum / 86400);
        //    return nTime + '天前';
        //}
    }

    //根据船舶数据数组显示船舶
    var showShips = function (shipDatas) {
        if (!shipDatas) return;
        var i = 0, len = shipDatas.length, d, opts, ship, hasSelected = false;
        for (; i < len; i++) {
            d = shipDatas[i];
            ship = regionShipList[d.shipId];
            opts = new shipxyMap.ShipOptions();
            opts.zoomlevels = service.showShipZooms;
            //不同港籍船舶的颜色，用边框区分
            if (d.left == "1")
            {//海安港
                opts.fillStyle.color = "0XFFFF00";
                //opts.strokeStyle.thickness = 0.5;
            }
            else if (d.left == "2") {//海安新港
                opts.fillStyle.color = "0X00FF33";
                //opts.strokeStyle.thickness = 0.5;
            }
            else if (d.left == "3") {//秀英港
                opts.fillStyle.color = "0XFF9900";
                //opts.strokeStyle.thickness = 0.5;
            }

            //Update By CJ 新增需求：超过10分钟时间没接收到输出的船舶，显示为黑色
            var nowtime = (new Date).getTime();/*当前时间戳*/
            var secondNum = comptime(d.lastTime, nowtime);//timestamp为PHP通过ajax回传的时间戳
            //超过两小时无数据的变灰色(只有实时监控才需要变色)
            if (secondNum > 7200 && controlShowType == 'current')
            {
                opts.fillStyle.color = "0X6C6C6C";
            }
            
            //如果名字为纯数字或者为空或者undefined就变白
            //if ((/^\d+$/.test(d.name)) || d.name == "" || d.name == undefined)
            //{
            //    opts.fillStyle.color = "0XFCFCFC";
            //}



            //不同船舶类型的颜色，用填充颜色区分
            //if (d.type == "客船") {
            //    opts.fillStyle.color = "0X00FF33";
            //}
            //else 
            //if (d.type == "危险品船") {
            //    opts.strokeStyle.color = "0XDC143C";
            //    opts.strokeStyle.thickness = 1;
            //}
            //else if (d.type == "客滚船") {
            //    opts.fillStyle.color = "0XFFFF00";
            //}
            
            opts.labelOptions.zoomlevels = service.showShipLabelZooms;
            opts.labelOptions.fontStyle.bold = true;  //粗体
            ship = new shipxyMap.Ship(d.shipId, d, opts);
            regionShipList[d.shipId] = d;
            map.addOverlay(ship);
            //有被选择的船，显示船舶信息框
            if (d.shipId == service.selectedShipId) {
                //view.showShipWin(d);
                hasSelected = true;
            }
        }
        //无被选择的船，关闭船舶信息框
        if (!hasSelected) {
            view.hideShipWin();
        }
    };

    

    //船舶点击事件处理函数
    var addShipClickEvent = function () {
        var EventObj = shipxyMap.Event;
        //调用API的注册船舶事件接口
        map.addShipEventListener(EventObj.CLICK, function (event) {
            //从缓存中来获取数据
            var shipId = event.overlayId;
            var ship = map.getOverlayById(shipId);
            if (ship) {
                service.selectShip(shipId); //框选
                view.showShipWin(ship.data); //显示船舶信息框
            }
            //请求最新数据来展示
            var that = this;
            var ships = new shipxyAPI.Ships(shipId, shipxyAPI.Ships.INIT_SHIPID);
            ships.getShips(function (status) {
                if (status == 0) {
                    var data = this.data[0];
                    if (data) {
                        if (ship) ship.data = data;
                        else ship = new shipxyMap.Ship(data.shipId, data);
                        service.selectShip(shipId); //框选
                        view.showShipWin(ship.data); //显示船舶信息框
                    }
                }
            });
        });
        map.addShipEventListener(EventObj.MOUSE_OVER, function (event) {
            var shipId = event.overlayId;
            var ship = map.getOverlayById(shipId);
            view.showShipTip(ship.data, event.latLng); //显示船舶简单信息提示
        });
        map.addShipEventListener(EventObj.MOUSE_OUT, function (event) {
            view.hideShipTip(); //隐藏船舶简单信息提示
        });
    };

    //轨迹点鼠标移上事件处理函数
    var trackover = function (event) {
        var track = map.getOverlayById(event.overlayId);
        var shipData = map.getOverlayById(track.data.shipId).data;
        view.showTrackTip({ name: shipData.name, callsign: shipData.callsign, MMSI: shipData.MMSI, IMO: shipData.IMO }, event.extendData); //显示轨迹点信息提示
    };
    //轨迹点鼠标移出事件处理函数
    var trackout = function (event) {
        view.hideTrackTip(); //隐藏轨迹点信息提示
    };

    //定位该船
    var locate = function (ship) {
        map.addOverlay(ship, true); //显示船
        service.selectShip(ship.data.shipId); //框选船
        map.locateOverlay(ship, service.locateShipZoom); //定位船舶
        view.showShipWin(ship.data); //显示船舶信息框
    };

    //错误提示
    var errorTip = function (errorCode) {
        switch (errorCode) {
            case 1:
                myApp.Message.error('网站服务出错！错误原因：服务过期。错误代码：1。');
                break;
            case 2:
                myApp.Message.error('网站服务出错！错误原因：服务无效或被锁定。错误代码：2。');
                break;
            case 3:
                myApp.Message.error('网站服务出错！错误原因：域名错误。错误代码：3。');
                break;
            case 4:
                myApp.Message.error('网站服务出错！错误原因：请求的数据量过大。错误代码：4。');
                break;
            case 100:
                myApp.Message.error('网站服务出错！错误原因：未知。错误代码：100。');
                break;
        }
    };

    myApp.service = {
        //初始化服务，包括注册事件、初始化请求等等
        init: function () {
            map = myApp.map;
            util = myApp.util;
            view = myApp.view;
            service = this;
            initShips();
            addShipClickEvent();

            /*****线显示样式*****/
            var optsBuoy = new shipxyMap.PolylineOptions()
            optsBuoy.zoomlevels = [5, 45]; //显示级别
            optsBuoy.zIndex = 4; //是否显示label
            optsBuoy.isShowLabel = true; //是否显示label
            optsBuoy.isEditable = false; //是否可编辑
            /*线样式*/
            optsBuoy.strokeStyle.color = 0xff3399;
            optsBuoy.strokeStyle.alpha = 0.8;
            optsBuoy.strokeStyle.thickness = 3;
            /*标签样式*/
            //标签线条
            optsBuoy.labelOptions.border = true; //有边框
            optsBuoy.labelOptions.borderStyle.color = 0xff0000;
            optsBuoy.labelOptions.borderStyle.alpha = 0.5;
            optsBuoy.labelOptions.borderStyle.thickness = 1;
            //标签文字
            optsBuoy.labelOptions.fontStyle.name = 'Verdana';
            optsBuoy.labelOptions.fontStyle.size = 14;
            optsBuoy.labelOptions.fontStyle.color = 0xff33cc;
            optsBuoy.labelOptions.fontStyle.bold = true;  //粗体
            optsBuoy.labelOptions.fontStyle.italic = false;  //斜体
            optsBuoy.labelOptions.fontStyle.underline = false;  //下划线
            //标签填充
            optsBuoy.labelOptions.background = true; //有背景
            optsBuoy.labelOptions.backgroundStyle.color = 0xfefefe;  //边框样式
            optsBuoy.labelOptions.backgroundStyle.alpha = 0.5;
            optsBuoy.labelOptions.zoomlevels = [5, 45]; //显示级别
            optsBuoy.labelOptions.text = "1号灯浮纬线";
            optsBuoy.labelOptions.labelPosition = new shipxyMap.Point(0, 0);
            //坐标数组，坐标X1,Y1,X2,Y2
            var coordsBuoy = "20.08125;110.30445;20.08125;110.20445";
            service.addPolyline(coordsBuoy, optsBuoy);
            optsBuoy.labelOptions.text = "中7灯浮纬线";
            coordsBuoy = "20.212716666666665;110.29491666666667;20.212716666666665;110.19491666666667";
            service.addPolyline(coordsBuoy, optsBuoy);

            optsBuoy.labelOptions.text = " ";
            optsBuoy.isShowLabel = false; //是否显示label
            var coordsHaQuay = "20.271267;110.229733;20.270833;110.22915";
            service.addPolyline(coordsHaQuay, optsBuoy);
            optsBuoy.labelOptions.text = "";
            coordsHaQuay = "20.269;110.231833;20.268433;110.231433";
            service.addPolyline(coordsHaQuay, optsBuoy);
            optsBuoy.labelOptions.text = "";
            coordsHaQuay = "23.16431;112.4467;22.991216;112.4464";
            service.addPolyline(coordsHaQuay, optsBuoy);
        },
        selectedShipId: '-1', //被选择的船舶shipId
        locateShipZoom: 15, //船舶定位级别
        showShipZooms: [10, 18], //显示船舶的级别序列：10到18级
        showShipLabelZooms: [15, 18], //显示船舶标签的级别序列：15到18级  


        //选择一艘船舶
        selectShip: function (shipId) {
            if (shipId == this.selectedShipId) return;
            //先清除原先被选择船舶的选择框
            this.unselectShip(this.selectedShipId);
            var ship = map.getOverlayById(shipId);
            if (ship) {
                ship.options.isSelected = true;
                ship.options.zoomlevels = [1, 18]; //选择的船，所有级别都显示
                map.addOverlay(ship, true);
                this.selectedShipId = shipId;
            }
        },
        //选择多艘船舶
        superviseShip: function (SuperviseShipIds) {

            var shipIdList = SuperviseShipIds.split(',');
            for (var i = 0; i < shipIdList.length; i++) {
                var ship = map.getOverlayById(shipIdList[i]);
                if (ship&&ship.options.isSelected!=true) {
                    ship.options.isSelected = true;
                    ship.options.zoomlevels = [1, 18]; //选择的船，所有级别都显示
                    map.addOverlay(ship, true);
                    this.selectedShipId = shipIdList[i];
                }
            }            
        },
        //显示船舶实时ais位置
        stopShipsHistory: function () {
            controlShowType = 'current';
        },
        //显示船舶历史ais位置
        startShipsHistory: function () {
            controlShowType = 'shipHistory';
        },
        //显示船舶历史ais位置
        showShipsHistory: function (historyTimeShipIds, historyTime, ShowType,SuperviseShipId) {
            //轨迹回放标识trackPlay trackPlaying
            if (ShowType == null)
            {
                controlShowType = "shipHistory";
            }
            else
            {
                if (controlShowType != "trackPlaying")
                {
                    controlShowType = ShowType;
                }
            }
            
            //监控船舶第一次先查询所有船舶位置再执行参数回放轨迹 2015-04-07 by ysh
            if ($("#movieInfo").contents().find("#selectAll").attr("checked") == "checked")
            {
                $.ajax({
                    type: "POST",
                    url: "/Common/MapOCX/GetHistoryPosition",
                    data: { shipIds: "all", historyTime: historyTime },
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.length != 0) {
                            var newdata = service.convertToApiDate(data);
                            regionCallback(0, newdata);
                        }
                        else {
                            if (controlShowType != "trackPlaying" && controlShowType != "trackPlay") {
                                myApp.Message.alert("未查询到相关历史数据！");
                            }
                        }
                    },
                    error: function (data) {
                        myApp.Message.alert("指定时间内并无接收到Ais船舶数据，如有疑问请咨询管理员！");
                    }

                });
            }
            
            var url = controlShowType == "shipHistory" ? "/Common/MapOCX/GetHistoryPositionNoReplay":"/Common/MapOCX/GetHistoryPosition";

            $.ajax({
                type: "POST",
                url: url,
                data: { shipIds: historyTimeShipIds, historyTime: historyTime },
                dataType: "json",
                async:false,
                beforeSend: function (data) {
                },
                success: function (data) {

                    if (data.length != 0) {
                        var newdata = service.convertToApiDate(data);
                        regionCallback(0, newdata);
                        if (newdata.length == 1 && controlShowType != "trackPlaying" && controlShowType != "trackPlay") {
                            service.locateShip(newdata[0].shipId);
                        }
                        //框定需监控的一艘或多船舶
                        if (SuperviseShipId != null && SuperviseShipId != "")
                        {
                            service.superviseShip(SuperviseShipId);
                        }
                    }
                    else
                    {
                        if (controlShowType != "trackPlaying" && controlShowType != "trackPlay") {
                            myApp.Message.alert("未查询到相关历史数据！");
                        }
                    }
                },
                error: function (data) {
                    myApp.Message.alert("指定时间内并无接收到Ais船舶数据，如有疑问请咨询管理员！");
                },
                complete: function (data) {
                }

            });
            return controlShowType;
        },

        //反选船舶
        unselectShip: function (shipId) {
            if (shipId == '-1') return;
            var ship = map.getOverlayById(shipId);
            if (ship) {
                ship.options.isSelected = false;
                ship.options.zoomlevels = this.showShipZooms;
                map.addOverlay(ship);
                this.selectedShipId = -1; //清除被选船舶shipId缓存
            }
        },

        //定位一条船
        locateShip: function (shipId) {
            var ship = map.getOverlayById(shipId);
            if (ship) {//缓存里存在，定位
                locate(ship);
            }
            //请求最新数据来定位
            var that = this;
            var ships = new shipxyAPI.Ships(shipId, shipxyAPI.Ships.INIT_SHIPID);
            ships.getShips(function (status) {
                if (status == 0) {
                    var data = this.data[0];
                    if (data) {
                        if (ship) ship.data = data;
                        else ship = new shipxyMap.Ship(data.shipId, data);
                        locate(ship);
                    } else {
                        service.unselectShip(that.selectedShipId); //框选船舶
                        view.showShipWin(that.getEmptyShipInfo(shipId)); //显示船舶信息框
                    }
                }
            });
        },

        //根据关键字查询船舶
        searchShip: function (key) {
            if (!key || key == '请输入船名、呼号、MMSI或IMO') { return; }
            if (!searchOj) {
                searchOj = new shipxyAPI.Search(); //构建API查询工具对象
            }
            var that = this;
            //调用API查询船舶接口
            searchOj.searchShip({ keyword: key, max: searchMaxCount }, function (status) {
                var data = this.data;
                if (status == 0 && data && data.length > 0) {//当有结果，先定位第一条结果到醒目位置
                    that.locateShip(data[0].shipId);
                }
                view.showList('searchlist', data, true); //刷新搜索结果列表
            });
        },
        //查询轨迹
        searchTrack: function (shipIds, btime, etime) {
            myApp.map.removeOverlayByType(shipxyMap.OverlayType.TRACK); //删除所有轨迹  
            this.abortSearchTrack();
            var that = this, EventObj = shipxyMap.Event;
            $.ajax({
                type: "POST",
                url: "/Common/MapOCX/GetHistoryShipAisInfo",
                data: { shipIds: shipIds, beginTime: btime, endTime: etime },
                dataType: "json",
                async: false,
                beforeSend: function (data) {
                },
                success: function (data) {
                    //显示轨迹
                    var trackDataList=eval(data);
                    if (trackDataList.length > 0) {
                        var shipIdList = shipIds.split(',');
                        for (var i = 0; i < shipIdList.length; i++)
                        {
                            var trackData = new shipxyAPI.Track(shipIdList[i], myApp.util.getDateByString(btime).getTime(), myApp.util.getDateByString(etime).getTime());
                            if (trackDataList[0][shipIdList[i]] != null)
                            {
                                trackData.data = trackDataList[0][shipIdList[i]];
                                var trackId = trackData.trackId;
                                var opts = new shipxyMap.TrackOptions();
                                opts.strokeStyle.color = tracksColor[i];
                                opts.pointStyle.strokeStyle.color = tracksColor[i];
                                opts.labelOptions.borderStyle.color = tracksColor[i];
                                var track = new shipxyMap.Track(trackId, trackData, opts);
                                map.addOverlay(track);
                                //注册轨迹点事件
                                map.addEventListener(track, EventObj.TRACKPOINT_MOUSEOVER, trackover);
                                map.addEventListener(track, EventObj.TRACKPOINT_MOUSEOUT, trackout);
                            }
                        }
                        
                    } else {
                        view.setTrackMsg('暂无轨迹');
                    }
                },
                error: function (data) {
                    myApp.Message.alert("获取船舶Ais数据失败，请与管理员联系！");
                },
                complete: function (data) {
                }

            });
        },

        //销毁轨迹查询
        abortSearchTrack: function () {
            if (trackObj) {
                trackObj.abort(); //销毁当前轨迹的请求
                trackObj = null;
                view.setTrackMsg('');
            }
        },

        //删除轨迹
        delTrack: function (trackId) {
            var track = map.getOverlayById(trackId), EventObj = shipxyMap.Event;
            if (track) {
                //移除轨迹点事件
                map.removeEventListener(track, EventObj.MOUSE_OVER, trackover);
                map.removeEventListener(track, EventObj.MOUSE_OUT, trackout);
                map.removeOverlay(track); //删除轨迹显示
                var len = trackObjs.length, td;
                //删除轨迹数据缓存
                while (len--) {
                    td = trackObjs[len].data;
                    if (td && td.trackId == trackId) {
                        trackObjs.splice(len, 1);
                        break;
                    }
                }
                //刷新列表
                view.showList("tracklist", trackObjs, true);
            }
        },

        //定位轨迹
        locateTrack: function (trackId) {
            var track = map.getOverlayById(trackId);
            if (track) {
                map.locateOverlay(track); //定位
            }
        },

        //筛选船舶，options：筛选条件集合
        filter: function (options) {
            filterData = [];
            var country = options.country, type = options.type, status = options.status, cargoType = options.cargoType;
            var length = options.length, beam = options.beam, draught = options.draught;
            //当所有条件都为默认值（所有），为全部数据，不筛选
            if (country == '所有' && type == '所有' && status == '所有' && cargoType == '所有' && length[0] == 0 && length[1] == 0 && beam[0] == 0 && beam[1] == 0 && draught[0] == 0 && draught[1] == 0) {
                filterData = regionData;
            } else {//否则，按条件筛选
                if (length[0] > length[1] || beam[0] > beam[1] || draught[0] > draught[1]) {
                    myApp.Message.alert('船长、船宽或吃水的起始条件值不能大于结束条件值。');
                    return;
                }
                var i = 0, len = regionData.length, d;
                for (; i < len; i++) {
                    d = regionData[i];
                    if (country != '所有') {
                        if (d.country != country) continue;
                    }
                    if (type != '所有') {
                        if (d.type != type) continue;
                    }
                    if (status != '所有') {
                        if (d.status != status) continue;
                    }
                    if (cargoType != '所有') {
                        if (d.cargoType != cargoType) continue;
                    }
                    if (length[0] >= 0 && length[1] > 0) {
                        if (d.length < length[0] || d.length > length[1]) continue;
                    }
                    if (beam[0] >= 0 && beam[1] > 0) {
                        if (d.beam < beam[0] || d.beam > beam[1]) continue;
                    }
                    if (draught[0] >= 0 && draught[1] > 0) {
                        if (d.draught < draught[0] || d.draught > draught[1]) continue;
                    }
                    filterData.push(d); //执行到此处的，已经满足了所有条件，筛选出来
                }
            }
            view.showList('regionlist', filterData, true); //刷新列表：筛选数据
            this.unselectShip(this.selectedShipId); //清除选择船
            map.removeOverlayByType(shipxyMap.OverlayType.SHIP); //删除所有船舶
            showShips(filterData); //用筛选数据刷新
        },

        //取消筛选，恢复到全部船舶
        unfilter: function () {
            filterData = null;
            view.showList('regionlist', regionData, true); //刷新列表：全部数据
            showShips(regionData);
        },

        //区域列表刷新，手动点击刷新按钮，取出最新的船舶数据刷新区域列表
        refresh: function () {
            view.showList('regionlist', filterData || regionData, true); //当前数据：筛选或者全部
        },

        //生成吉船舶信息
        getEmptyShipInfo: function (shipId) {
            return { shipId: shipId, name: "", callsign: "", MMSI: "", IMO: "", type: "", status: "", length: NaN, beam: NaN, draught: NaN, lat: NaN, lng: NaN,
                heading: NaN, course: NaN, speed: NaN, rot: NaN, dest: "", eta: "", lastTime: NaN, country: "", cargoType: ""
            };
        },
        convertToApiDate : function (data)
        {
            var newHash = [];//区域内船舶数据的id索引，哈希表
            if (data && data.length > 0) {
                var i = 0, len = data.length, d;
                for (; i < len; i++) {
                    d = data[i];
                    //if (d["ShipId"] == "412464150" || d["ShipId"] == "412521350" || d["ShipId"] == "412522120" || d["ShipId"] == "412522280" || d["ShipId"] == "412522740" || d["ShipId"] == "412522750" || d["ShipId"] == "412522760" || d["ShipId"] == "412522810" || d["ShipId"] == "413460230") {
                    //    continue;
                    //}
                    var sd = new shipxyAPI.Ship();
                    sd.country = "cn";
                    //sd.eta = d["Month"] + "." + d["Day"] + " " + d["Hour"] + ":" + d["Minute"];
                    //sd.eta = "7.3 16:00";
                    for (var k in d) {//更新该船的数据内容
                        if (k == "ShipId") {
                            sd.shipId = d[k];
                            sd.name = d[k];
                        }
                        else if (k == "Width") {
                            sd.beam = d[k];
                        }
                        else if (k == "CargoType") {
                            sd.cargoType = d[k];
                        }
                        else if (k == "Imo") {
                            sd.IMO = d[k];
                        }
                        else if (k == "Rot") {
                            sd.rot = d[k];
                        }
                        else if (k == "CallSign") {
                            sd.callsign = d[k];
                        }
                        else if (k == "Cog") {
                            sd.course = d[k];
                        }
                        else if (k == "Dest") {
                            sd.dest = d[k];
                        }
                        else if (k == "Draught") {
                            if (d[k] <= 0) {
                                sd.draught = 0;
                            }
                            else {
                                sd.draught = d[k];
                            }
                        }
                        else if (k == "Hdg") {
                            sd.heading = d[k];
                        }
                        else if (k == "LastTime") {
                            sd.lastTime = parseFloat(d[k].replace("/Date(","").replace(")/","")).toString().substring(0,10);
                        }
                        else if (k == "Lat") {
                            sd.lat = d[k];
                        }
                        else if (k == "Length") {
                            sd.lenght = d[k];
                        }
                        else if (k == "Lng") {
                            sd.lng = d[k];
                        }
                        else if (k == "Mmsi") {
                            sd.MMSI = d[k].toString();
                        }
                        else if (k == "Sog") {
                            sd.speed = d[k];
                        }
                        else if (k == "NaviStatusCn") {
                            sd.status = d[k];
                        }
                        else if (k == "Trail") {
                            if (d[k] != "-2147483648.0000")
                            {
                                sd.trail =0;
                            }
                            else
                                sd.trail = d[k];
                        }
                        else if (k == "ShipType")
                        {
                            if (d[k] == "1") {
                                sd.type = "客船";
                            }
                            else if (d[k] == "2") {
                                sd.type = "危险品船";
                            }
                            else if (d[k] == "3") {
                                sd.type = "客滚船";
                            }
                            else {
                                sd.type = d[k];
                            }
                        }
                        else if (k == "CargoType") {
                            sd.cargoType = d[k];
                        }
                        else if (k == "ShipRegistry") {
                            sd.left = d[k];
                        }
                    }
                    newHash.push(sd);
                }

            }
            return newHash;
        },
        //添加浮标纬线
        addPolyline: function (coords, opts) {
        var coord = coords.split(';');
        /*****线*****/
        var data = [];
        data[0] = new shipxyMap.LatLng(parseFloat(coord[0]), parseFloat(coord[1]));
        data[1] = new shipxyMap.LatLng(parseFloat(coord[2]), parseFloat(coord[3]));
        polyline = new shipxyMap.Polyline('MyPolyline1' + opts.labelOptions.text, data, opts);
        //添加到地图上显示
        map.addOverlay(polyline);
        //map.locateOverlay(polyline, polyline.options.zoomlevels[0]);
    }
    };
})();