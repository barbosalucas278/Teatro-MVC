using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Teatro_App.Controllers
{
    public class HomeController : Controller
    {
        private UnidadTrabajo _Ut;
        public HomeController()
        {
            _Ut = new UnidadTrabajo();
        }
        public ActionResult Index()
        {
            var integranteNuevo = new Integrante
            {
                Nombre = "Lucas",
                Apellido = "Barbosa",
                Edad = 27,
                Dni = "39485335",
                Telefono = "1161336329"
            };
            _Ut.Integrantes.Add(integranteNuevo, "Lucas");
            var resultado = _Ut.Complete().Result;
            if (resultado == 1)
            {
                _Ut.Dispose();
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}