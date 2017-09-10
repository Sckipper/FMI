using System.Web;
using System.Web.Optimization;

namespace Licenta
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/3rdParty/jquery-1.10.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/3rdParty/jquery-ui.1.12.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/Logged").Include(
                        "~/Scripts/Logged.js"));

            bundles.Add(new ScriptBundle("~/bundles/Layout").Include(
                        "~/Scripts/Layout.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/Home").Include(
                      "~/Scripts/3rdParty/jquery.piegraph.js",
                      "~/Scripts/Home.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap.css",
                      "~/Content/Layout.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/Login").Include(
                      "~/Content/Login.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/Home").Include(
                      "~/Content/Home.css"
                      ));

            BundleTable.EnableOptimizations = true;
        }
    }
}
