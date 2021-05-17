using System.Web.Optimization;


namespace TemplateSystem.WebMvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterLogin(bundles);
            RegisterLayout(bundles);

            BundleTable.EnableOptimizations = true;

        }


        private static void RegisterLogin(BundleCollection bundles)
        {
            //Styles
            bundles.Add(new StyleBundle("~/assets/plugins/jquery-ui").Include(
                "~/assets/plugins/jquery-ui/jquery-ui.min.css"));


            bundles.Add(new StyleBundle("~/assets/plugins/bootstrap/4.1.0/css").Include(
               "~/assets/plugins/bootstrap/4.1.0/css/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/assets/plugins/font-awesome/5.0/css").Include(
               "~/assets/plugins/font-awesome/5.0/css/fontawesome-all.min.css"));

            bundles.Add(new StyleBundle("~/assets/plugins/animate").Include(
               "~/assets/plugins/animate/animate.min.css"));

            bundles.Add(new StyleBundle("~/assets/css/material").Include(
               "~/assets/css/material/style.min.css"));

            bundles.Add(new StyleBundle("~/assets/css/material").Include(
               "~/assets/css/material/style-responsive.min.css"));

            bundles.Add(new StyleBundle("~/assets/css/material/theme").Include(
               "~/assets/css/material/theme/default.css"));


            bundles.Add(new StyleBundle("~/assets/plugins/gritter/css").Include(
               "~/assets/plugins/gritter/css/jquery.gritter.css"
           ));


            //Scripts          
            

            bundles.Add(new ScriptBundle("~/assets/plugins/jquery").Include(
              "~/assets/plugins/jquery/jquery-3.2.1.min.js"));

            bundles.Add(new ScriptBundle("~/assets/plugins/jquery-ui").Include(
              "~/assets/plugins/jquery-ui/jquery-ui.min.js"));

            bundles.Add(new ScriptBundle("~/assets/plugins/bootstrap/4.1.0/js").Include(
              "~/assets/plugins/bootstrap/4.1.0/js/bootstrap.bundle.min.js"));

            bundles.Add(new ScriptBundle("~/assets/plugins/slimscroll").Include(
              "~/assets/plugins/slimscroll/jquery.slimscroll.min.js"));

            bundles.Add(new ScriptBundle("~/assets/plugins/js-cookie").Include(
              "~/assets/plugins/js-cookie/js.cookie.js"));

            bundles.Add(new ScriptBundle("~/assets/js/theme").Include(
              "~/assets/js/theme/material.min.js"));

            bundles.Add(new ScriptBundle("~/assets/js").Include(
              "~/assets/js/apps.min.js"));

            bundles.Add(new ScriptBundle("~/assets/plugins/gritter/js").Include(
              "~/assets/plugins/gritter/js/jquery.gritter.js"));

            bundles.Add(new ScriptBundle("~/assets/plugins/pace").Include(
              "~/assets/plugins/pace/pace.min.js"));


        }


        public static void RegisterLayout(BundleCollection bundles)
        {
            //Esta es una forma de agregar los estilos minificados
        }




    }
}