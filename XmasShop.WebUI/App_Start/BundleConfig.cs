using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace SportsStore.WebUI.App_Start
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundleContent").Include(
                        "~/Content/bootstrap_temp/vendor/bootstrap/css/bootstrap.min.css",
                        "~/Content/css/xmas-shop.css",
                        "~/Content/css/fontawesome-all.min.css",
                        "~/Scripts/wowjs/animate.min.css"));

            bundles.Add(new ScriptBundle("~/bundleScripts").Include(
                "~/Content/bootstrap_temp/vendor/jquery/jquery.min.js",
                "~/Scripts/jquery-1.10.2.min.js",
                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                "~/Content/bootstrap_temp/vendor/bootstrap/js/bootstrap.bundle.min.js",
                "~/Scripts/fontawesome-all.min.js"));

        }

    }
}