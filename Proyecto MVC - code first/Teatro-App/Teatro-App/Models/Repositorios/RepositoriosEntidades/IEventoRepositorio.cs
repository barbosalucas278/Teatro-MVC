using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatro_App.Models.Repositorios.RepositoriosEntidades
{
    interface IEventoRepositorio
    {
        Task<Evento> FindByFecha(string obra);
    }
}
