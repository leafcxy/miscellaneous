$(document).ready(function () {
    jQuery.fn.anim_progressbar = function (aOptions) {
        //播放暂停标识
        jQuery.fn.anim_progressbar.stopFlag=true;
        //加速减速值
        jQuery.fn.anim_progressbar.intervalCount=1;
        //播放值
        jQuery.fn.anim_progressbar.playTime=0;
        // def values
        var iCms = 1000;
        var iMms = 60 * iCms;
        var iHms = 3600 * iCms;
        var iDms = 24 * 3600 * iCms;
        var displayFlag = "";

        // def options
        var aDefOpts = {
            start: new Date(), // now
            finish: new Date().setTime(new Date().getTime() + 1 * iCms), // now + 1 sec
            interval: 20000
        }
        var aOpts = jQuery.extend(aDefOpts, aOptions);
        var vPb = this;
        // calling original progressbar
        //$(vPb).children('.pbar').progressbar();
        //$(vPb).children('.pbar').children('.ui-progressbar-value').css('width', '0%');
        myApp.service.showShipsHistory($("#movieInfo").contents().find("#selShipId").val(), myApp.util.formatDateToString(new Date(Date.parse(aOpts.start.replace(/-/g, "/")))), 'trackPlay');
        // each progress bar
        return this.each(
            function() {
                var iDuration = Date.parse(aOpts.finish.replace(/-/g,"/")) - Date.parse(aOpts.start.replace(/-/g,"/"));
                // looping process
                var vInterval = setInterval(
                    function(){
                        if(jQuery.fn.anim_progressbar.stopFlag)
                        {                            
                            return;
                        }
                        else
                        {
                            jQuery.fn.anim_progressbar.playTime+=aOpts.interval*jQuery.fn.anim_progressbar.intervalCount;
                        }
                        //var iLeftMs = aOpts.finish - new Date(); // left time in MS
                        //var iElapsedMs = aOpts.start+playTime, // elapsed time in MS
                        //iDays = parseInt(iLeftMs / iDms), // elapsed days
                        //iHours = parseInt((iLeftMs - (iDays * iDms)) / iHms), // elapsed hours
                        //iMin = parseInt((iLeftMs - (iDays * iDms) - (iHours * iHms)) / iMms), // elapsed minutes
                        //iSec = parseInt((iLeftMs - (iDays * iDms) - (iMin * iMms) - (iHours * iHms)) / iCms), // elapsed seconds
                        //计算出目前已播放进度的百分比
                        iPerc = (jQuery.fn.anim_progressbar.playTime > 0) ? jQuery.fn.anim_progressbar.playTime / iDuration * 100 : 0; // percentages

                        // display current positions and progress
                        $(vPb).children('.percent').html('<b>' + iPerc.toFixed(1) + '%</b>');
                        if (displayFlag == "trackPlaying") {//如果正在播放                            
                            //当前播放时间
                            $("#movieInfo").contents().find("#elapsed").html(myApp.util.formatDateToCNString(new Date(Date.parse(aOpts.start.replace(/-/g, "/")) + jQuery.fn.anim_progressbar.playTime)));
                            //缩小时显示
                            $("#elapsedbackup").html($("#movieInfo").contents().find("#elapsed").html());
                            //当前播放倍速
                            $("#movieInfo").contents().find("#speedCount").html(jQuery.fn.anim_progressbar.intervalCount);
                            //缩小时显示
                            $("#speedCountbackup").html($("#movieInfo").contents().find("#speedCount").html());
                        }
                        else if (displayFlag == "trackPlay") {
                            //如果播放过程，但当前未找到选中船舶的相关任何数据
                            if (jQuery.fn.anim_progressbar.playTime<600000)
                            {
                                //超过600000毫秒还未找到数据，则提示异常信息
                                window.frames["movieInfo"].changInfo(1);
                            }
                            else
                            {
                                //给出暂未找到数据的友好提示
                                window.frames["movieInfo"].changInfo(2);
                            }
                        }
                        
                        //$(vPb).children('.elapsed').html(myApp.util.formatDateToCNString(new Date(Date.parse(aOpts.start.replace(/-/g,"/"))+jQuery.fn.anim_progressbar.playTime))+'</b>');
                        //当前回放的时间
                        var currentPlayTime = myApp.util.formatDateToString(new Date(Date.parse(aOpts.start.replace(/-/g, "/")) + jQuery.fn.anim_progressbar.playTime));
                        //播放时间间隔，半分钟获取一次数据
                        //var playVan = 0;
                        //if (jQuery.fn.anim_progressbar.intervalCount>1)
                        //{//当插入的时间间隔大于30秒，则实时获取
                        //    playVan = 0;
                        //}
                        //else
                        //{
                        //    playVan = jQuery.fn.anim_progressbar.playTime % 30000;
                        //}
                        //if (playVan == 0 || jQuery.fn.anim_progressbar.playTime == aOpts.interval)
                        //{
                        //    displayFlag = myApp.service.showShipsHistory(movieInfo.selShipId.value, currentPlayTime, 'trackPlay');
                        //}
                        if ($("#movieInfo").contents().find("#selectAll").attr("checked") == "checked") {
                            //当选择所有船舶时
                            displayFlag = myApp.service.showShipsHistory("all", currentPlayTime, 'trackPlay', $("#movieInfo").contents().find("#selShipId").val());
                        }
                        else {
                            displayFlag = myApp.service.showShipsHistory($("#movieInfo").contents().find("#selShipId").val(), currentPlayTime, 'trackPlay');
                        }
                        $(vPb).children('.percentRow').children('.progress').children('.progress-bar').css('width', iPerc + '%');
						//alert(iPerc);
                        // in case of Finish
                        if ($("#movieInfo").contents().find("#startTime").val() == "")
                        {
                            clearInterval(vInterval);
                        }
                        if (iPerc >= 100) {
                            clearInterval(vInterval);
                            //$(vPb).children('.percent').html('<b>100%</b>');
                            //movieInfo.elapsed.innerHTML = '回放结束';
                        }
                        else
                        {
                            
                        }
                    } ,aOpts.interval
                );
            }
        );
    }
    
    jQuery.fn.anim_progressbar.init = function (id) {

        var vPb = $('#'+id);
        // calling original progressbar
        //$(vPb).children('.pbar').progressbar();
        $(vPb).children('.percentRow').children('.progress').children('.progress-bar').css('width', '1%');
    }

});