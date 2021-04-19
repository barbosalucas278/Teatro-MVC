using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Teatro_App.Models.Repositorios.RepositoriosEntidades
{
    public class OrquestaRepositorio : Repositorio<Orquesta>, IOrquestaRepositorio
    {
        public OrquestaRepositorio(ContextConfig contexto) : base(contexto)
        {

        }
        public Task<List<Orquesta>> GetByLocalidad(string localidad)
        {
            return _Contexto.Set<Orquesta>().Where(o => o.Localidad == localidad && o.Activo && o.MarcaUso).ToListAsync();
        }

    }
}