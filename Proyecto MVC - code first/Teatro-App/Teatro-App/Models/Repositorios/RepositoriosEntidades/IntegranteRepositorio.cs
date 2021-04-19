using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Teatro_App.Models.Repositorios.RepositoriosEntidades
{
    public class IntegranteRepositorio : Repositorio<Integrante>, IIntegranteRepositorio
    {
        public IntegranteRepositorio(ContextConfig contexto) : base(contexto)
        {

        }

        public Task<List<Integrante>> GetByApellido(string apellido)
        {
            return _Contexto.Set<Integrante>()
                .Where(i => i.Apellido == apellido && i.Activo && i.MarcaUso)
                .ToListAsync();
        }

        public Task<Integrante> GetByDni(string dni)
        {
            return _Contexto.Set<Integrante>()
                .Where(i => i.Dni == dni && i.Activo && i.MarcaUso)
                .FirstOrDefaultAsync();
        }

        public Task<Integrante> GetByTelefono(string telefono)
        {
            return _Contexto.Set<Integrante>()
                .Where(i => i.Telefono == telefono && i.Activo && i.MarcaUso)
                .FirstOrDefaultAsync();
        }
    }
}