using System.Web;
using System.Web.Optimization;

namespace Comit.XJPublicServicePlatform
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/unobtrusive").Include(
                        "~/Scripts/jquery.unobtrusive*"));

            bundles.Add(new ScriptBundle("~/bundles/iecustom").Include(
                        "~/Assets/js/html5shiv.js",
                        "~/Assets/js/respond.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      //调整了bootstrap和typeahead的顺序，与原生框架一致
                      "~/Assets/js/bootstrap.min.js",
                      "~/Assets/js/typeahead-bs2.min.js",
                      "~/Scripts/Security.js",
                      "~/Scripts/LoadingUtils.js",
                      "~/Assets/js/bootbox.min.js",
                      "~/Assets/js/jquery-ui-1.10.3.full.min.js",
                      "~/Assets/js/jquery.ui.touch-punch.min.js",
                      "~/Assets/js/chosen.jquery.min.js",
                      "~/Assets/js/fuelux/fuelux.spinner.min.js",
                      "~/Assets/js/date-time/bootstrap-datepicker.min.js",
                      "~/Assets/js/date-time/bootstrap-timepicker.min.js",
                      // "~/Assets/js/date-time/moment.min.js",
                      //"~/Assets/js/date-time/daterangepicker.min.js",
                      "~/Assets/js/bootstrap-colorpicker.min.js",
                      "~/Assets/js/jquery.knob.min.js",
                      "~/Assets/js/jquery.autosize.min.js",
                      "~/Assets/js/jquery.inputlimiter.1.3.1.min.js",
                      "~/Assets/js/jquery.maskedinput.min.js",
                      "~/Assets/js/bootstrap-tag.min.js",
                      "~/Assets/js/ace-elements.min.js",
                      "~/Assets/js/ace.min.js",
                      "~/Assets/js/select2.min.js",
                      "~/Scripts/pageCommon.js"
                       
                      ));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*",
                        "~/Assets/js/ace-extra.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqGrid").Include(
                      "~/Assets/js/bootstrap.min.js",
                      "~/Assets/js/jqGrid/jquery.jqGrid.min.js",
                      "~/Assets/js/jqGrid/i18n/grid.locale-en.js",
                      "~/Scripts/Security.js",
                      "~/Scripts/LoadingUtils.js",
                      "~/Assets/js/bootbox.min.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/loading.css",
                    "~/Assets/css/bootstrap.css",
                    "~/Assets/css/font-awesome.min.css",
                    "~/Assets/css/summernote.min.css",
                    "~/Assets/css/jquery-ui-1.10.3.full.min.css",
                    "~/Assets/css/chosen.css",
                    "~/Assets/css/datepicker.css",
                    "~/Assets/css/bootstrap-timepicker.css",
                    "~/Assets/css/daterangepicker.css",
                    "~/Assets/css/colorpicker.css",
                    "~/Assets/css/ace-fonts.css",
                    "~/Assets/css/ace.min.css",
                    "~/Assets/css/ace-rtl.min.css",
                    "~/Assets/css/ace-skins.min.css",
                    "~/Assets/css/select2.css"
                    ));
            bundles.Add(new StyleBundle("~/Content/pickercss").Include(
            "~/Assets/css/bootstrap-combined.min.css",
            "~/Assets/css/bootstrap-timepicker.css"
        ));
            bundles.Add(new ScriptBundle("~/bundles/map").Include(
                      "~/Assets/js/jquery-1.10.2.min.js",
                      "~/Scripts/mapAPI/myApp.js",
                      "~/Scripts/mapAPI/util.js",
                      "~/Scripts/mapAPI/view.js",
                      "~/Scripts/mapAPI/service.js",
                      "~/Scripts/mapAPI/xwin.js",
                      "~/Scripts/mapAPI/jquery-ui-1.8.16.custom.min.js",
                      "~/Scripts/mapAPI/progress.js",
                      "~/Assets/js/bootbox.min.js",
                      "~/Assets/js/bootbox.min.js",
                      "~/Assets/js/date-time/moment.min.js",
                      "~/Assets/js/bootstrap-datetimepicker.min.js",
                      "~/Scripts/pageCommon.js"
                      ));
            bundles.Add(new StyleBundle("~/Content/mapCss").Include(
                    "~/Content/MapCss/lzhx_souye.css",
                    "~/Content/MapCss/common.css",
                    "~/Content/MapCss/xwin.css",
                    "~/Content/MapCss/jquery-ui-1.8.16.custom.css",
                    "~/Content/MapCss/progress.css",
                    "~/Assets/css/bootstrap-datetimepicker.min.css",
                    "~/Assets/css/bootstrap-combined.min.css",
                    "~/Content/MapCss/map.css"
                    ));

            bundles.Add(new StyleBundle("~/Content/indexCss").Include(
                    "~/Assets/css/index/index.css",
                    "~/Assets/css/index/navDefault.css"
                
                    ));
            //覆盖Web.Config的开启关闭压缩设置
            //在 Web.config文件中compilation节点设置debug 的值可以开启或关闭压缩和合并功能。 在下面的XML中， debug设置值为true，可以禁用脚本压缩和合并功能。
            BundleTable.EnableOptimizations = false;
        }
    }
}
