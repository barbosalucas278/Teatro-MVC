using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatro_App
{
    public class IntegranteConfig : EntidadBaseConfig<Integrante>
    {
        public IntegranteConfig()
        {
            ToTable("Integrante");
            Property(i => i.Nombre).HasMaxLength(150).IsRequired();
            Property(i => i.Apellido).HasMaxLength(150).IsRequired();
            Property(i => i.Edad).IsRequired();
            Property(i => i.Telefono).HasMaxLength(20).IsRequired();
            Property(i => i.Dni).HasMaxLength(15).IsRequired();

        }
    }
}
