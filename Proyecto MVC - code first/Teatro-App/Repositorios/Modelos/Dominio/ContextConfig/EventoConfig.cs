using Repositorios.Dominio.ContextConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Modelos.Dominio.ContextConfig
{
    public class EventoConfig : EntidadBaseConfig<Evento>
    {
        public EventoConfig()
        {
            Property(e => e.OrquestaId)
                .IsRequired();

            Property(e => e.Obra)
                .IsRequired()
                .HasMaxLength(200);

            Property(e => e.Dia)
                .IsRequired()
                .HasColumnName("datetime2");

            //Relaciones

            HasRequired(e => e.Orquesta)
                .WithMany(o => o.Eventos)
                .HasForeignKey(e => e.OrquestaId);

        }
    }
}
