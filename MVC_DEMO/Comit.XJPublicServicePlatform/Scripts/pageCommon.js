//新增修改操作成功反馈
function success(data) {
    if (data.SuccessInfo.indexOf("失败") == -1 && data.SuccessInfo.indexOf("不提示") == -1) {
        //新增操作成功后，给删除按钮赋主键值
        eval("$('#" + data.PkName + "').val('" + data.PkValue + "');");
        //页面控制
        pageControl("Update");
        
        //操作提醒
        if (data.SuccessInfo != null)
        {
            alertBox(data.SuccessInfo);
        }
        
        if (data.Url != null) {
            window.location.href = data.Url;
        }
    }
    else if (data.SuccessInfo.indexOf("不提示") != -1)
    {

    }
    else if(data.SuccessInfo.indexOf("失败") != -1)
    {
        alertBox(data.SuccessInfo);
    }
    else
    {
        alertBox("操作失败，请与管理员联系！");
    }
}

//页面失败反馈
function failureInfo(request) {
    alertBox("操作失败，请与管理员联系！");
}
//按钮提交前事件
function beginAct(request) {
    if (top != null) top.LoadingUtils.loading();
}
//删除按钮提交前事件
function beginDelAct(request) {
    
}
//按钮响应结束后事件
function completeAct(request) {
    if (top != null) top.LoadingUtils.unloading();
}
//页面按钮控制方法
function pageControl(operateType, addRight, delRight) {
    if (addRight=="False")
    {//新增修改权限
        $("#btnUpdate").css("display", "none");
        $("#btnAdd").css("display", "none");
    }
    if (delRight == "False") {
        //删除权限
        $("#btnDelete").css("display", "none");
    }
    if (operateType == "") {
        if ($("#btnAdd").length > 0) {
            $("#btnAdd").css("display", "inline");
        }
        if ($("#btnUpdate").length > 0) {
            $("#btnUpdate").css("display", "none");
        }
        if ($("#btnDelete").length > 0) {
            $("#btnDelete").css("display", "none");
        }
    }
    else if (operateType == "Update" || operateType == "Add") {
        if ($("#btnAdd").length > 0) {
            $("#btnAdd").css("display", "none");
        }
        if ($("#btnUpdate").length > 0) {
            $("#btnUpdate").css("display", "inline");
        }
        if ($("#btnDelete").length > 0) {
            $("#btnDelete").css("display", "inline");
        }
    }
    else {
        if ($("#btnAdd").length > 0) {
            $("#btnAdd").css("display", "none");
        }
        if ($("#btnUpdate").length > 0) {
            $("#btnUpdate").css("display", "none");
        }
        if ($("#btnDelete").length > 0) {
            $("#btnDelete").css("display", "none");
        }
    }
}

//日期控件，数值控件改变值，同时更改其隐藏控件
function changeRelateObject(id,obj,type)
{
    if (obj.value == "")
    {
        if (type == "number")
        {
            $("#" + id).val(-2147483648);
        }
        else if (type == "date") {
            $("#" + id).val("1900-01-01");
        }
        else if (type == "string")
        {
            alert(obj.value);
            $("#" + id).val(obj.value);
        }
        else {
            $("#" + id).val(obj.value);
        }
    }
    else
    {
        $("#" + id).val(obj.value);
    }    
}
//日期控件，数值控件改变值验证不通过时，同时非隐藏控件获得焦点
function changeFocus(id)
{
    $('#' + id).focus();
}

//删除按钮的comfirm事件
function delConfirm()
{    
    
    bootbox.dialog({
        title: "删除提示",
        message: "<span class='bigger-110'>你确定要删除此数据吗？</span>",
        buttons:
        {            
            "danger":
            {
                "label": "删除",
                "className": "btn-sm btn-danger",
                "callback": function () {
                    delMethod();
                }
            },
            "button":
            {
                "label": "取消",
                "className": "btn-sm",
                "callback": function () {
                }
            }
        }
    });
}

//信息提示框
//type等于1，为页面验证提示
function alertBox(message,method,type) {
    if (message != null && message!="")
    {
        var btnClass = "btn-sm btn-primary";
        var titleInfo = "温馨提示";
        if (type == "1") {
            btnClass = "btn-sm btn-danger";
            titleInfo = "信息验证提醒";
        }
        bootbox.dialog({
            title: titleInfo,
            message: "<span class='bigger-110'>" + message + "</span>",
            buttons:
            {
                "button":
                {
                    "label": "确定",
                    "className": btnClass,
                    "callback": function () {
                        if (method != null || method != "") {
                            eval(method);
                        }
                    }
                }
            }
        });
    }
    
}

//确认提示框
function comfirmBox(message, methodOK, methodNo) {

    bootbox.dialog({
        title: "确认提示",
        message: "<span class='bigger-110'>" + message + "</span>",
        buttons:
        {
            "Yes":
            {
                "label": "确定",
                "className": "btn-sm btn-primary",
                "callback": function () {
                    if (methodOK != "" || methodOK != null)
                    {
                        eval(methodOK);
                    }
                    
                }
            },
            "No":
            {
                "label": "取消",
                "className": "btn-sm btn-primary",
                "callback": function () {
                    if (methodNo != "" || methodNo != null) {
                        eval(methodNo);
                    }
                }
            }
        }
    });
}

//页面删除方法
function delMethod()
{
    var delUrl = $("form")[0].action.replace("Operate", "Delete");
    $.ajax({
        type: "POST",
        url: delUrl,
        data: { id: $("#Id").val() },
        dataType: "json",
        beforeSend: function (data) {
            if (top != null) top.LoadingUtils.loading();
        },
        success: function (data) {
            alertBox(data.SuccessInfo);
            if (data.SuccessInfo == "删除成功！")
            {
                if (data.Url != null)
                {
                    window.location.href = data.Url;
                }
                else
                {
                    window.history.go(-1);
                    //window.location.href=window.history.back();
                }
                
                
                
            }

        },
        error: function (data) {
            alertBox("操作失败，请与管理员联系！");
        },
        complete: function (data) {
            if (top != null) top.LoadingUtils.unloading();
        }

    });
}

//验证信息提示
function validationInfo(notTip)
{
    var id = $("input:focus").attr("id");
    if ($('#validationMessage').html().indexOf("<div class=\"validation-summary-valid\" data-valmsg-summary=\"true\"><ul><li style=\"display: none;\"></li>\n</ul></div>") == -1 && $('#validationMessage').text().Trim()!="")
    {//如果验证信息里有内容，则提醒       
        var t = $('#validationMessage').text().Trim();
        var info = $('#validationMessage').html()
        //提示信息并让控件重新获得焦点
        alertBox(info, "setTimeout('changeFocus(\"" + id + "\")', 100);", "0");
        $('#validationMessage').html("\n                                    <div class=\"validation-summary-valid\" data-valmsg-summary=\"true\"><ul><li style=\"display: none;\"></li>\n</ul></div>\n                                ");
    }
}
//去除空格
String.prototype.Trim = function () {
    return this.replace(/\s+/g, "");
}
String.prototype.LRTrim = function () {
    return this.replace(/(^\s*|\s*$)/g, "");
}
String.prototype.LTrim = function () {
    return this.replace(/(^\s*)/g, "");
}
String.prototype.RTrim = function () {
    return this.replace(/(\s*$)/g, "");
}


//仅仅弹出提示内容		
function AlertOK(tip) {
    bootbox.dialog({
        message: "<span class='bigger-110'>" + tip + "</span>",
        buttons:
            {
                "success":
                    {
                        "label": "<i class='icon-ok'></i> 确定",
                        "className": "btn-sm btn-success"
                    }
            }
    });
}

function AlertFail(tip) {
    bootbox.dialog({
        message: "<span class='bigger-110'>" + tip + "</span>",
        buttons:
            {
                "danger":
                    {
                        "label": "<i class='icon-exclamation-sign'></i> 确定",
                        "className": "btn-sm btn-danger"
                    }
            }
    });
}

//文本自定义分数只能键入数字 by ysh 2014-10-15
function IsNum(e, o) {
    var k = window.event ? e.keyCode : e.which;
    if (((k >= 48) && (k <= 57)) || k == 8 || k == 0 || k == 46) {
        if (o.value == ".") {
            alertBox("不能以小数点开头！");
            o.value = "";
            window.event.returnValue = false;
        }
    }
    else {
        if (window.event) {
            window.event.returnValue = false;
        }
        else {
            e.preventDefault(); //for firefox                 
        }
    }
}

//文本自定义分数不能超过设置的最大值 by ysh 2014-10-15
function limitInput(o) {
    var value = o.value;
    var min = 0;
    var max = 4294967295;
    if (o.value < min || o.value > max) {
        alertBox("不能超过最大值：" + max);
        o.value = '';
    }
}


//html转码
function HTMLEncode(html) {
    var temp = document.createElement("div");
    (temp.textContent != null) ? (temp.textContent = html) : (temp.innerText = html);
    var output = temp.innerHTML;
    temp = null;
    return output;
}

function HTMLDecode(text) {
    var temp = document.createElement("div");
    temp.innerHTML = text;
    var output = temp.innerText || temp.textContent;
    temp = null;
    return output;
}

//上传文件--这个函数名，参数不能修改
function sendFile(file, editor, welEditable, mode, filename) {
    //alert("   bnbb");
    var delUrl = $("form")[0].action.replace("Operate", "UploadFile");
    //debugger;
    data = new FormData();
    data.append("file", file);
    $.ajax({
        data: data,
        type: "POST",
        url: delUrl,
        cache: false,
        contentType: false,
        processData: false,
        success: function (data) {
            //alert(data.SuccessInfo);
            //$("#summernote").insertImage(welEditable, data.SuccessInfo);
            //debugger;
            if (!data.SuccessInfo) {
                alert(data);
            } else {
                var code = "";
                if (mode == "enclosure") {
                    //code = "<a href='" + data.SuccessInfo + "'>" + filename + "</a>&nbsp;";
                    var $node = $('<a>').attr('href', data.SuccessInfo).attr('data-filename', filename).text(filename);
                    if ($node) {
                        // insert video node
                        editor.insertNode(welEditable, $node[0]);
                    }
                    //editor.insertNode(welEditable, $node);
                    //$("#summernote").code($("#summernote").code() + code);
                } else {
                    code = "<span><img style='width: 25%;'  src='" + data.SuccessInfo + "' /></span>&nbsp;";
                    editor.insertImage(welEditable, data.SuccessInfo, "img");
                }
            }
        }
    });
}