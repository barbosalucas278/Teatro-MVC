using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace Repositorios.Modelos.Repositorios
    {
        public class UnidadTrabajo : IUnidadTrabajo
        {
            private readonly ContextConfig Context;
            public Task<int> Complete()
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }

