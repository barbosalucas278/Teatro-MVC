using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatro_App
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ContextConfig _Contexto;
        public Repositorio<Integrante> Integrantes { get; private set; }
        public UnidadTrabajo()
        {
            _Contexto = new ContextConfig();
            Integrantes = new Repositorio<Integrante>(_Contexto);
        }
        public Task<int> Complete()
        {
            return _Contexto.SaveChangesAsync();
        }

        public void Dispose()
        {
            _Contexto.Dispose();
        }
    }
}

