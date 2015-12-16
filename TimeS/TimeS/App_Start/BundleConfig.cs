using System.Web.Optimization;

namespace TimeS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/Scripts/Features/Jquery/jquery-2.1.4.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Content/Scripts/Features/Angular/angular.min.js",
                        "~/Content/Scripts/Features/Angular/angular-ui-router.min.js",
                        "~/Content/Scripts/Features/Angular/angular-resource.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/angularStrap").Include(
            //            "~/Content/Scripts/Features/Angular/angular-animate.min.js",
            //            "~/Content/Scripts/Features/Angular/angular-strap.min.js",
            //            "~/Content/Scripts/Features/Angular/angular-strap.tpl.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/mainAnjs").Include(
                        "~/Content/Scripts/Site/Default/App.js",
                        "~/Content/Scripts/Site/Default/Controller.js",
                        "~/Content/Scripts/Site/Usuario/Controller.js",
                        "~/Content/Scripts/Site/Atividade/Controller.js",
                        "~/Content/Scripts/Site/Tarefa/Controller.js",
                        "~/Content/Scripts/Site/TipoAtividade/Controller.js",
                        "~/Content/Scripts/Site/Default/Default.js",
                        "~/Content/Scripts/Site/Default/Service.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/Scripts/Features/Jquery/jquery.validate*"));

            //Use the development version of Modernizr to develop with and learn from. Then, when you're
            //ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/Scripts/Features/Jquery/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/Scripts/Features/Bootstrap/bootstrap.min.js",
                      "~/Content/Scripts/Features/Jquery/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Styles/Features/bootstrap.min.css",
                      "~/Content/Styles/Default.css"));
        }
    }
}
