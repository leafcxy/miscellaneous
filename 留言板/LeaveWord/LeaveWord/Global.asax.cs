using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MvcContrib.Unity;
using Microsoft.Practices.Unity;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.Unity.Configuration;
using System.Web.Security;
using System.Collections;
using System.Web.Configuration;
using System.Web.Http;

namespace LeaveWord
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication, IUnityContainerAccessor
    {
        protected void Application_Start()
        {
            InitializeContainer();
            AreaRegistration.RegisterAllAreas();
            HtmlHelper.UnobtrusiveJavaScriptEnabled = true;
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            log4net.Config.XmlConfigurator.Configure();
        }
        private static UnityContainer _container;

        public static IUnityContainer Container
        {
            get { return _container; }
        }

        #region IUnityContainerAccessor 成员

        IUnityContainer IUnityContainerAccessor.Container
        {
            get { return Container; }
        }

        #endregion

        /// <summary>
        /// Instantiate the container and add all Controllers that derive from 
        /// UnityController to the container.  Also associate the Controller 
        /// with the UnityContainer ControllerFactory.
        /// </summary>
        protected virtual void InitializeContainer()
        {
            if (_container == null)
            {
                _container = new UnityContainer();

                // Set the Unity Controller Factory
                ControllerBuilder.Current.SetControllerFactory(typeof(UnityControllerFactory));

                string unityConfigFilePath = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["unityConfigPath"];
                FileConfigurationSource configExternal = new FileConfigurationSource(unityConfigFilePath);

                UnityConfigurationSection section = (UnityConfigurationSection)configExternal.GetSection("unity");
                section.Containers["dt"].Configure(_container);
            }
        }
    }
}