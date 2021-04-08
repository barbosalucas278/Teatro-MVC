using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using teatro.Models;
using teatro.Models.ViewModels;

namespace teatro.Controllers
{
    public class OrquestasController : Controller
    {
        private readonly Teatro bd = new Teatro();
        // GET: Orquestas
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: Orquestas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Orquestas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orquestas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orquestas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Orquestas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orquestas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Orquestas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
