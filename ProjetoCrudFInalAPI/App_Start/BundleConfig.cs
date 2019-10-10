using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ProjetoCrudeFInalAPI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/YourStyles.css"));

#if DEBUG

            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif

            //public static void RegisterBundles(BundleCollection bundles)
            //{
            //    bundles.Add(new ScriptBundle("~/bundles/scripts/desktop")
            //        .Include(
            //                 "~/Scripts/jquery-{version}.js",
            //                 "~/Scripts/jquery-ui-{version}.js",
            //                 "~/Scripts.unobtrusive.ajax.js"
            //                 )
            //            .IncludeDirectory("~/Scripts",".js"));

            //    bundles.Add(new StyleBundle("~/bundles/css/desktop")
            //        .Include(
            //        "~/Content/themes/base/jquery-ui.css")
            //        .IncludeDirectory("~/Content", ".css"));
        }
    }
}