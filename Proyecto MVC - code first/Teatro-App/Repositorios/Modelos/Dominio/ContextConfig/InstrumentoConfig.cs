using Repositorios.Dominio.ContextConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Modelos.Dominio.ContextConfig
{
    public class InstrumentoConfig : EntidadBaseConfig<Instrumento>
    {
        public InstrumentoConfig()
        {
            Property(i => i.Nombre)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
