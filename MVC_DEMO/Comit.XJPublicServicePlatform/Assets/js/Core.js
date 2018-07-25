
function getCometServerPush(userId) {
    /// <summary>取得Comet长轮询服务器推送的数据</summary>
    $.ajax({
        cache: false,
        //data: { userId: userId },
        url: '/ShipMonitor/Comet/Index',
        success: function (data) {
            //若收到最近定位数据则更新页面
            if (data) {
                switch (data.DataType) {
                    case 1000: //监控信息通知
                        popupUnreadMessageNotify(data.DataObject);
                        break;
                    case 1010: //台风避风信息通知
                        showWindMessage(data.DataObject);
                        break;
                    case 1020: //首页预警信息
                        showWarnMessage(data.DataObject);
                        //alert("播放提示音!");
                        ////播放提示音
                        //playTipMusic();
                        break;
                    case 1030: //定位器(所属的及关注中的)上下线的最近位置
                        //更新界面上的定位数据显示
                        //cometUpdateDeviceLocation(data.DataObject, data.DataType);
                        break;
                }
            }
            //Comet轮询
            getCometServerPush(userId);
        },
        error: function (xhr, err) {
            //alert(xhr.status);
            //window.location.reload();
            //alert("readyState: " + xhr.readyState + "\nstatus: " + xhr.status);
            //alert("responseText: " + xhr.responseText);
        }
    });
}

//function playTipMusic() {
//    $("#jquery_jplayer_1").jPlayer("play");
//}

function popupUnreadMessageNotify(count) {
    /// <summary>右下角弹框显示未读消息提醒</summary>
    /// <param name="count" type="int">未读消息数</param>
    var callback = function (data) {
        if (data == 0) return;
        ////如果未读消息列表已显示,则返回
        //if (PopupMessageCenter.is(":visible")) return;
        var wind = $("#wind");
        //更新数量
        wind.html(data);
        ////显示弹框
        //popup.slideDown("slow");
    };
    //如果传入空参数则直接显示
    if (count != "")
        callback(count);
    else//否则从服务器获取
        return;
}


//书写首页预警
function showWarnMessage(str) {
    var callback = function (data) {
        if (data == 0) return;
        var warn = $("#warn"); 
        //更新数量
        warn.html(data);
    };
    //如果传入为空则直接显示
    if (str != "")
        callback(str);
    else//否则从服务器获取
        return;
}

//书写避风预警页面的值
function showWindMessage(str) {
    return;
}
