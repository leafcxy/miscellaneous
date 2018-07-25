/******************************************************************************** 
** 作者：杨扬
** 时间：2012-10-12
** 描述：常用报表js
*********************************************************************************/




function radOrClick(obj, type) {
    var myDate = new Date();
    if (type == 0) {//不限
        $('#' + obj.name.replace('radLink', 'Input')).val('');
    }
    else if (type == 1) {//本月
        var thisMonth = myDate.getFullYear() + '-' + monthCheck((myDate.getMonth() + 1).toString()) + '-' + '01';
        $('#' + obj.name.replace('radLink', 'Select')).val('>=');
        $('#' + obj.name.replace('radLink', 'Input')).val($(obj).attr('value') + thisMonth);
    }
    else if (type == 2) {//上月
        var thisMonth = myDate.getFullYear() + '-' + monthCheck((myDate.getMonth() + 1).toString()) + '-' + '01';
        var lastMonth = myDate.getFullYear() + '-' + monthCheck((myDate.getMonth()).toString()) + '-' + '01';
        $('#' + obj.name.replace('radLink', 'Select')).val('<');
        $('#' + obj.name.replace('radLink', 'Input')).val(thisMonth + $(obj).attr('value') + lastMonth);
    }   
    else if (type == 9) {//自定义
        $(obj).parent().parent().hide().next().show().next().show();
        $(obj).parent().parent().prev().show().prev().hide();
        $('#' + obj.name.replace('radLink', 'Input')).val('');
    }
};
function radioClick(obj) {
    $('input[name=' + obj.name + ']').attr('checked', false);
    $(obj).attr('checked', 'checked');
};
function monthCheck(mon) {
    if (mon.length == 1) {
        mon = '0' + mon;
    };
    return mon;
};

function radOrBack(obj) {
    $(obj).parent().hide().prev().show();
    $(obj).parent().next().show().next().hide().next().hide();
    $("#" + $(obj).attr('radid')).click();
};

(function($) {
    //查询组数
    var highSearchPar = 1;
    var sitem = {};
    var searchs = new Array();
    var columnDatas = {};
    var dbType = "sqlserver";
    var t = document.createElement('div');
    var d = {};
    var exportOn = false;
    $.addReport = function (p) {

        // apply default properties
        d = $.extend({
            getDataUrl: '../../Share/Report/ReportData?date=' + new Date().getTime()
            , xmlUrl: 'C:\\Documents and Settings\\Administrator\\桌面\\1.xml'
            , debug: true
            , sql: "select '无' from dual"
        }, p);

        //全局变量
        sitems = d.sitems;



        var formSerach = document.createElement('form');
        var formDiv = document.createElement('div');
        var btnNext3 = document.createElement('button');
        var btnIncrease = document.createElement('button');
        var btnNext4 = document.createElement('button');
        var aDiv = document.createElement('div');
        var span = document.createElement('span');
        var divStep2 = document.createElement('div');
        var divStep3 = document.createElement('div');


        //报表内容div
        if (!d.debug)
            $("#report").html(insertReport2('AF', 'Rebar=none;')); //insertReport2('AF', 'Rebar=none;')
        else
            $("#report").html(insertReport2('AF', '')); //insertReport2('AF', '')
        $(divStep2).addClass('formSerch').append(formSerach).append(aDiv);
        //三个按钮
        $(btnNext3).addClass('btn-margin btn-info').html('查询').attr("id","searchReport");
        $(btnIncrease).addClass('btn-margin btn-info').html('增加更多查询条件');
        $(btnNext4).addClass('btn-margin btn-info').html('导出Excel');
        //按钮的SPAN
        $(span).addClass('input-group-btn').append(btnNext3).append(btnIncrease).append(btnNext4);
        //按钮SPAN的DIV
        $(aDiv).addClass('aDiv').append(span);
        //查询框的div
        //$(formDiv).addClass('formDiv').append(formSerach);
        $(t).addClass('formDiv').append(divStep2).append(divStep3);


        //重载此页面弹出框标题的HTML样式
        $.widget("ui.dialog", $.extend({}, $.ui.dialog.prototype, {
            _title: function (title) {
                var $title = this.options.title || '&nbsp;'
                if (("title_html" in this.options) && this.options.title_html == true)
                    title.html($title);
                else title.text($title);
            }
        }));

        //默认加载第一组查询
        if (highSearchPar == 1)
            $(formSerach).append(HighSearch());
        //移除顶端遮罩
        //if (top.hideMask) top.hideMask();

        $("#searchReport").on('click', function (e) {
            e.preventDefault();

            var dialog = $("#report").removeClass('hide').dialog({
                modal: true,
                title: "<div class='widget-header widget-header-small'><h4 class='smaller'>统计报表</h4></div>",
                title_html: true,
                width: 1200,
                height: 800
            });

            var params = [
				         { name: 'where', value: GetWhereSql() }
				         , { name: 'sql', value: escape(d.sql) }
				         , { name: 'Action', value: "GetData2" }

            ];
            
            if (d.xmlUrl.indexOf("ReportForCountArrange") > 0
             || d.xmlUrl.indexOf("ReportForCountCollect") > 0
             || d.xmlUrl.indexOf("ReportForAnchTime") > 0
             || d.xmlUrl.indexOf("ReportForCountJoin") > 0
             || d.xmlUrl.indexOf("ReportForTimingOut") > 0)
                ShowReport1(params);
            else
                ShowReport(params);
            
            //开启导出功能
            exportOn = true;
        });

        //查询报表
        $(btnNext3).mouseup
        (function () {
            //呈现顶端遮罩
            //if (top.showMask) top.showMask();
            var params = [
				         { name: 'where', value: GetWhereSql() }
				         , { name: 'sql', value: escape(d.sql) }
				         , { name: 'Action', value: "GetData2" }

            ];
            
            if (d.xmlUrl.indexOf("ReportForCountArrange") > 0
             || d.xmlUrl.indexOf("ReportForCountCollect") > 0
             || d.xmlUrl.indexOf("ReportForAnchTime") > 0
             || d.xmlUrl.indexOf("ReportForCountJoin") > 0
             || d.xmlUrl.indexOf("ReportForTimingOut") > 0)
                ShowReport1(params);
            else
                ShowReport(params);

            //开启导出功能
            exportOn = true;
        }
        );

        //回车则开始查询
        $('input[type=text],select', t).keydown(function(e) {
            if (e.keyCode == 13) {
                $(btnNext3).click();
            }
        });



        //增加一组查询条件
        $(btnIncrease).click(
            function() { AddSelectGroup(formSerach); }
	    );

        $(btnNext4).click(
            function () {
                if (exportOn)
                {
                    //呈现顶端遮罩
                    //if (top.showMask) top.showMask();

                    var dateTmp = new Date();
                    var tagFolder = "c:\\数据导出" + dateTmp.getTime() + ".xls";
                    AF.func("CallFunc", "105\r\nType=xls;filename=" + tagFolder);
                    alert('已经将文件导出到C盘根目录，地址如下：' + tagFolder);
                    //移除顶端遮罩
                    //if (top.hideMask) top.hideMask();
                }
                else
                {
                    alert('没有找到数据，请点击查询获取信息。');
                }
            });
    };


    //显示报表
    function ShowReport(params) {
        $.ajax({
            type: 'POST',
            url: d.getDataUrl,
            data: params,
            dataType: 'json',
            success: function (data, status, XHR) {
                AF.func("Build", d.xmlUrl);
                AF.func("SeparateView", "1\r\n1"); //分屏冻结窗口
                AF.func("SetSource", "ds1\r\n../../" + data.path);
                if (!d.debug) {
                    AF.func('addUnEditAbleOnly', 'bgColor=T');
                    AF.func("Swkrntpomzqa", "1,2,4, 8,16,32, 128, 64");
                }
                else {
                    $('.aDiv').append(data.path);
                }
                AF.func('Calc', '');
                //移除顶端遮罩
                //if (top.hideMask) top.hideMask();
            },
            error: function(XHR, status, errorThrow) {
                alert('信息', XHR.responseText, '500');
            }
        });
    };
    //显示报表
    function ShowReport1(params) {
        $.ajax({
            type: 'POST',
            url: d.getDataUrl,
            data: params,
            dataType: 'json',
            success: function (data, status, XHR) {
                AF.func("Build", d.xmlUrl);
                AF.func("SeparateView", "2\r\n1"); //分屏冻结窗口
                AF.func("SetSource", "ds1\r\n../../" + data.path);
                if (!d.debug) {
                    AF.func('addUnEditAbleOnly', 'bgColor=T');
                    AF.func("Swkrntpomzqa", "1,2,4, 8,16,32, 128, 64");
                }
                else {
                    $('.aDiv').append(data.path);
                }
                AF.func('Calc', '');
                //移除顶端遮罩
                //if (top.hideMask) top.hideMask();
            },
            error: function (XHR, status, errorThrow) {
                alert('信息', XHR.responseText, '500');
            }
        });
    };

    function HighSearch() {
        if (highSearchPar > 10) {
            alert("不能超过十组查询！");
            return;
        }
        var search = ""
                    + "    <div class='widget-box'>"
                    + "       <div class='widget-header'>"
                    + "         <h4>第" + highSearchPar + "组</h4>"
                    + "             <span class='widget-toolbar'>"
                    + "                <a href='#' data-action='collapse'>"
                    + "                    <i class='icon-chevron-up'></i>"
                    + "                </a>"
                    + "             </span>"
                    + "       </div>"
                    + "         <div class='widget-body'>"
                    + "           <div class='widget-main'>"
                    + "             <div class='row'> ";
        //每个字段的代码
        var searchNode = "              <div class='col-xs-12 col-md-6 col-lg-4' style='padding-top:8px;'> "
                    + "                     <label>{display}</label>"
                    + "                     <select name='{name}Select" + highSearchPar + "' id='{name}Select" + highSearchPar + "' style='width: 80px;' accessKey='d'>{selectOption}</select>"
                    + "                     <input type='text' name='{name}Input" + highSearchPar + "' id='{name}Input" + highSearchPar + "' {check} />"
                    + "                 </div>";
        var searchNodeForOracleDate = " <div class='col-xs-12 col-md-4 col-lg-4'> "
                    + "                             <label>{display}</label>"
                    + "                             <span style=display:none'>{display}(<a onclick='radOrBack(this)' radid='{name}radOr1" + highSearchPar + "' href='##'>返回</a>)</span>"
                    + "                             <span>"
                    + "                                 <label><input id='{name}radOr1" + highSearchPar + "' class='ace' onclick='radOrClick(this,0)'  type='radio' name='{name}radLink" + highSearchPar + "' value='' /><span class='lbl'>不限</span></label>"
                    + "                                 <label><input id='{name}radOr2" + highSearchPar + "' class='ace' onclick='radOrClick(this,1)'  type='radio' name='{name}radLink" + highSearchPar + "' value=\"','yyyy-mm-dd') and Add_months({name},-1)< to_date('\" /><span class='lbl'>本月</span></label>"
                    + "                                 <label><input id='{name}radOr3" + highSearchPar + "' class='ace' onclick='radOrClick(this,2)'  type='radio' name='{name}radLink" + highSearchPar + "' value=\"','yyyy-mm-dd') and Add_months({name},+1)>= to_date('\" /><span class='lbl'>上月</span></label>"
                    + "                                 <label><input id='{name}radOr4" + highSearchPar + "' class='ace' onclick='radOrClick(this,9)'  type='radio' name='{name}radLink" + highSearchPar + "' value='' /><span class='lbl'>自定义</span></label>"
                    + "                             </span>"
                    + "                             <select style='display:none' name='{name}Select" + highSearchPar + "' id='{name}Select" + highSearchPar + "' style='width: 80px;' accessKey='d'>{selectOption}</select>"
                    + "                             <input style='display:none' type='text' name='{name}Input" + highSearchPar + "' id='{name}Input" + highSearchPar + "' placeholder='选择日期' data-date-format='yyyy-mm-dd' class='searchString date-picker' {check}/>"
                    + "                 </div>";
        var searchNodeForSqlServerDate = "       <div class='col-xs-12 col-md-4 col-lg-4' style='padding-top:8px;padding-right:0px;'> "
                    + "                             <label>{display}</label>"
                    + "                             <span style='display:none;font-size:14px'>{display}(<a onclick='radOrBack(this)' radid='{name}radOr1" + highSearchPar + "' href='##'>返回</a>)</span>"
                    + "                             <span>"
                    + "                                <label><input id='{name}radOr1" + highSearchPar + "' class='ace' onclick='radOrClick(this,0)'  type='radio' name='{name}radLink" + highSearchPar + "' value='' /><span class='lbl'>不限</span></label>"
                    + "                                <label><input id='{name}radOr2" + highSearchPar + "' class='ace' onclick='radOrClick(this,1)'  type='radio' name='{name}radLink" + highSearchPar + "' value='' /><span class='lbl'>本月</span></label>"
                    + "                                <label><input id='{name}radOr3" + highSearchPar + "' class='ace' onclick='radOrClick(this,2)'  type='radio' name='{name}radLink" + highSearchPar + "' value=\"' and {name} >= '\" /><span class='lbl'>上月</span></label>"
                    + "                                <label><input id='{name}radOr4" + highSearchPar + "' class='ace' onclick='radOrClick(this,9)'  type='radio' name='{name}radLink" + highSearchPar + "' value='' /><span class='lbl'>自定义</span></label>"
                    + "                             </span>"
                    + "                             <select style='display:none;height:25px;' name='{name}Select" + highSearchPar + "' id='{name}Select" + highSearchPar + "' style='width: 80px;' accessKey='d'>{selectOption}</select>"
                    + "                             <input style='display:none;padding-top:0px;' type='text' name='{name}Input" + highSearchPar + "' id='{name}Input" + highSearchPar + "' placeholder='选择日期' data-date-format='yyyy-mm-dd' class='searchString date-picker' {check}/>"
                    + "                 </div>";
        //两种不同情况的条件下拉框
        var qmodeStr = "<option value='like'>包含</option><option value='not like'>不包含</option><option value='='>等于</option><option value='<>'>不等于</option>";
        var qmodeInt = "<option value='='>等于</option><option value='<>'>不等于</option><option value='>'>大于</option><option value='>='>大于等于</option><option value='<'>小于</option><option value='<='>小于等于</option>";
        var qmodeOracleDate = "<option value='='>等于</option><option value='>='>大于等于</option><option value='-1<'>小于等于</option><option value='-1>='>大于</option><option value='<'>小于</option>";
        var qmodeSqlServerDate = "<option value='='>等于</option><option value='>='>大于等于</option><option value='<'>小于等于</option><option value='>='>大于</option><option value='<'>小于</option>";
        //输入验证
        var checkStr = "";
        //下拉框值
        var selectOptionStr = "";
        //循环取得要查询的字段的HTML代码
        for (var s = 0; s < sitems.length; s++) {
            //给不同的数据类做不同的查询条件选择和输入验证
            if (sitems[s].qcheck == 'Datetime' || sitems[s].qcheck == 'Date') {
                checkStr = "type='text' placeholder='选择日期' data-date-format='yyyy-mm-dd' class='searchString date-picker'";
                if (dbType == "oracle")
                {
                    selectOptionStr = qmodeOracleDate;
                    search += ReplaceAll(searchNodeForOracleDate.replace('{check}', checkStr).replace('{selectOption}', selectOptionStr).replace('{display}', sitems[s].display).replace('{display}', sitems[s].display), '{name}', sitems[s].name);
                }
                else
                {
                    selectOptionStr = qmodeSqlServerDate;
                    search += ReplaceAll(searchNodeForSqlServerDate.replace('{check}', checkStr).replace('{selectOption}', selectOptionStr).replace('{display}', sitems[s].display).replace('{display}', sitems[s].display), '{name}', sitems[s].name);
                }
                
            }
            else if (sitems[s].qcheck == 'Int') {
                checkStr = "require='false' dataType='Integer' msg='" + sitems[s].display + "格式不正确'";
                selectOptionStr = qmodeInt;
                search += searchNode.replace('{check}', checkStr).replace('{selectOption}', selectOptionStr).replace('{display}', sitems[s].display).replace('{name}', sitems[s].name).replace('{name}', sitems[s].name).replace('{name}', sitems[s].name).replace('{name}', sitems[s].name);
            }
            else if (sitems[s].qcheck == 'Decimal') {
                //正值表达式里一个“\”要换成两个
                checkStr = "require='false' dataType='Custom' regexp='^([+-]?)\\d*\\.?\\d+$' msg='" + sitems[s].display + "格式不正确'";
                selectOptionStr = qmodeInt;
                search += searchNode.replace('{check}', checkStr).replace('{selectOption}', selectOptionStr).replace('{display}', sitems[s].display).replace('{name}', sitems[s].name).replace('{name}', sitems[s].name).replace('{name}', sitems[s].name).replace('{name}', sitems[s].name);
            }
            else {
                checkStr = "require='false'";
                selectOptionStr = qmodeStr;
                search += searchNode.replace('{check}', checkStr).replace('{selectOption}', selectOptionStr).replace('{display}', sitems[s].display).replace('{name}', sitems[s].name).replace('{name}', sitems[s].name).replace('{name}', sitems[s].name).replace('{name}', sitems[s].name);
            }
            
        }
        search += "            </div>"
                    + "         </div>"
                    + "         </div>"
                    + "     </fieldset>"
                    + "     </div>";
        searchs[highSearchPar - 1] = sitems;
        highSearchPar++;
        //$.parser.parse();
        //setTimeout("$.parser.parse()", 1000);
        return search;
    };
    function datePicker() {
        //日期控件
        setTimeout("$('.date-picker').datepicker({ autoclose: true }).next().on(ace.click_event, function () {$(this).prev().focus();});", 100);
    };
    //全部替换
    function ReplaceAll(oldStr, replaceStr, newStr) {
        var arrTmp = oldStr.split(replaceStr);
        var strTmp = '';

        for (var i = 0; i < arrTmp.length - 1; i++) {
            strTmp += arrTmp[i] + newStr;
        }
        strTmp += arrTmp[i];
        //alert(strTmp);
        return strTmp;
    };

    //取查询条件sql
    function GetWhereSql() {
        if (dbType == "oracle") {
            return GetWhereSqlForOracle();
        }
        else {
            return GetWhereSqlForMsSqlServer();
        }
    };
    //oracle取查询条件sql
    function GetWhereSqlForOracle() {
        //var cookieParam = p.queryCode + "," + highSearchPar;
        //var cookieParamTmp = "";
        var whereSqlStr = " and ";
        var whereSqlGroup = " 1=1 ";
        var inputStr = "";
        var whereSqlNode = " and {name} {select} '{input}' ";
        var whereSqlNodeForInt = " and {name} {select} {input} ";
        var whereSqlNodeForDate = " and {name} {select} to_date('{input}', 'yyyy-mm-dd') ";
        var whereSqlNodeForDate2 = " and floor({name} - to_date('{input}', 'yyyy-mm-dd hh24:mi:ss')) = 0 ";
        //验证输入
        //if (!Validator.Validate(document.getElementById('formSerach'), null, false)) {
        //    return false;
        //}

        //循环所有字段，有填东西的字段，生成查询语句
        for (var i = 1; i < highSearchPar; i++) {
            if (i != 1) {
                //查询组之前的“并且、或者”
                var objTmp = $('input[name=radLink' + i + '][checked]');
                whereSqlStr += "(" + whereSqlGroup + ")" + objTmp.val() + " ";
                whereSqlGroup = " 1=1 ";
            }

            for (var s = 0; s < searchs[i - 1].length; s++) {
                var objSelectTmp = $('select[name=' + searchs[i - 1][s].name + 'Select' + i + ']', t);
                var objInputTmp = $('input[name=' + searchs[i - 1][s].name + 'Input' + i + ']', t);
                //根据不同的数据类型和查询符号，进行不同的处理组装sql
                if (objInputTmp.val() != '') {

                    if (searchs[i - 1][s].qcheck == "Date" || searchs[i - 1][s].qcheck == "Datetime") {
                        if (objSelectTmp.val() == '=') {
                            inputStr = objInputTmp.val();
                            whereSqlGroup += whereSqlNodeForDate2.replace('{name}', searchs[i - 1][s].name).replace('{input}', inputStr);
                        }
                        else {
                            inputStr = objInputTmp.val();
                            whereSqlGroup += whereSqlNodeForDate.replace('{name}', searchs[i - 1][s].name).replace('{select}', objSelectTmp.val()).replace('{input}', inputStr);
                        }

                    }
                    else if (searchs[i - 1][s].qcheck == "Int" || searchs[i - 1][s].qcheck == "Decimal") {

                        inputStr = objInputTmp.val();
                        whereSqlGroup += whereSqlNodeForInt.replace('{name}', searchs[i - 1][s].name).replace('{select}', objSelectTmp.val()).replace('{input}', inputStr);
                    }
                    else {
                        if (objSelectTmp.val().indexOf('like') > -1) {
                            inputStr = "%" + ReplaceAll(objInputTmp.val(), "'", "''") + "%";
                        }
                        else {
                            inputStr = ReplaceAll(objInputTmp.val(), "'", "''");
                        }
                        whereSqlGroup += whereSqlNode.replace('{name}', searchs[i - 1][s].name).replace('{select}', objSelectTmp.val()).replace('{input}', inputStr);
                    }
                }
            }
        }
        whereSqlStr += "(" + whereSqlGroup + ")";

        return escape(whereSqlStr);
    };

    //MsSqlServer取查询条件sql
    function GetWhereSqlForMsSqlServer() {
        var whereSqlStr = " and ";
        var whereSqlGroup = " 1=1 ";
        var inputStr = "";
        var whereSqlNode = " and {name} {select} '{input}' ";
        var whereSqlNodeForDate = " and {name} like '{input}%' ";

        //循环所有字段，有填东西的字段，生成查询语句
        for (var i = 1; i < highSearchPar; i++) {
            if (i != 1) {
                //alert($('input[name=radLink' + i + '][checked]').val());
                var objTmp = $('input[name=radLink' + i + '][checked]');
                whereSqlStr += "(" + whereSqlGroup + ") " + objTmp.val() + " ";
                whereSqlGroup = " 1=1 ";
                //cookieParam += "," + objTmp.attr("id") + "," + objTmp.val();

            }

            for (var s = 0; s < searchs[i - 1].length; s++) {
                var objSelectTmp = $('select[name=' + searchs[i - 1][s].name + 'Select' + i + ']', highSearchDiv);
                var objInputTmp = $('input[name=' + searchs[i - 1][s].name + 'Input' + i + ']', highSearchDiv);

                if (objInputTmp.val() != '') {
                    if (searchs[i - 1][s].qcheck == "Date" || searchs[i - 1][s].qcheck == "Datetime") {
                        if (objSelectTmp.val() == '=') {
                            inputStr = objInputTmp.val();
                            whereSqlGroup += whereSqlNodeForDate.replace('{name}', searchs[i - 1][s].name).replace('{input}', inputStr);
                        }
                        else {
                            inputStr = objInputTmp.val();
                            whereSqlGroup += whereSqlNode.replace('{name}', searchs[i - 1][s].name).replace('{select}', objSelectTmp.val()).replace('{input}', inputStr);
                        }

                    }
                    else if (searchs[i - 1][s].qcheck == "Int" || searchs[i - 1][s].qcheck == "Decimal") {

                        inputStr = objInputTmp.val();
                        whereSqlGroup += whereSqlNode.replace('{name}', searchs[i - 1][s].name).replace('{select}', objSelectTmp.val()).replace('{input}', inputStr);
                    }
                    else {
                        if (objSelectTmp.val().indexOf('like') > -1) {
                            inputStr = "%" + ReplaceAll(objInputTmp.val(), "'", "''") + "%";
                        }
                        else {
                            inputStr = ReplaceAll(objInputTmp.val(), "'", "''");
                        }
                        whereSqlGroup += whereSqlNode.replace('{name}', searchs[i - 1][s].name).replace('{select}', objSelectTmp.val()).replace('{input}', inputStr);
                    }
                    
                }
            }
        }
        whereSqlStr += "(" + whereSqlGroup + ")";

        return escape(whereSqlStr);
    };

    //增加一组查询条件
    function AddSelectGroup(form) {
        if (highSearchPar > 10) {
            alert("不能超过十组查询！");
            return;
        }
        datePicker();
        resizeMain(180);
        var radStrTmp = ""
				            + "     "
				            + "     <div style='width:100%;height:30px' >"
                            + "     <input id='radAnd" + highSearchPar + "'  type='radio' onfocus='radioClick(this)' checked='checked' name='radLink" + highSearchPar + "' value='and' /><label>并且</label>"
        //+ "     </td><td style='width:30px'>"
                            + "     <input id='radOr" + highSearchPar + "'  type='radio' onfocus='radioClick(this)' name='radLink" + highSearchPar + "' value='or' /><label>或者</label>"
                            + "     (\"<label style=\"font-size:13px;color:#ff0000;\">并且</label>\"会优先合并计算)</div>"
                            + "     ";
        $(form).append(radStrTmp);
        $(form).append(HighSearch());

    };
    var docloaded = false;

    $(document).ready(function () { docloaded = true; datePicker(); });

    $.fn.Report = function(p) {

        return this.each(function() {
            if (!docloaded) {
                //$(this).hide();
                t = this;
                $(document).ready
					(
						function() {
						    $.addReport(p);
						}
					);
            } else {
                $.addReport(this, p);
            }
        });

    }; //end flexigrid

})(jQuery);