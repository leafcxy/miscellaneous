using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Comit.XJPublicServicePlatform.Areas.Common.Controllers
{
    public class SecurityController : Controller
    {
        public ActionResult EncryptQueryString(string param)
        {
            return Json("{newstr:'" + Comit.XJPublicServicePlatform.Web.Common.Security.EncryptQueryString(param) + "'}");
            //return Comit.Gse.DAO.Security.EncryptQueryString(param);
        }

        public ActionResult DecryptQueryString(string param)
        {
            return Json("{newstr:'" + Comit.XJPublicServicePlatform.Web.Common.Security.DecryptQueryString(param) + "'}");
        }
    }
}