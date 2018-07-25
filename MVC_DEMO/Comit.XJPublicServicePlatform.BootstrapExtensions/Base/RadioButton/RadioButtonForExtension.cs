using System;
using System.Linq.Expressions;
using System.Web.Mvc;
namespace Comit.XJPublicServicePlatform.BootstrapExtensions.Base
{
    public static class RadioButtonForExtensions
    {
        public static MvcHtmlString RadioButtonForExtension<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value, object htmlAttributes, string text)
        {
            String radioButtonForStr = System.Web.Mvc.Html.InputExtensions.RadioButtonFor(htmlHelper, expression, value, htmlAttributes).ToHtmlString();
            radioButtonForStr = string.Format(" <label>{0}<span class=\"lbl\">{1}</span>\t</label>", radioButtonForStr, text);
            return MvcHtmlString.Create(radioButtonForStr);
        }
    }
}

