using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Teatro_App.Models.Repositorios.RepositoriosEntidades
{
    public class IntegranteInstrumentoPuestoEventoRepositorio : Repositorio<IntegranteInstrumentoPuestoEvento>, IIntegranteInstrumentoPuestoEventoRepositorio
    {
        public IntegranteInstrumentoPuestoEventoRepositorio(ContextConfig contexto) : base(contexto)
        {
        }

        public Task<IntegranteInstrumentoPuestoEvento> GetIntegrante(int id)
        {
            return _Contexto.Set<IntegranteInstrumentoPuestoEvento>()
                .Include(x => x.Integrante)
                .Include(x => x.Puesto)
                .Include(x => x.Instrumento)
                .Include(x => x.Evento)
                .Where(x => x.Activo && x.MarcaUso && x.Integrante.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}