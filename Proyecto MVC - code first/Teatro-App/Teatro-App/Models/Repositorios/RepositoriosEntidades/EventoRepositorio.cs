using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Teatro_App.Models.Repositorios.RepositoriosEntidades
{
    public class EventoRepositorio : Repositorio<Evento>, IEventoRepositorio
    {
        public EventoRepositorio(ContextConfig context) : base(context)
        {
        }

        public Task<Evento> FindByFecha(string obra)
        {
            throw new NotImplementedException();
        }
    }
}