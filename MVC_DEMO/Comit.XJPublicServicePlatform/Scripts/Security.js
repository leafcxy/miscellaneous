function EncryptQueryString(param) {
    var newparam = "";
    var paramForSecurity = [
				     { name: 'param', value: param }
    ];
    $.ajax({
        type: 'post',
        url: '/Common/Security/EncryptQueryString',
        async: false,
        data: paramForSecurity,
        dataType: 'json',
        success: function (data) {
            newparam = eval(data);
        },
        error: function (data) { }
    });
    
    return newparam;
}
function DecryptQueryString(param) {
    var newparam = "";
    var paramForSecurity = [
                    { name: 'param', value: param }
    ];
    $.ajax({
        type: 'post',
        url: '/Common/Security/DecryptQueryString',
        async: false,
        data: paramForSecurity,
        datatype: 'json',
        success: function (data) {
            newparam = eval(data);
        },
        error: function (data) { }
    });
    return newparam;

}