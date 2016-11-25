using System.Web;
using System.Web.Optimization;

namespace MyWebApplication
{
    public class BundleConfig
    { 
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular").Include( 
                       "~/Scripts/AngularJs/angular.min.js",
                       "~/Scripts/AngularJs/angular-ui-router.min.js",
                       "~/Scripts/AngularJs/angular-animate.min.js",
                       "~/Scripts/AngularJs/salaryAppModules.js",
                       "~/Scripts/AngularJs/salaryApp.js",
                       "~/Scripts/AngularJs/angular-material.min.js",
                       "~/Scripts/AngularJs/angular-aria.min.js",
                       "~/Scripts/AngularJs/svg-assets-cache.js",
                       "~/Scripts/app/loader/controller/loaderController.js"
                       ));
             
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/CustomScripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/CustomScripts/jquery.validate*"));
             
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/CustomScripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/CustomScripts/bootstrap.js",
                      "~/Scripts/CustomScripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/css/progressbar.css",
                      "~/Content/site.css"));
        }
    }
}
