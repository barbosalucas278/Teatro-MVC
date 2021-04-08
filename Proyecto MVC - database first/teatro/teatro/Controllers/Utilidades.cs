using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using teatro.Models;

namespace teatro.Controllers
{
    public static class Utilidades
    {
        /// <summary>
        /// Mapea un Integrante en un IntegranteDto
        /// </summary>
        /// <param name="integrante">Integrante de dominio</param>
        /// <returns></returns>
        public static IntegranteDto MapearIntegrante(Integrante integrante)
        {
            var integranteDto = new IntegranteDto
            {
                Nombre = integrante.Nombre,
                Apellido = integrante.Apellido,
                Edad = integrante.Edad,
                Telefono = integrante.Telefono,
                Id = integrante.Id,
                Dni = integrante.Dni
            };
            return integranteDto;
        }
        /// <summary>
        /// Mapea un IntegranteDto a un Integrante de dominio.
        /// </summary>
        /// <param name="integranteDto">integranteDto</param>
        /// <returns></returns>
        public static Integrante MapearIntegrante(IntegranteDto integranteDto)
        {
            var integranteDb = new Integrante
            {
                Nombre = integranteDto.Nombre,
                Apellido = integranteDto.Apellido,
                Edad = integranteDto.Edad,
                Telefono = integranteDto.Telefono,
                Dni = integranteDto.Dni
            };

            return integranteDb;
        }


        /// <summary>
        /// Mapea una Orquesta a una OrquestaDto
        /// </summary>
        /// <param name="orquesta">Orquesta de dominio</param>
        /// <returns></returns>
        public static OrquestaDto MapearOrquesta(Orquesta orquesta)
        {
            var orquestaDto = new OrquestaDto
            {
                Id = orquesta.Id,
                Localidad = orquesta.Localidad,
                Nombre = orquesta.Nombre
            };

            return orquestaDto;
        }


        public static EventoDto MapearEvento(Evento eventoDb)
        {
            EventoDto eventoDto = new EventoDto
            {
                Id = eventoDb.id,
                Dia = eventoDb.Dia,
                Obra = eventoDb.Obra,
                Orquesta = new OrquestaDto { Id = eventoDb.Orquesta.Id, Nombre = eventoDb.Orquesta.Nombre, Localidad = eventoDb.Orquesta.Localidad }
            };

            return eventoDto;
        }

        public static Evento MapearEvento(EventoDto eventoDto)
        {
            Evento eventoDb = new Evento
            {
                Dia = eventoDto.Dia,
                Obra = eventoDto.Obra,
                OrquestaId = eventoDto.Orquesta.Id,
                Activo = true
            };

            return eventoDb;
        }
    }
}