/******************************************************************************** 
** 作者：杨扬
** 时间：2012-10-12
** 描述：自定义报表js
*********************************************************************************/
//全局变量
var sitems = {};
var searchs = new Array();
//var columnDatas = {};
var highSearchDiv = $('#highSearchDiv');
//查询组数
var highSearchPar = 1;
var dbType = "sqlserver"; //数据库类型配置oracle,sqlserver 

//通过配置以下数据，生成要查询的列的选择功能，配置的name和数据类型，要和数据源里的字段名一至，配置的数据类型，只能有以下几种：String,Int,Decimal,Date,Datetime

/*
var tmp = "["



        + "{title:'基本信息',citems:["//
        + "{display: '申请编号', name : 'apply_num', qcheck: 'String'}"
        + ",{display: '申请事项名称', name : 'applyer_item_name', qcheck: 'String'}"

        + "]}"


        + ",{title:'基本信息',citems:["//
        + "{display: '申请编号', name : 'apply_num', qcheck: 'String'}"
        + ",{display: '申请事项名称', name : 'applyer_item_name', qcheck: 'String'}"

        + "]}"



        + "]";
var action = "GetData";
*/
//columnDatas = eval(tmp);


//生成模板
function GetXmlTemplate(dataCount) {

    var len = sitems.length;
    var tmp = "";
    var s = ''
+ '<?xml version="1.0" encoding="UTF-8" ?>'
+ '<!--By Supcan Report -->'
+ '<Report>'
	+ '<WorkSheet name="Sheet" isDefaultPrint="true">'
		+ '<Properties><sort>CODE d</sort>'
			+ '<BackGround bgColor="#FFFFFF" arrange="left,top" alpha="255"/>'
			+ '<DefaultTD>'
				+ '<TD fontIndex="0" textColor="#000000" transparent="true" leftBorder="1" topBorder="1" leftBorderColor="#C0C0C0" leftBorderStyle="solid" topBorderColor="#C0C0C0" topBorderStyle="solid" decimal="2" align="left" vAlign="middle" isProtected="false" isThousandSeparat="true" datatype="1" isRound="true" isPrint="true"/>'
			+ '</DefaultTD>'
			+ '<Other isShowZero="true" isRefOriPrecision="true" AutoBreakLine="3" LineDistance="0" isRowHeightAutoExtendAble="true" isRowHeightAutoExtendAfterRefreshed="true"/>'
		+ '</Properties>'
		+ '<Fonts>'
			+ '<Font faceName="宋体" charSet="134" height="-14" weight="400"/>'
		+ '</Fonts>'
		+ '<Table>';
    var topTdCount = 6;
    if (len > topTdCount) topTdCount = len;
    for (var i = 1; i < topTdCount; i++) {
        s += '<Col width="140"/>';
    }
    s += '<Col width="15"/>'
        + '<TR height="24" sequence="0"><TD>企业总数：</TD><TD datatype="1" formula="=data(&apos;ds1\\CountTable&apos;, 1, &apos;CASECOUNT&apos;)"/><TD>当前显示：</TD><TD datatype="1" formula="=data(&apos;ds1\\CountTable&apos;, 1, &apos;ALLCOUNT&apos;)"/><TD>行数据</TD>';

    s += '<TD topBorder="0"/>'
			+ '</TR>'
			+ '<TR height="24" sequence="1">';
	//生成标题
    for (var i = 1; i < len; i++) {

        s += '<TD>' + sitems[i].display + '</TD>';

    }
    s += '<TD topBorder="0"/>'
			+ '</TR>'
			+ '<TR height="24" sequence="2">';
	//设置数据源
    for (var i = 1; i < len; i++) {
        var maskStr = "";
        //if (sitems[i].qcheck == "Datetime") {
        //    maskStr = 'datatype="1" maskid="1"';
        //}
        //else if (sitems[i].qcheck == "Date") {
        //    maskStr = 'datatype="1" maskid="2"';
        //}
        if (i == 1) {
            s += '<TD formula="=datarow(&apos;ds1\\Table&apos;)" ' + maskStr + '/>';
        }
        else {
            s += '<TD ' + maskStr + ' />';
        }
    }
    s += '<TD topBorder="0"/>'
			+ '</TR>'
			+ '<TR height="15" sequence="3">';
    for (var i = 1; i < len; i++) {
        s += '<TD leftBorder="0"/>';
    }
    s += '<TD leftBorder="0" topBorder="0"/>'
			+ '</TR>'
		+ '</Table>'
		+ '<PrintPage>'
			+ '<Paper>'
				+ '<Margin left="19" top="25" right="19" bottom="25"/>'
			+ '</Paper>'
			+ '<Page>'
				+ '<PageCode>'
					+ '<Font faceName="宋体" charSet="134" height="-14" weight="400"/>'
				+ '</PageCode>'
			+ '</Page>'
		+ '</PrintPage>';
    //分类汇总
    if ($('input[name=radGroup][checked]').val() == "y") {
        s += '<Summaries>';
        //if ($('#selectOrder').val() != '') {
        //    s += '	<Summary datasourceID="ds1" datasourceXMLNode="" isEnabled="true" isSumAtBottomRight="true" sort="2" userDefinedSort="' + $('#selectOrder').val() + ' ' + $('input[name=radOrder][checked]').val() + '" isUniteRows="false" isPrintGridLine="false">'
            //alert('		<name sort="' + $('#selectOrder').val() + ' ' + $('input[name=radOrder][checked]').val() + '">Table</name>');
        //}
        //else {
            s += '	<Summary datasourceID="ds1" datasourceXMLNode="" isEnabled="true" isSumAtBottomRight="true" sort="3" isUniteRows="false" isPrintGridLine="false">'
        //}
        s += '		<Groups>';
        //if (len * dataCount < 200000) {
        for (var i = 1; i < $('input[name=radGroupNum][checked]').val(); i++) {
            //var i = 1;
            s += '<Group id="' + sitems[i].name + '" text="" align="0" isMergeBorder="true" bgColor="#FFFFFF">';
            s += '<Font faceName="宋体" charSet="134" height="-12" weight="400"/>';
            s += '<SubTotals>';
            for (var j = $('input[name=radGroupNum][checked]').val(); j < len; j++) {
                s += '<SubTotal id="' + sitems[j].name + '" decimal="0">';
                if (sitems[j].qcheck == 'Decimal' || sitems[j].qcheck == 'Int') {
                    s += '数值合计 @sum';
                }
                else {
                    s += '数量合计 @rows';
                }
                s += '</SubTotal>';
            }
            s += '</SubTotals></Group>';
        }
        //}
        //else {

        //    var i = 1;
        //    s += '<Group id="' + sitems[i].name + '" text="" align="0" isMergeBorder="true" bgColor="#FFFFFF">';
        //    s += '<Font faceName="宋体" charSet="134" height="-12" weight="400"/>';
        //    s += '<SubTotals></SubTotals></Group>';
       // }
        s += '		</Groups>'
		+ '	</Summary>'
		+ '</Summaries>';
    }
    s += '</WorkSheet>'
	//+ '	<Masks>'
	//+ '	<mask id="1" datatype="4">FormatDate(data,&apos;YYYY-MM-DD HH:mm&apos;)</mask>'
	//+ '	<mask id="2" datatype="4">FormatDate(data,&apos;YYYY-MM-DD&apos;)</mask>'
	//+ '	</Masks>'
	+ '	<DataSources Version="255" isAutoCalculateWhenOpen="false" isSaveCalculateResult="false">'
	+ '	<DataSource type="0"><!-- Desc: Supcan Report Component DataSource Specification -->'
	+ '<Data>'
	+ '<ID>ds1</ID>'
	+ '<Version>2</Version>'
	+ '<Type>0</Type>'
	+ '<TypeMeaning>XML</TypeMeaning>'
	+ '<Source></Source>'
	+ '<XML_RecordAble_Nodes>'
	+ '	<Node>';
	//排序
    //if ($('#selectOrder').val() != '') {
    //    s += '		<name sort="' + $('#selectOrder').val() + ' ' + $('input[name=radOrder][checked]').val() + '">Table</name>';
        //alert('		<name sort="' + $('#selectOrder').val() + ' ' + $('input[name=radOrder][checked]').val() + '">Table</name>');
    //}
    //else {
        s += '		<name>Table</name>';
    //}
    s += '	</Node><Node>'
    s += '		<name>CountTable</name>';
    s += '	</Node>'
	+ '</XML_RecordAble_Nodes>'
	+ '	<Columns>';
	//数据源
    for (var i = 1; i < len; i++) {
        s += "<Column>";
        s += "<name>Table\\" + sitems[i].name + "</name>";
        s += "<text>" + sitems[i].display + "</text>";
        s += "<type>" + sitems[i].qcheck + "</type>";
        //s += "<type>string</type>";
        s += "<visible>true</visible>";
        s += "<sequence>" + i + 1 + "</sequence>";
        s += "</Column>";
    }
    s += "<Column>";
    s += "<name>CountTable\\ALLCOUNT</name>";
    s += "<text>数据总数</text>";
    s += "<type>String</type>";
    s += "<visible>true</visible>";
    s += "<sequence>" + i + "</sequence>";
    s += "</Column>";
    s += "<Column>";
    s += "<name>CountTable\\CASECOUNT</name>";
    s += "<text>涉及企业总数</text>";
    s += "<type>String</type>";
    s += "<visible>true</visible>";
    s += "<sequence>" + i + 1 + "</sequence>";
    s += "</Column>";
    s += '	</Columns>'
	+ '</Data>'
	+ '	</DataSource>'
	+ '</DataSources>'
    + '</Report>';

    return s;
}

//字段多选框点击事件
function SelectColumns(obj) {
    var objSelect = document.getElementById("selectColumns");
    var objSelectOrder = document.getElementById("selectOrder");
    if (obj.checked) {
        var op = new Option(obj.display, obj.name);
        $(op).attr('qcheck', obj.qcheck);
        var op2 = new Option(obj.display, obj.name);
        $(op2).attr('qcheck', obj.qcheck);
        objSelect.options.add(op);
        objSelectOrder.options.add(op2);
    }
    else {
        for (var i = 0; i < objSelect.options.length; i++) {
            if (objSelect.options[i].value == obj.name) {
                objSelect.options.remove(i);
                break;
            }
        }

        for (var i = 0; i < objSelectOrder.options.length; i++) {
            if (objSelectOrder.options[i].value == obj.name) {
                objSelectOrder.options.remove(i);
                break;
            }
        }
    }
}

//向上移
$('#btnUp').click(function() {
    var objSelect = document.getElementById("selectColumns");
    if (objSelect.options.length == 0) return;
    if (objSelect.selectedIndex == -1) return;
    var index = objSelect.selectedIndex;
    if (index == 0) return;
    var op = new Option(objSelect.options[index].text, objSelect.options[index].value);
    $(op).attr('qcheck', objSelect.options[index].qcheck);
    var op2 = new Option(objSelect.options[index - 1].text, objSelect.options[index - 1].value);
    $(op2).attr('qcheck', objSelect.options[index - 1].qcheck);
    objSelect.options[index] = op2;
    objSelect.options[index - 1] = op;
    objSelect.selectedIndex = index - 1;
});
//向下移
$('#btnDown').click(function() {
    var objSelect = document.getElementById("selectColumns");
    if (objSelect.options.length == 0) return;
    if (objSelect.selectedIndex == -1) return;
    var index = objSelect.selectedIndex;
    if (index == objSelect.options.length - 1) return;
    var op = new Option(objSelect.options[index].text, objSelect.options[index].value);
    $(op).attr('qcheck', objSelect.options[index].qcheck);
    var op2 = new Option(objSelect.options[index + 1].text, objSelect.options[index + 1].value);
    $(op2).attr('qcheck', objSelect.options[index + 1].qcheck);
    objSelect.options[index] = op2;
    objSelect.options[index + 1] = op;
    objSelect.selectedIndex = index + 1;
});

//显示字段
function ShowTables() {

    var search = "";
    for (var c = 0; c < columnDatas.length; c++) {
        search += ""
                + "     <fieldset class='fieldset'>"
                + "         <legend><span >" + columnDatas[c].title + " <a onclick='checkAll(this)' href='##'>全选</a> <a onclick='checkReverse(this)' href='##'>反选</a></span></legend>"
                + "         <div  style='margin: 10px'>"
                + "             <div style='width: 100%'> ";
        //每个字段的代码
        var searchNode = "              <div class='d_s'> "
                + "                     <table class='t_s' style='width: 100px;'> "
                + "                         <tr> "
                + "                             <td ><input type='checkbox' onclick='SelectColumns(this)' name='{name}' display='{display}' qcheck='{qcheck}' id='{name}CheckBox'  /><label for='{name}CheckBox'>{display}</label></td>"
                + "                         </tr>"
                + "                     </table>  "
                + "                 </div>";

        //循环取得要查询的字段的HTML代码
        var citems = columnDatas[c].citems;

        for (var s = 0; s < citems.length; s++) {
            search += searchNode.replace('{display}', citems[s].display).replace('{display}', citems[s].display).replace('{name}', citems[s].name).replace('{name}', citems[s].name).replace('{name}', citems[s].name).replace('{qcheck}', citems[s].qcheck);
        }
        search += "            </div>"
                + "         </div>"
                + "     </fieldset>";
    }
    return search;
}




function HighSearch() {
    if (highSearchPar > 10) {
        alert("不能超过十组查询！");
        return;
    }
    var search = ""
                + "     <fieldset class='fieldset'>"
                + "         <legend><span >第" + highSearchPar + "组</span></legend>"
                + "         <div style='margin: 10px'>"
                + "             <div style='width: 100%'> ";
    //每个字段的代码
    var searchNode = "              <div class='d_s'> "
                + "                     <table class='t_s' style='width: 330px;'> "
                + "                         <tr> "
                + "                             <td style='width: 100px;'>{display}</td>"
                + "                             <td > <select name='{name}Select" + highSearchPar + "' id='{name}Select" + highSearchPar + "' style='width: 80px;' accessKey='d'>{selectOption}</select></td>"
                + "                             <td > <input type='text' name='{name}Input" + highSearchPar + "' id='{name}Input" + highSearchPar + "' {check} accessKey='d'/></td>"
                + "                         </tr>"
                + "                     </table>  "
                + "                 </div>";
    var searchNodeForOracleDate = "       <div class='d_s'> "
                + "                     <table class='t_s' style='width: 330px;'> "
                + "                         <tr> "
                + "                             <td style='width: 100px;'>{display}</td>"
                + "                             <td style='width: 100px;display:none'>{display}(<a onclick='radOrBack(this)' radid='{name}radOr1" + highSearchPar + "' href='##'>返回</a>)</td>"
                + "                             <td style='width: 230px;'> "//border: solid 1px #A4BED4;
                + "                                 <input id='{name}radOr1" + highSearchPar + "' onclick='radOrClick(this,0)'  type='radio' name='{name}radLink" + highSearchPar + "' value='' /><label for='{name}radOr" + highSearchPar + "'>不限</label>"
                + "                                 <input id='{name}radOr2" + highSearchPar + "' onclick='radOrClick(this,1)'  type='radio' name='{name}radLink" + highSearchPar + "' value=\"','yyyy-mm-dd') and Add_months({name},-1)< to_date('\" /><label for='{name}radOr" + highSearchPar + "'>本月</label>"
                + "                                 <input id='{name}radOr3" + highSearchPar + "' onclick='radOrClick(this,2)'  type='radio' name='{name}radLink" + highSearchPar + "' value=\"','yyyy-mm-dd') and Add_months({name},+1)>= to_date('\" /><label for='{name}radOr" + highSearchPar + "'>上月</label>"
                + "                                 <input id='{name}radOr4" + highSearchPar + "' onclick='radOrClick(this,9)'  type='radio' name='{name}radLink" + highSearchPar + "' value='' /><label for='{name}radOr" + highSearchPar + "'>自定义</label>"
                + "                             </td>"
                + "                             <td style='display:none' > <select name='{name}Select" + highSearchPar + "' id='{name}Select" + highSearchPar + "' style='width: 80px;' accessKey='d'>{selectOption}</select></td>"
                + "                             <td style='display:none' > <input type='text' name='{name}Input" + highSearchPar + "' id='{name}Input" + highSearchPar + "' {check} accessKey='d'/></td>"
                + "                         </tr>"
                + "                     </table>  "
                + "                 </div>";
    var searchNodeForSqlServerDate = "       <div class='d_s'> "
                + "                     <table class='t_s' style='width: 330px;'> "
                + "                         <tr> "
                + "                             <td style='width: 100px;'>{display}</td>"
                + "                             <td style='width: 100px;display:none'>{display}(<a onclick='radOrBack(this)' radid='{name}radOr1" + highSearchPar + "' href='##'>返回</a>)</td>"
                + "                             <td style='width: 230px;'> "//border: solid 1px #A4BED4;
                + "                                 <input id='{name}radOr1" + highSearchPar + "' onclick='radOrClick(this,0)'  type='radio' name='{name}radLink" + highSearchPar + "' value='' /><label for='{name}radOr" + highSearchPar + "'>不限</label>"
                + "                                 <input id='{name}radOr2" + highSearchPar + "' onclick='radOrClick(this,1)'  type='radio' name='{name}radLink" + highSearchPar + "' value=\"' and DATEADD(m,-1,{name}) < '\" /><label for='{name}radOr" + highSearchPar + "'>本月</label>"
                + "                                 <input id='{name}radOr3" + highSearchPar + "' onclick='radOrClick(this,2)'  type='radio' name='{name}radLink" + highSearchPar + "' value=\"' and DATEADD(m,1,{name}) >= '\" /><label for='{name}radOr" + highSearchPar + "'>上月</label>"
                + "                                 <input id='{name}radOr4" + highSearchPar + "' onclick='radOrClick(this,9)'  type='radio' name='{name}radLink" + highSearchPar + "' value='' /><label for='{name}radOr" + highSearchPar + "'>自定义</label>"
                + "                             </td>"
                + "                             <td style='display:none' > <select name='{name}Select" + highSearchPar + "' id='{name}Select" + highSearchPar + "' style='width: 80px;' accessKey='d'>{selectOption}</select></td>"
                + "                             <td style='display:none' > <input type='text' name='{name}Input" + highSearchPar + "' id='{name}Input" + highSearchPar + "' {check} accessKey='d'/></td>"
                + "                         </tr>"
                + "                     </table>  "
                + "                 </div>";
    //两种不同情况的条件下拉框
    var qmodeStr = "<option value='like'>包含</option><option value='not like'>不包含</option><option value='='>等于</option><option value='<>'>不等于</option>";
    var qmodeInt = "<option value='='>等于</option><option value='<>'>不等于</option><option value='>'>大于</option><option value='>='>大于等于</option><option value='<'>小于</option><option value='<='>小于等于</option>";
    var qmodeOracleDate = "<option value='='>等于</option><option value='>='>大于等于</option><option value='-1<'>小于等于</option><option value='-1>='>大于</option><option value='<'>小于</option>";
    var qmodeSqlServerDate = "<option value='='>等于</option><option value='>='>大于等于</option><option value='-1<'>小于等于</option><option value='-1>='>大于</option><option value='<'>小于</option>";
    //输入验证
    var checkStr = "";
    //下拉框值
    var selectOptionStr = "";
    //循环取得要查询的字段的HTML代码
    for (var s = 1; s < sitems.length; s++) {
        //给不同的数据类做不同的查询条件选择和输入验证
        if (sitems[s].qcheck == 'Datetime' || sitems[s].qcheck == 'Date') {
            checkStr = "type='text' data-val='false' data-date-format='yyyy-mm-dd' class='searchString date-picker'";
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
                + "     </fieldset>";
    searchs[highSearchPar - 1] = sitems;
    highSearchPar++;
    //$.parser.parse();
    //setTimeout("$.parser.parse()", 1000);
    return search;
}


function radOrClick(obj, type) {
    var myDate = new Date();
    if (type == 0) {//不限
        $('#' + obj.name.replace('radLink', 'Input')).val('');
    }
    else if (type == 1) {//本月
        var thisMonth = myDate.getFullYear() + '-' + (myDate.getMonth() + 1) + '-' + '1';
        $('#' + obj.name.replace('radLink', 'Select')).val('>=');
        $('#' + obj.name.replace('radLink', 'Input')).val(thisMonth + $(obj).attr('value') + thisMonth);
        //alert($(obj).attr('value'));
    }
    else if (type == 2) {//上月
        var thisMonth = myDate.getFullYear() + '-' + (myDate.getMonth() + 1) + '-' + '1';
        $('#' + obj.name.replace('radLink', 'Select')).val('<');
        $('#' + obj.name.replace('radLink', 'Input')).val(thisMonth + $(obj).attr('value') + thisMonth);
    }
    else if (type == 9) {//自定义
        $(obj).parent().hide().next().show().next().show();
        $(obj).parent().prev().show().prev().hide();
        $('#' + obj.name.replace('radLink', 'Input')).val('');
    }
}

function radOrBack(obj) {
    $(obj).parent().hide().prev().show();
    $(obj).parent().next().show().next().hide().next().hide();
    $("#" + $(obj).attr('radid')).click();
}


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
}

//取查询条件sql
function GetWhereSql() {
    if (dbType == "oracle") {
        return GetWhereSqlForOracle();
    }
    else {
        return GetWhereSqlForMsSqlServer();
    }
}
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
        
        for (var s = 1; s < searchs[i - 1].length; s++) {
            var objSelectTmp = $('select[name=' + searchs[i - 1][s].name + 'Select' + i + ']', highSearchDiv);
            var objInputTmp = $('input[name=' + searchs[i - 1][s].name + 'Input' + i + ']', highSearchDiv);
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
}

//MsSqlServer取查询条件sql
function GetWhereSqlForMsSqlServer() {

    var whereSqlStr = " and ";
    var whereSqlGroup = " 1=1 ";
    var inputStr = "";
    var whereSqlNode = " and {name} {select} '{input}' ";
    var whereSqlNodeForDate = " and DATEDIFF(dd,{name},'{input}') = 0 ";

    //循环所有字段，有填东西的字段，生成查询语句
    for (var i = 1; i < highSearchPar; i++) {
        if (i != 1) {
            //alert($('input[name=radLink' + i + '][checked]').val());
            var objTmp = $('input[name=radLink' + i + '][checked]');
            whereSqlStr += "(" + whereSqlGroup + ")" + objTmp.val() + " ";
            whereSqlGroup = " 1=1 ";
            //cookieParam += "," + objTmp.attr("id") + "," + objTmp.val();

        }

        for (var s = 1; s < searchs[i - 1].length; s++) {
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
}

//增加一组查询条件
function AddSelectGroup() {
    if (highSearchPar > 10) {
        alert("不能超过十组查询！");
        return;
    }
    var radStrTmp = ""
				            + "     "
				            + "     <table class='tBtn' ><tr><td style='width:100%;height:30px' >"
				            + "     <div  class='' title='设置上下两组查询的关系'>"
                            + "     <input id='radAnd" + highSearchPar + "'  type='radio' checked='checked' name='radLink" + highSearchPar + "' value='and' /><label for='radAnd" + highSearchPar + "'>并且</label>"
    //+ "     </td><td style='width:30px'>"
                            + "     <input id='radOr" + highSearchPar + "'  type='radio' name='radLink" + highSearchPar + "' value='or' /><label for='radOr" + highSearchPar + "'>或者</label>"
                            + "     (\"并且\"会优先合并计算)</div></td></tr></table>"
                            + "     ";
    $('form[name=formSerach]').append(radStrTmp);
    $('form[name=formSerach]').append(HighSearch());
}

//取查询字段的sql
function GetColumnSql() {
    var objdata = {};
    var columnSql = "rownum";
    //循环取得要查询的字段的HTML代码
    for (var s = 1; s < sitems.length; s++) {
        columnSql += ',' + sitems[s].name;
    }
    return columnSql.replace('rownum,', '');
}


$('#divStep1').show();

//加载所有字段
$('#divForColumns').append(ShowTables());

//全选事件
function checkAll(obj) {
    var checked = $($('input[type=checkbox]', $(obj).parent().parent().parent())[0]).attr('checked');

    $('input[type=checkbox]', $(obj).parent().parent().parent()).each(function() {
        if ($(this).attr('checked') == checked) {
            $(this).attr('checked', (!checked));
            SelectColumns(this);
        }
    });
}

//反选事件
function checkReverse(obj) {
    $('input[type=checkbox]', $(obj).parent().parent().parent()).each(function() {
        if ($(this).attr('checked'))
            $(this).attr('checked', false)
        else
            $(this).attr('checked', true)
        SelectColumns(this);
    });
}

//下一步，设置查询条件
$('#btnNext2', highSearchDiv).click
    (
        function() {
            var tmp = "[{display: '标题1', name : 'code', qcheck: 'String'}";
            var objOptions = document.getElementById("selectColumns").options;
            //呈现顶端遮罩
            //if (top.showMask) top.showMask();
            if (document.getElementById("selectColumns").options.length == 0) {
                alert("请选择要查询的数据！");
                //移除顶端遮罩
                //if (top.hideMask) top.hideMask();
                return;
            }
            if ($('input[name=radGroup][checked]').val() == "y") {
                if (objOptions.length < $('input[name=radGroupNum][checked]').val()) {
                    alert("要汇总的列数量必须少于总列数！");
                    //移除顶端遮罩
                    //if (top.hideMask) top.hideMask();
                    return;
                }
            }


            for (var i = 0; i < objOptions.length; i++) {
                tmp += ",{display: '" + objOptions[i].text + "', name : '" + objOptions[i].value + "', qcheck: '" + objOptions[i].qcheck + "'}";
            }
            //$(objOptions).each(function() {
            //    tmp += ",{display: '" + $(this).attr("text") + "', name : '" + $(this).attr("value") + "', qcheck: '" + $(this).attr("qcheck") + "'}";
            //});
            tmp += "]";
            sitems = eval(tmp);
            //默认加载第一组查询
            if (highSearchPar == 1)
                $('form[name=formSerach]').append(HighSearch());
            $('#divStep1').hide();
            $('#divStep2').show();
            //移除顶端遮罩
            //if (top.hideMask) top.hideMask();

        }

    );

//回车则开始查询
$('input[type=text],select', highSearchDiv).keydown(function(e) {
    if (e.keyCode == 13) {
        $('#btnNext3').click();
    }
});


//预览报表
$('#btnNext3').click
    (function() {
        //验证输入
        if(!Validator.Validate(document.getElementById('formSerach'),null,false))
        {
            return false;
        }
        var orderStr = "";
        if ($('#selectOrder').val() != '') {
            orderStr = ' order by ' + $('#selectOrder').val() + ' ' + $('input[name=radOrder][checked]').val();
        }
        var params = [
				 { name: 'columns', value: GetColumnSql() }
				, { name: 'where', value: GetWhereSql() }
				, { name: 'where2', value: ' top 100 '}//预览只显示前100条
				, { name: 'orderSql', value: orderStr}
				, { name: 'tableName', value: tableName}
				, { name: 'keyColumn', value: keyColumn}
				, { name: 'Action', value: action}
			];
        $('#divStep3').show();
        $('#divStep2').hide();
        
        ShowReport(params);

    }
    );
    
//显示报表
function ShowReport(params) {
    $.ajax({
        type: 'POST',
        url: '../Areas/Share/Report/ReportData' + "?" + new Date().getTime(),
        data: params,
        dataType: 'json',
        success: function(data, status, XHR) {
            if (sitems.length * data.dataCount > 200000) {
                if (!confirm("本次报表的数据量达到了" + Math.floor(sitems.length * data.dataCount / 10000) + "万，由于数据量过大，需要等待较长时间，是否继续显示？")) {
                    //移除顶端遮罩
                    //if (top.hideMask) top.hideMask();
                    return;
                }
            }
            AF.func("Build", GetXmlTemplate(data.dataCount));
            AF.func("SetSource", "ds1\r\n../../" + data.path + "?" + new Date().getTime());
            var y = "2", x = "2";
            if (data.dataCount < 10)
                y = "0";
            if (sitems.length < 9)
                x = "0";
            AF.func("SeparateView", y + "\r\n" + x);
            AF.func('addUnEditAbleOnly', 'bgColor=T');
            //AF.func("Swkrntpomzqa", "1,2,4, 8,16,32, 128, 64");

            AF.func('Calc', '');
            //移除顶端遮罩
            //if (top.hideMask) top.hideMask();
        },
        error: function(XHR, status, errorThrow) {
            alert('信息', XHR.responseText, '500');
        }
    });
}

//保存为模板
function SaveMould(params) {
    $.ajax({
        type: 'POST',
        url: '/Cases/CaseRepotrMould/SaveMould',
        data: params,
        dataType: 'json',
        success: function(data, status, XHR) {
            value: $("#Id").val(data);
            alert('模板保存成功。');
            //移除顶端遮罩
            if (top.hideMask) top.hideMask();
        },
        error: function(XHR, status, errorThrow) {
            alert('信息', XHR.responseText, '500');
        }
    });
}

//增加一组查询条件
$('#btnIncrease').click(
        function() { AddSelectGroup(); }
	);

//上一步
$('#btnReturn3').click(
	    function() {
	        $('#divStep1').show();
	        $('#divStep2').hide();
	    }
				);
//上一步
$('#btnReturn4').click(
        function() {
            $('#divStep2').show();
            $('#divStep3').hide();
        }
    );

//显示所有数据
$('#btnGetAllData').click(


            function() {

                //呈现顶端遮罩
                //if (top.showMask) top.showMask();
                var orderStr = "";
                if ($('#selectOrder').val() != '') {
                    orderStr = ' order by ' + $('#selectOrder').val() + ' ' + $('input[name=radOrder][checked]').val();
                }
                var params = [
				 { name: 'columns', value: GetColumnSql() }
				, { name: 'where', value: GetWhereSql() }
				, { name: 'where2', value: '' }
				, { name: 'orderSql', value: orderStr }
				, { name: 'Action', value: action}
				, { name: 'keyColumn', value: keyColumn}
				, { name: 'tableName', value: tableName}
			];
                ShowReport(params);

            }
        );

//保存为报表模板
$('#btnMouldSave').click(
            function() {
                //呈现顶端遮罩
                //if (top.showMask) top.showMask();

                // 如果选中的案件为零
                if ($("#mouldName").val() == "") {
                    value: $("#Id").val(data);
                    alert('请填写模板名。');
                    //移除顶端遮罩
                    if (top.hideMask) top.hideMask();
                    return false;
                }

                var params = [
				 { name: 'Name', value: $("#mouldName").val() }
				, { name: 'Id', value: $("#Id").val() }
				, { name: 'Content', value: GetSaveData() }
			];
                SaveMould(params);
                //移除顶端遮罩
                //if (top.hideMask) top.hideMask();

            }
        );

$('#btnNext4').click(
            function() {
                //呈现顶端遮罩
                //if (top.showMask) top.showMask();

                var dateTmp = new Date();
                var tagFolder = "c:\\数据导出" + dateTmp.getTime() + ".xls";
                AF.func("CallFunc", "105\r\nType=xls;filename=" + tagFolder);
                alert('已经将文件导出到C盘根目录，地址如下：' + tagFolder);
                //移除顶端遮罩
                //if (top.hideMask) top.hideMask();
            });


/*以下是当前设置和还原设置的接口*/

var sitemsBh = {};  
var searchsBh = new Array();
var SaveDataRadio = "";
var SaveDataText = "";
var ht = new Array();

//还原
function BackHistory(htStr) {
    //alert($.cookie('HistoryData'));
    //ht = eval($.cookie('HistoryData'));
    ht = eval(htStr);
    sitemsBh = ht[0];
    searchsBh = ht[1];
    SaveDataRadio = ht[2];
    SaveDataText = ht[3];
    //alert(SaveDataText);
    //还原已经勾选的字段
    for (var i = 1; i < sitemsBh.length; i++) {
        $('#' + sitemsBh[i].name + 'CheckBox').attr('checked', true);
        SelectColumns(document.getElementById(sitemsBh[i].name + 'CheckBox'));
    }

    //还原查询页
    for (var i = 0; i < searchsBh.length; i++) {
        sitems = searchsBh[i];
        //默认加载第一组查询
        if (i == 0)
            $('form[name=formSerach]').append(HighSearch());
        else
            AddSelectGroup();
    }
    sitems = sitemsBh;
    var arrTmp = SaveDataText.split("@2@");
    for (var i = 0; i < arrTmp.length - 1; i = i + 2) {
        $("#" + arrTmp[i]).val(arrTmp[i + 1]);
    }
    arrTmp = SaveDataRadio.split("@2@");
    for (var i = 0; i < arrTmp.length; i = i + 2) {
        if (arrTmp[i + 1] == 'true') {
            $("#" + arrTmp[i]).click();
        }
    }


}

//取值用于还原
function GetSaveData() {
    sitemsBh = sitems;
    searchsBh = searchs;
    $('input[type=radio]').each(function() {
    SaveDataRadio += $(this).attr('id') + '@2@' + $(this).attr('checked') + '@2@';
    });
    $('input[type=text][value!=""][id!="mouldName"]').each(function() {
    SaveDataText += $(this).attr('id') + '@2@' + $(this).val() + '@2@';
    SaveDataText += $($('select', $(this).parent().parent())[0]).attr('id') + '@2@' + $($('select', $(this).parent().parent())[0]).val() + '@2@';
    });
    SaveDataText += $('#selectOrder').attr('id') + '@2@' + $('#selectOrder').val() + '@2@';
    ht[0] = sitemsBh;
    ht[1] = searchsBh;
    ht[2] = SaveDataRadio;
    ht[3] = SaveDataText;
    $.cookie('HistoryData', $.serialize(ht));
    return $.serialize(ht);
}


/*
//获取Id
var id = $.query.get("Id");
//获取模板
if (id != null && id != "" && id != "0" && id != '-1') {
    $.ajax({
        cache: false,
        type: 'GET',
        url: '/Cases/CaseRepotrMould/Finds',
        data: { Id: id },
        dataType: 'json',
        success: function(data, status, XHR) {
            //显示模板名
            $("#mouldName").val(data[0].Name);
            //加载id
            $("#Id").val(data[0].Id);
            //模板加载
            BackHistory(data[0].Content);
        },
        error: function(XHR, status, errorThrow) {
            alert('信息', XHR.responseText, '500');
        }
    });
}
*/