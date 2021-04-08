using System.Web;
using System.Web.Optimization;

namespace teatro
{
    public class BundleConfig
    {
        // Para obtener m�s informaci�n sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            "~/Scripts/jquery.validate*"));   

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
            "~/Scripts/moment.js"));

            bundles.Add(new ScriptBundle("~/bundles/listado").Include(
                        "~/Scripts/listado.js"));
            bundles.Add(new ScriptBundle("~/bundles/validacion-integrante").Include(
                        "~/Scripts/validacion-integrante.js"));
            bundles.Add(new ScriptBundle("~/bundles/funciones").Include(
                        "~/Scripts/funciones.js"));
            bundles.Add(new ScriptBundle("~/bundles/listado-evento").Include(
            "~/Scripts/listado-evento.js"));
            bundles.Add(new ScriptBundle("~/bundles/validation-evento").Include(
            "~/Scripts/validation-evento.js"));

            bundles.Add(new ScriptBundle("~/bundles/detallesModal").Include("~/Scripts/detallesModal.js"));


            // Utilice la versi�n de desarrollo de Modernizr para desarrollar y obtener informaci�n. De este modo, estar�
            // para la producci�n, use la herramienta de compilaci�n disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
