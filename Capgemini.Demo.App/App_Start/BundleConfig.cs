using System.Web;
using System.Web.Optimization;

namespace Capgemini.Demo.App
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //"~/Scripts/jquery-1.10.2.min.js"));
            "~/Scripts/js/jquery-2.2.3.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/js/bootstrap.min.js",
                      "~/Scripts/js/mdb.min.js", "~/Scripts/js/tether.min.js"));

            bundles.Add(new StyleBundle("~/Styles/css").Include(
                      "~/Content/mdb/css/bootstrap.css",
                       "~/Content/mdb/css/mdb.css",
                      "~/Content/mdb/css/style.css"
                      ).Include("~/Content/font-awesome/css/font-awesome.css", new CssRewriteUrlTransform()));

        }
    }
}
