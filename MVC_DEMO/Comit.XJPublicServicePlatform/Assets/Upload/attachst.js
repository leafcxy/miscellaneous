// JavaScript Document
var ntkoocx = null; //控件对象
var NTKO_errNoOcx = "NTKO附件管理控件装载失败.";
var NTKO_AttachInfo = new Array(); //保存服务器上的控件列表信息
var IsDocFileSaved = false; //是否已经保存,成功保存之后设置。
var k; //定义文件列表

function NTKO_InitAtaches()
{
	//获得控件对象
	ntkoocx = document.all("NTKOATTACH_OCX");
	if(!ntkoocx)
	{
		alert(NTKO_errNoOcx);
		return;
	}
	IsDocFileSaved = false; //是否已经保存,成功保存之后设置。
	//根据页面编码设置控件属性
	var useUTF8 = (document.charset == "utf-8");
	ntkoocx.IsUseUTF8Data = useUTF8;
	//alert(NTKO_AttachInfo.length);
	for(var i=0;i<NTKO_AttachInfo.length;i++)
	{
        ntkoocx.AddServerFile(NTKO_AttachInfo[i][0],NTKO_AttachInfo[i][1],NTKO_AttachInfo[i][2],NTKO_AttachInfo[i][3]);
	}
}
//如果原先的表单定义了OnSubmit事件，保存文档时首先会调用原先的事件。
function NTKO_doFormOnSubmit()
{
	var form = document.forms[0];
  	if (form.onsubmit)
	{
    	var retVal = form.onsubmit();
     	if (typeof retVal == "boolean" && retVal == false)
       	return false;
	}
	return true;
}
function NTKO_ConfirmSave()
{
	if(IsDocFileSaved)return;
	if(!ntkoocx)return;
	if(ntkoocx.IsPermitAddDelFiles && ntkoocx.IsNeedSaveToServer)
	{
		if(window.confirm("有一些附件文件被修改或者增加,您需要保存回服务器吗?"))
		{
			NTKO_SaveDocWithAttaches();
			return true;
		}
		else
		{
			//用户选择了取消
			return false;
		}
	}
	//不需要保存
	return true;
}
function NTKO_SaveDocWithAttaches() {
    if (!NTKO_doFormOnSubmit()) return;
    if (!ntkoocx) {
        alert(NTKO_errNoOcx);
    }
    if (document.all("ShipNameC").value == "") {
        if (confirm("文件名为空确认需要保存吗?")) {
            savedoc();
        }
    }
    else {
        savedoc();
    }
}
function savedoc() {
    //document.all("acount").value = ntkoocx.FilesCount; //获取附后数量
    ntkoocx.BeginSaveToURL(
			"UploadFile",  //此处为upload.aspx
			"EDITFILE", //文件输入域名称,可任选,不与其他<input type=file name=..>的name部分重复即可
			"", //可选的其他自定义数据－值对，以&分隔。如：myname=tanger&hisname=tom,一般为空
			"myForm" //控件的智能提交功能可以允许同时提交选定的表单的所有数据.此处可使用id或者序号
		);
}
//当前表单不可编辑,当整个表单只读时调用
function FormDisabled(bool) {
    var formid = document.forms.item(0)
    var elelength = formid.length;
    for (var i = 0; i < elelength; i++)
    { formid.elements[i].disabled = bool; }
}