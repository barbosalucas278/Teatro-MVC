using Repositorios.Dominio.ContextConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Modelos.Dominio.ContextConfig
{
    public class OrquestaConfig : EntidadBaseConfig<Orquesta>
    {
        public OrquestaConfig()
        {
            Property(o => o.Nombre)
                .IsRequired()
                .HasMaxLength(150);

            Property(o => o.Localidad)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
