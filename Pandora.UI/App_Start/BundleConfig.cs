using System.Web;
using System.Web.Optimization;

namespace Pandora.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //USER
            bundles.Add(new StyleBundle("~/styles/general").Include(
                "~/Content/css/normalize.css",
                "~/Content/css/main.css",
                "~/Content/css/bootstrap.min.css",
                "~/Content/css/animate.min.css",
                "~/Content/css/font-awesome.min.css",
                "~/Content/css/font/flaticon.css",
                "~/Content/css/owl.carousel.min.css",
                "~/Content/css/owl.theme.default.min.css",
                "~/Content/css/meanmenu.min.css",
                "~/Content/lib/custom-slider/css/nivo-slider.css",
                "~/Content/lib/custom-slider/css/preview.css",
                "~/Content/css/select2.min.css",
                "~/Content/style.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/general").Include(
                "~/Scripts/js/vendor/modernizr-2.8.3.min.js",
                "~/Scripts/js/vendor/jquery-2.2.4.min.js",
                "~/Scripts/js/bootstrap.min.js",
                "~/Scripts/js/owl.carousel.min.js",
                "~/Scripts/lib/custom-slider/js/jquery.nivo.slider.js",
                "~/Scripts/lib/custom-slider/home.js",
                "~/Scripts/js/jquery.meanmenu.min.js",
                "~/Scripts/js/wow.min.js",
                "~/Scripts/js/plugins.js",
                "~/Scripts/js/jquery.countdown.min.js",
                "~/Scripts/js/jquery.scrollUp.min.js",
                "~/Scripts/js/isotope.pkgd.min.js",
                "~/Scripts/js/main.js",
                "~/Scripts/js/select2.min.js",
                "~/Scripts/js/vendor/noUiSlider/nouislider.min.js",
                "~/Scripts/js/wNumb.js"
                ));

        }
    }
}
