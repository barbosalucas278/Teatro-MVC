using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using teatro.Models;
using teatro.Models.ViewModels;

namespace teatro.Controllers
{
    public class IntegrantesController : Controller
    {
        private readonly Teatro db = new Teatro();

        // GET: Integrantes
        public ActionResult Index()
{
            var listaDB = db.Integrante
                .OrderByDescending(x => x.Id)
                .ToList();

            var integrantesDto = listaDB.Select(Utilidades.MapearIntegrante).OrderByDescending(x => x.Nombre).ToList();

            IntegranteViewModel viewModel = new IntegranteViewModel
            {
                ListaIntegrantes = integrantesDto
            };


            return View(viewModel);
        }

        public ActionResult Listado()
        {
            return View();
        }

        // GET: Integrantes/Create
        public ActionResult CreateIntegrante()
        {
            return View();
        }

        // POST: Integrantes/Create
        [HttpPost]
        public ActionResult CreateIntegrante(IntegranteDto integrante)
        {
            try
            {
                var integranteDb = Utilidades.MapearIntegrante(integrante);

                db.Integrante.Add(integranteDb);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                var viewModel = new IntegranteViewModel
                {
                    Integrante = integrante
                };
                return View(viewModel);
            }
        }

        // GET: Integrantes/Edit/5
        public ActionResult IntegranteEdit(int id)
        {
            var integranteDb = db.Integrante.Where(x => x.Id == id).FirstOrDefault();

            var viewModel = new IntegranteViewModel
            {
                Integrante = Utilidades.MapearIntegrante(integranteDb)            
            };

            return View(viewModel);
        }

        // POST: Integrantes/Edit/5
        [HttpPost]
        public ActionResult IntegranteEdit(int id, IntegranteDto integrante)
        {
            try
            {
                var integranteDb = db.Integrante.Where(x => x.Id == id).FirstOrDefault();
                if(integranteDb != null)
                {
                    integranteDb.Nombre = integrante.Nombre;
                    integranteDb.Apellido = integrante.Apellido;
                    integranteDb.Edad = integrante.Edad;
                    integranteDb.Telefono = integrante.Telefono;
                    
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(integrante);
            }
        }

        // GET: Integrantes/Delete/5
        public ActionResult IntegranteDelete(int id)
        {
            var integranteDb = db.Integrante.Where(x => x.Id == id && x.Activo).FirstOrDefault();
            if (integranteDb != null)
            {
                var integranteDto = new IntegranteDto
                {
                    Id = integranteDb.Id,
                    Nombre = integranteDb.Nombre,
                    Apellido = integranteDb.Apellido,
                    Edad = integranteDb.Edad,
                    Telefono = integranteDb.Telefono
                };
                return View(integranteDto);
            }

                return RedirectToAction("Index");
        }

        // POST: Integrantes/Delete/5
        [HttpPost]
        public ActionResult IntegranteDelete(int id, IntegranteDto integranteDto)
        {
            try
            {
                var integranteDb = db.Integrante.Where(x => x.Id == id).FirstOrDefault();
                integranteDb.Activo = false;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
    
}
