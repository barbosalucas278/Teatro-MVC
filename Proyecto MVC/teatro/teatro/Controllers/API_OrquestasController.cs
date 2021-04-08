using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using teatro.Models;

namespace teatro.Controllers
{
    public class API_OrquestasController : ApiController
    {
        private Teatro db = new Teatro();

        [Route("Orquestas/all")]
        public IHttpActionResult GetOrquestas()
        {
            var listaOrquestasDb = db.Orquesta.Where(x => x.Activo).OrderByDescending(x => x.Nombre).ToList();

            var listaorquestasDto = listaOrquestasDb.Select(Utilidades.MapearOrquesta).ToList();

            return Ok(listaorquestasDto);
        }

        [Route("Orquestas/findbyid/{id}")]
        public IHttpActionResult GetOrquesta(int? id)
        {
            if(id is null)
            {
                return BadRequest();
            }
            var orquestaDB = db.Orquesta.Find(id);
            if (orquestaDB == null)
            {
                return NotFound();
            }

            var orquestaDto = Utilidades.MapearOrquesta(orquestaDB);

            return Ok(orquestaDto);
        }

        // PUT: api/API_Orquestas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrquesta(int id, Orquesta orquesta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orquesta.Id)
            {
                return BadRequest();
            }

            db.Entry(orquesta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrquestaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/API_Orquestas
        [ResponseType(typeof(Orquesta))]
        public IHttpActionResult PostOrquesta(Orquesta orquesta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Orquesta.Add(orquesta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = orquesta.Id }, orquesta);
        }

        // DELETE: api/API_Orquestas/5
        [ResponseType(typeof(Orquesta))]
        public IHttpActionResult DeleteOrquesta(int id)
        {
            Orquesta orquesta = db.Orquesta.Find(id);
            if (orquesta == null)
            {
                return NotFound();
            }

            db.Orquesta.Remove(orquesta);
            db.SaveChanges();

            return Ok(orquesta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrquestaExists(int id)
        {
            return db.Orquesta.Count(e => e.Id == id) > 0;
        }
    }
}