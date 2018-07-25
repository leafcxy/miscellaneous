$(document).ready(function () {
    jQuery.fn.anim_progressbar = function (aOptions) {
        //������ͣ��ʶ
        jQuery.fn.anim_progressbar.stopFlag=true;
        //���ټ���ֵ
        jQuery.fn.anim_progressbar.intervalCount=1;
        //����ֵ
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
                        //�����Ŀǰ�Ѳ��Ž��ȵİٷֱ�
                        iPerc = (jQuery.fn.anim_progressbar.playTime > 0) ? jQuery.fn.anim_progressbar.playTime / iDuration * 100 : 0; // percentages

                        // display current positions and progress
                        $(vPb).children('.percent').html('<b>' + iPerc.toFixed(1) + '%</b>');
                        if (displayFlag == "trackPlaying") {//������ڲ���                            
                            //��ǰ����ʱ��
                            $("#movieInfo").contents().find("#elapsed").html(myApp.util.formatDateToCNString(new Date(Date.parse(aOpts.start.replace(/-/g, "/")) + jQuery.fn.anim_progressbar.playTime)));
                            //��Сʱ��ʾ
                            $("#elapsedbackup").html($("#movieInfo").contents().find("#elapsed").html());
                            //��ǰ���ű���
                            $("#movieInfo").contents().find("#speedCount").html(jQuery.fn.anim_progressbar.intervalCount);
                            //��Сʱ��ʾ
                            $("#speedCountbackup").html($("#movieInfo").contents().find("#speedCount").html());
                        }
                        else if (displayFlag == "trackPlay") {
                            //������Ź��̣�����ǰδ�ҵ�ѡ�д���������κ�����
                            if (jQuery.fn.anim_progressbar.playTime<600000)
                            {
                                //����600000���뻹δ�ҵ����ݣ�����ʾ�쳣��Ϣ
                                window.frames["movieInfo"].changInfo(1);
                            }
                            else
                            {
                                //������δ�ҵ����ݵ��Ѻ���ʾ
                                window.frames["movieInfo"].changInfo(2);
                            }
                        }
                        
                        //$(vPb).children('.elapsed').html(myApp.util.formatDateToCNString(new Date(Date.parse(aOpts.start.replace(/-/g,"/"))+jQuery.fn.anim_progressbar.playTime))+'</b>');
                        //��ǰ�طŵ�ʱ��
                        var currentPlayTime = myApp.util.formatDateToString(new Date(Date.parse(aOpts.start.replace(/-/g, "/")) + jQuery.fn.anim_progressbar.playTime));
                        //����ʱ����������ӻ�ȡһ������
                        //var playVan = 0;
                        //if (jQuery.fn.anim_progressbar.intervalCount>1)
                        //{//�������ʱ��������30�룬��ʵʱ��ȡ
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
                            //��ѡ�����д���ʱ
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
                            //movieInfo.elapsed.innerHTML = '�طŽ���';
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