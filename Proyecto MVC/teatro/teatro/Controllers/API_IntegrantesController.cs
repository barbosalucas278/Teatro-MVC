using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using teatro.Models;

namespace teatro.Controllers
{
    
    public class API_IntegrantesController : ApiController
    {
        private readonly Teatro db = new Teatro();

        [Route("Integrantes/all")]
        public IHttpActionResult GetElementos()
        {
            var listaDB = db.Integrante.Where(x => x.Activo)
                .OrderByDescending(x => x.Id)
                .ToList();

            var integrantesDto = listaDB.Select(Utilidades.MapearIntegrante).OrderByDescending(x => x.Nombre).ToList();

            return Ok(integrantesDto);
        }
     
        [HttpPost]
        [Route("Integrantes/verificar")]
        public IHttpActionResult GetVerificarDni([FromBody]string dni)
        {
            if (dni != null)
            {
                bool existe = false;

                var listaDB = db.Integrante.Where(x => x.Activo).Select(x => new
                {
                    dni = x.Dni
                }).ToList();

                foreach (var integrante in listaDB)
                {
                    if (integrante.dni == dni)
                    {
                        existe = true;
                        break;
                    }
                }
                return Ok(new { Existe = existe });
            }
            return BadRequest();
        }       

        [Route("Integrantes/findbyid/{id}")]
        public IHttpActionResult GetElemento(int id)
        {
            var integranteDb = db.Integrante
                .Where(x => x.Id == id && x.Activo)
                .FirstOrDefault();

            if (integranteDb is null) return NotFound();

            var integranteDto = Utilidades.MapearIntegrante(integranteDb);

            return Ok(integranteDto);
        }

        [HttpPost]
        [Route("Integrantes/new")]
        public IHttpActionResult CrearElemento([FromBody] IntegranteDto integranteNuevo)
        {
            if (integranteNuevo is null)
            {
                return BadRequest();
            }

            var integranteDb = Utilidades.MapearIntegrante(integranteNuevo);
            integranteDb.Activo = true;

            var listaDb = db.Integrante.ToList();


            foreach (var item in listaDb)
            {
                if (item.Dni == integranteDb.Dni)
                {
                    return BadRequest();
                }
            }

            db.Integrante.Add(integranteDb);

            db.SaveChanges();

            return Ok(new { Id = integranteDb.Id });
        }

        [HttpPut]
        [Route("Integrantes/edit/{id}")]
        public IHttpActionResult ModificarElemento(int id, [FromBody] IntegranteDto integrante)
        {
            if (integrante is null) return BadRequest();

            var integranteDb = db.Integrante.Where(x => x.Id == id && x.Activo).FirstOrDefault();

            if (integranteDb is null || integranteDb.Telefono != integrante.Telefono) return NotFound();

            integranteDb = Utilidades.MapearIntegrante(integrante);

            integrante.Id = id;

            db.SaveChanges();

            return Ok(integrante);

        }

        [HttpDelete]
        [Route("Integrantes/delete/{id}")]
        public IHttpActionResult BorrarElemento(int id)
        {
            var integranteDb = db.Integrante.Where(x => x.Id == id && x.Activo).FirstOrDefault();

            if (integranteDb is null) return NotFound();

            integranteDb.Activo = false;
            db.SaveChanges();

            return Ok(new { id });
        }
    }
}
