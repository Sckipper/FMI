using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Licenta
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleTable.EnableOptimizations = true;
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 90;
        }

        void Session_End(object sender, EventArgs e)
        {

        }

    }
}
