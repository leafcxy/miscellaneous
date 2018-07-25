//附件上传管理公共页js 2014-09-25 by ysh
//子页面控制父页面iframe自适应高度
function resizeMain(height) {
    //现控件需要动态增加的高度
    var oldformHeight = $("#formHeight").val();
    //上一个控件动态增加的高度，需减去
    var formHeight = $("body").find("form").height();
    //动态更改页面高度
    $("body").find("form").height(formHeight + height - oldformHeight)
    //父页面ifram自适应高度
    setTimeout("$(top).resize()", "100");
    //保存此次动态适应的高度
    $("#formHeight").val(height);
}

//事项详细页面引用的js
//审核通过附件生效方法
function PassEffect(applyNum,affixId) {
    var delUrl = $("form")[0].action.replace("Operate", "PassEffect");
    $.ajax({
        type: "POST",
        url: delUrl,
        data: { objId: $("#ObjId").val(), applyNum: applyNum, affixId: affixId },
        dataType: "json",
        beforeSend: function (data) {
            if (top != null) top.LoadingUtils.loading();
        },
        success: function (data) {
            alertBox(data.SuccessInfo);
            if (data.SuccessInfo == "操作成功！") {
                window.location.href = data.Url;
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

//企业列表下载附件
function download(affixId, objId) {
    window.open("/UploadManagement/ObjEnclosureHistory/Download?AffixId=" + affixId + "&objId=" + objId);
}