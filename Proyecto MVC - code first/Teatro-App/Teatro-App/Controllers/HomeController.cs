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
            //var iipe = new IntegranteInstrumentoPuestoEvento
            //{
            //    IntegranteId = 21,
            //    PuestoId = 5,
            //    InstrumentoId = 14,
            //    EventoId = 1,
            //    Nombre = "no se que poner"
            //};
            //_Ut.IntegranteInstrumentoPuestoEventos.Add(iipe, "pepe");
            var busqueda = _Ut.IntegranteInstrumentoPuestoEventos.GetIntegrante(21).Result;
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