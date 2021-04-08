using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using teatro.Models;
using teatro.Models.ViewModels;

namespace teatro.Controllers
{
    public class EventosController : Controller
    {
        private readonly Teatro db = new Teatro();
        //Vista API
        public ActionResult ListadoEvento()
        {
            return View();
        }
        // GET: Eventos
        public ActionResult Index()
        {
            var eventosDb = db.Evento.Where(x => x.Activo).OrderByDescending(x => x.Dia).ToList();
            var eventosDto = eventosDb.Select(Utilidades.MapearEvento).ToList();

            var viewmodel = new EventoIndexViewModel
            {
                ListaEventos = eventosDto
            };
            return View(viewmodel);
        }

        // GET: Eventos/Details/5
        public ActionResult Details(int id)
        {
            var eventosDb = db.Evento.FirstOrDefault(x => x.id == id && x.Activo);

            var viewModel = new EventoViewModel
            {
                Evento = Utilidades.MapearEvento(eventosDb)
            };
            return View(viewModel);
        }
        // GET: Eventos/Create
        public ActionResult Create()
        {
            var listaOrquestasDb = db.Orquesta.OrderByDescending(x => x.Nombre).ToList();
            var listaOrquestaDto = listaOrquestasDb.Select(Utilidades.MapearOrquesta).ToList();
            var viewModel = new EventoViewModel
            {
                ListaOrquestas = listaOrquestaDto
            };
            return View(viewModel);
        }

        // POST: Eventos/Create
        [HttpPost]
        public ActionResult Create(EventoViewModel viewModel)
        {
            try
            {
                if (viewModel != null)
                {

                    var eventoDb = new Evento
                    {
                        OrquestaId = viewModel.Evento.Orquesta.Id,
                        Orquesta = db.Orquesta.Where(x => x.Id == viewModel.Evento.Orquesta.Id && x.Activo).FirstOrDefault(),
                        Dia = viewModel.Evento.Dia,
                        Obra = viewModel.Evento.Obra,
                        Activo = true
                    };

                    db.Evento.Add(eventoDb);

                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Eventos/Edit/5
        public ActionResult Edit(int id)
        {
            var evento = db.Evento.Where(x => x.id == id && x.Activo).FirstOrDefault();


            var eventoDto = new EventoDto
            {
                Id = evento.id,
                Dia = evento.Dia,
                Obra = evento.Obra,
                Orquesta = new OrquestaDto
                {
                    Id = evento.Orquesta.Id,
                    Localidad = evento.Orquesta.Localidad,
                    Nombre = evento.Orquesta.Nombre
                },
            };


            var listaOrquestasDto = db.Orquesta.Select(Utilidades.MapearOrquesta).ToList();

            var viewModel = new EventoViewModel
            {
                Evento = eventoDto,
                ListaOrquestas = listaOrquestasDto
            };
            return View(viewModel);
        }

        // POST: Eventos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EventoViewModel viewModel)
        {
            try
            {
                var eventoDb = db.Evento.Where(x => x.id == id && x.Activo).FirstOrDefault();

                eventoDb.OrquestaId = viewModel.Evento.Orquesta.Id;
                eventoDb.Orquesta = db.Orquesta.Where(x => x.Id == viewModel.Evento.Orquesta.Id && x.Activo).FirstOrDefault();
                eventoDb.Dia = viewModel.Evento.Dia;
                eventoDb.Obra = viewModel.Evento.Obra;


                return RedirectToAction("Index");


                db.SaveChanges();

                return RedirectToAction("Index");

            }
            catch
            {
                var listaOrquestasDto = db.Orquesta.Select(Utilidades.MapearOrquesta).ToList();

                viewModel.ListaOrquestas = listaOrquestasDto;
                return View(viewModel);
            }
        }

        // GET: Eventos/Delete/5
        public ActionResult Delete(int id)
        {
            var evento = db.Evento.Where(x => x.id == id && x.Activo).FirstOrDefault();
            if (evento != null)
            {


                var eventoDto = new EventoDto
                {
                    Id = evento.id,
                    Dia = evento.Dia,
                    Obra = evento.Obra,
                    Orquesta = new OrquestaDto
                    {
                        Id = evento.Orquesta.Id,
                        Localidad = evento.Orquesta.Localidad,
                        Nombre = evento.Orquesta.Nombre
                    },
                };

                var viewModel = new EventoViewModel
                {
                    Evento = eventoDto
                };
                return View(viewModel);
            }
            return RedirectToAction("Index");
        }

        // POST: Eventos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EventoDto eventoDto)
        {
            try
            {
                var eventoDb = db.Evento.Where(x => x.id == id && x.Activo).FirstOrDefault();

                eventoDb.Activo = false;

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
