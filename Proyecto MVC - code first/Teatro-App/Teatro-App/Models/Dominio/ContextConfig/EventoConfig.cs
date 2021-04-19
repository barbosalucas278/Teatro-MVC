using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatro_App
{
    public class EventoConfig : EntidadBaseConfig<Evento>
    {
        public EventoConfig()
        {
            Property(e => e.OrquestaId)
                .IsRequired();            

            Property(e => e.Dia)
                .IsRequired()
                .HasColumnType("datetime2");

            //Relaciones

            HasRequired(e => e.Orquesta)
                .WithMany(o => o.Eventos)
                .HasForeignKey(e => e.OrquestaId);

        }
    }
}
