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
    public class API_EventosController : ApiController
    {
        private readonly Teatro db = new Teatro();

        [Route("Eventos/all")]
        public IHttpActionResult GetEventos()
        {
            //Se utiliza el include para poder traerme todos los registros de de chica tabla sino la api trabajaria de manera lazyloading 
            //que sería que cada vez que necesito un registro hace la consulta automaticamente.(Utilidades.cs Linea 72) 
            //generando muchas consultas a la api (n+1 donde n es igual a cada evento que consulta por su orquesta a la bd)
            var listaEventosDb = db.Evento
                .Include(x => x.Orquesta) 
                .Where(x => x.Activo).OrderByDescending(x => x.id).ToList();

            var eventosDto = listaEventosDb.Select(Utilidades.MapearEvento).ToList();

            return Ok(eventosDto);
        }

        // GET: api/API_Eventos/5
        [Route("Eventos/findbyid/{id}")]
        public IHttpActionResult GetEvento(int id)
        {
            var eventoDb = db.Evento.Find(id);
            if (eventoDb == null)
            {
                return NotFound();
            }

            var eventoDto = Utilidades.MapearEvento(eventoDb);

            return Ok(eventoDto);
        }

        // PUT: api/API_Eventos/5
        [HttpPost]
        [Route("Eventos/new")]
        public IHttpActionResult CrearEvento([FromBody]EventoDto eventoDto)
        {
            if(eventoDto is null)
            {
                return BadRequest();
            }

            Evento eventoDb = Utilidades.MapearEvento(eventoDto);

            var listadoEventosDb = db.Evento.Where(x => x.Activo).ToList();

            //Ciclo la lista de eventos para ver si ya existe el evento
            //FALTA REVISAR NO ROMPE SI HAY UN EVENTO YA EXISTETE IGUAL
            foreach(Evento e in listadoEventosDb)
            {
                if(eventoDb == e)
                {
                    return BadRequest();
                }
            }

            //agrego el evento a la tabla de eventos de la bd
            db.Evento.Add(eventoDb);
            //Guardo los cambios en la db
            db.SaveChanges();

            return Ok(new { Id = eventoDb.id });
        }

        // POST: api/API_Eventos
        [HttpPut]
        [Route("Eventos/edit/{id}")]
        public IHttpActionResult ModificarEvento(int id, [FromBody]EventoDto eventoDto)
        {
            if (eventoDto is null)
            {
                return BadRequest();
            }

            Evento eventoDb = db.Evento.Find(id);

            if(eventoDb is null)
            {
                return NotFound();
            }

            eventoDb.Dia = eventoDto.Dia;
            eventoDb.Obra = eventoDto.Obra;
            eventoDb.OrquestaId = eventoDto.Orquesta.Id;

            db.SaveChanges();

            return Ok(eventoDto);
        }

        // DELETE: api/API_Eventos/5
        [HttpDelete]
        [Route("Eventos/delete/{id}")]
        public IHttpActionResult BorrarEvento(int id)
        {
            Evento eventoDb = db.Evento.Find(id);
            if (eventoDb == null)
            {
                return NotFound();
            }

            eventoDb.Activo = false;

            db.SaveChanges();

            return Ok(new { id });
        }

    }
}