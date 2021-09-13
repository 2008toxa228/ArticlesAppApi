using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ArticlesAppApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IsoDateTimeConverter converter = new IsoDateTimeConverter
            {
                DateTimeStyles = DateTimeStyles.AdjustToUniversal,
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
            };
            GlobalConfiguration.Configuration.Formatters
             .JsonFormatter.SerializerSettings.Converters.Add(converter);
        }
    }
}
