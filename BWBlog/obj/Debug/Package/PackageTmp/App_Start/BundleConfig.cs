using System.Web;
using System.Web.Optimization;

namespace BWBlog
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Theme/vendor/jquery/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Theme/vendor/popper/popper.min.js",
                      "~/Theme/vendor/bootstrap/js/bootstrap.min.js",
                      //"~/Scripts/respond.js",
                      "~/Scripts/custom.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jsscripts").Include(
                      "~/Scripts/Activities/alphabetize.js",
                      "~/Scripts/Activities/capitalize.js",
                      "~/Scripts/Activities/factorial.js",
                      "~/Scripts/Activities/fizzbuss.js",
                      "~/Scripts/Activities/palindrome.js",
                      "~/Scripts/Activities/stats.js",
                      "~/Scripts/Activities/prime.js",
                      "~/Scripts/Activities/stringscrambler.js",
                      "~/Scripts/Activities/vowels.js",
                      "~/Scripts/SyntaxHighlighter/shCore.js",
                      "~/Scripts/SyntaxHighlighter/shBrushJScript.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Theme/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Theme/css/modern-business.css",
                      "~/Content/site.css",
                      //"~/Assets/css/custom.css",
                      "~/Content/SyntaxHighlighter/shCore.css",
                      "~/Content/SyntaxHighlighter/shCoreDefault.css",
                      "~/Content/SyntaxHighlighter/shThemeDefault.css"
                      ));
        }
    }
}
