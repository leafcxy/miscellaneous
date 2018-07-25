using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Comit.XJPublicServicePlatform.BootstrapExtensions.Base
{
    public static class TextBoxForExtensions
    { 
        public static MvcHtmlString TextBoxForExtension<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes, string attributesStr)
        {
            MvcHtmlString textBoxForStr = System.Web.Mvc.Html.InputExtensions.TextBoxFor(htmlHelper, expression, htmlAttributes);
            return MvcHtmlString.Create(textBoxForStr.ToString().Replace("/>", attributesStr + "/>")); 
        }

        public static MvcHtmlString TextBoxExtension(this HtmlHelper htmlHelper, string name, object value, object htmlAttributes, string attributesStr)
        {
            MvcHtmlString textBoxForStr = System.Web.Mvc.Html.InputExtensions.TextBox(htmlHelper,name,value, htmlAttributes);
            return MvcHtmlString.Create(textBoxForStr.ToString().Replace("/>", attributesStr + "/>"));
        }
    }
}
