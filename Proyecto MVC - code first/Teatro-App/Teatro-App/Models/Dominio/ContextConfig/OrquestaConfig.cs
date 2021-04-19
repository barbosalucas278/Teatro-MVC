using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatro_App
{
    public class OrquestaConfig : EntidadBaseConfig<Orquesta>
    {
        public OrquestaConfig()
        {

            Property(o => o.Localidad)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
