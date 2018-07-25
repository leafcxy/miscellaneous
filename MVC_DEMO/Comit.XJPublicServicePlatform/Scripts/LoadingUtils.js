

var timeoutTmp;
LoadingUtils={
	/**
	 * 开启加载提示
	 * @author Sky
	 * @param windowObj 要显示加载提示的窗口对象,没有指定则为当前窗口
	 */
	
    loading:function (windowObj){
        if(windowObj==null){
  		    windowObj=window;
  	    }  
  	    if(windowObj.document.getElementById("loadingDiv")==null){
	        var div = windowObj.document.createElement("div"); 
	 	    //var iframe = windowObj.document.createElement("iframe"); 
	        var img = windowObj.document.createElement("img"); 
	        var basePath="";
	        var indexPathName=document.location.pathname.indexOf("/");
	        if(indexPathName!=-1){
	    	    indexPathName=document.location.pathname.indexOf("/",indexPathName+1);
	        }
	        var indexHostPath=document.location.href.indexOf(document.location.pathname);
	        if(indexHostPath!=-1){
	    	    basePath=document.location.href.substring(0,indexHostPath+indexPathName);
	        }
	        img.src = "../../../Images/Share/loading.gif";
	        img.onerror = function(){ 
	            this.src = "../../../Images/Share/loading.gif";
	        };
	        img.className="loadingImg";
	        img.style.display = "none";
	        img.style.marginLeft = ((document.body.clientWidth - 75)) / 2+"px";
	        img.style.marginTop = ((document.body.clientHeight - 100) / 2) + "px";
	        //iframe.className="loadingDiv";   
	        div.id="loadingDiv";  
	        div.className="loadingDiv";  
	        div.appendChild(img);  
	  	    //div.appendChild(iframe);   

	        windowObj.document.body.appendChild(div);   
            img.style.display="block";
            timeoutTmp = setTimeout("top.LoadingUtils.errorload();",60000);
  	    }
    },  
	  
    errorload:function()
    {
        comfirmBox('页面加载超时，是否继续加载？', 'LoadingUtils.confirmYES()', 'LoadingUtils.confirmNO()');
    },
	confirmYES:function()
	{
	    timeoutTmp = setTimeout("top.LoadingUtils.errorload();",60000);
	},
	confirmNO:function()
	{
	    top.LoadingUtils.unloading();
	}, 
	/**
	 * 关闭加载提示
	 * @author Sky
	 * @param windowObj 要关闭加载提示的窗口对象,没有指定则为当前窗口
	 */   
	unloading:function (subject,windowObj){
		clearTimeout(timeoutTmp);
	  	if(windowObj==null){
	  		windowObj=window;
	  	}  	
	    var div = windowObj.document.getElementById("loadingDiv");
	    if(div!=null){
	    	windowObj.document.body.removeChild(div);
	    }
	  },
	GoToUrl:function (Url)
	{
	    if (top != null) top.LoadingUtils.loading();
	    var newUrl = "";
	    var newParam = "";
	    if (String(Url).indexOf("\?") != -1) {
	        newUrl = String(Url).split("\?")[0];
	        var params = String(Url).split("\?")[1].split("&");
	        for (var i = 0; i < params.length; i++) {
	            if (params[i].indexOf("=") != -1) {//参数加密
	                if (i < params.length - 1) {
	                    newParam += params[i].split("=")[0] + "=" + EncryptQueryString(params[i].split("=")[1]) + "&";
	                }
	                else
	                {
	                    newParam += params[i].split("=")[0] + "=" + EncryptQueryString(params[i].split("=")[1]);
	                }	                
	            }

	        }
	        newUrl += "?" + newParam;
	    }
	    else {
	        newUrl = Url;
	    }
	    window.location.href = newUrl;
	},//重写列表跳转的方法
	GoToUrl: function (Url, treeID) {
	    
	    if (top != null) top.LoadingUtils.loading();
	    var newUrl = "";
	    var newParam = "";
	    if (String(Url).indexOf("\?") != -1) {
	        newUrl = String(Url).split("\?")[0];
	        var params = String(Url).split("\?")[1].split("&");
	        for (var i = 0; i < params.length; i++) {
	            if (params[i].indexOf("=") != -1) {//参数加密
	                if (i < params.length - 1) {
	                    newParam += params[i].split("=")[0] + "=" + EncryptQueryString(params[i].split("=")[1]) + "&";
	                }
	                else {
	                    newParam += params[i].split("=")[0] + "=" + EncryptQueryString(params[i].split("=")[1]);
	                }
	            }

	        }
	        newUrl += "?TreeId=" + treeID + "&" + newParam;
	    }
	    else {
	        newUrl = Url + "?TreeId=" + treeID;
	    }
	    window.location.href = newUrl;
	},
	OpenToUrl:function (Url)
    {
        if(top != null)top.LoadingUtils.loading();
        window.open(Url,'','height=700, width=950,scrollbars=yes');
    },
    DataLoading:function ()
    {
        if(top != null)top.LoadingUtils.loading();
    },
    DataUnloading:function ()
    {
        if(top != null)top.LoadingUtils.unloading();
    },
    DelConfirm:function ()
    {       
        ConfimBox('您确定要删除吗？','btnDel')
        return false;
    },
    focusInput:function ()//定位光标焦点到第一个输入框
    {
        for(var i=0;i<10;i++)
        {

            if($('input:visible').get(i) != null)
            {
                
                try 
                {
                    $('input:visible').get(i).focus();
                    break;
                } 
                catch(e) 
                {
                } 
                finally 
                {
                }

            }
            else
            {
                break;
            }
        }
    },

    Page_Load:function()
    {
        //设置页面的标题。
        document.title='广州航运交易所';
        //设置只读的字段外面的TD的样式
        $('input[disabled is true]').parent('td').toggleClass('compositionalInput_disabledContextTD');
        $('textarea[disabled is true]').parent('td').toggleClass('compositionalTextarea_disabledContextTD');
        //定位光标焦点到第一个输入框
        LoadingUtils.focusInput();
        $('input[disabled is true][class=buttonBg]').attr('class','buttonBgForDisable');
        
    }
};






try{//对于不支持document.onreadystatechange 事件的浏览器，则调用jquery的onload方法关闭
    $(function () {
        if(top != null && top.LoadingUtils != null)
        {
            top.LoadingUtils.unloading();
        }
        //LoadingUtils.Page_Load();
	});
}catch(e){}