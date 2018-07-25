using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Comit.XJPublicServicePlatform.BootstrapExtensions.Base
{
    public static class CheckBoxForExtensions
    {
        public static MvcHtmlString CheckBoxForExtension<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, object htmlAttributes)
        {
            String checkBoxForStr = System.Web.Mvc.Html.InputExtensions.CheckBoxFor(htmlHelper, expression, htmlAttributes).ToHtmlString();
            checkBoxForStr = checkBoxForStr.Replace("<input name=\""+expression.Body.ToString().Split('.')[1]+"\" type=\"hidden\" value=\"false\" />", "");
            checkBoxForStr = string.Format("<label>{0}<span class=\"lbl\"></span><input name=\"" + expression.Body.ToString().Split('.')[1] + "\" type=\"hidden\" value=\"false\" />\t</label>", checkBoxForStr);
            return MvcHtmlString.Create(checkBoxForStr);
        }
    }
}
    