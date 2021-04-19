using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatro_App.Models.Repositorios.RepositoriosEntidades
{
    interface IIntegranteInstrumentoPuestoEventoRepositorio
    {
        Task<IntegranteInstrumentoPuestoEvento> GetIntegrante(int id);
    }
}
