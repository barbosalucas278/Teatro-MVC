using Repositorios.Dominio.ContextConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Modelos.Dominio.ContextConfig
{
    public class IntegranteInstrumentoPuestoEventoConfig : EntidadBaseConfig<IntegranteInstrumentoPuestoEvento>
    {
        public IntegranteInstrumentoPuestoEventoConfig()
        {
            Property(i => i.EventoId)
                .IsRequired();
            Property(i => i.PuestoId)
                .IsRequired();
            Property(i => i.IntegranteId)
                .IsRequired();
            Property(i => i.InstrumentoId)
                .IsRequired();

            //Relaciones

            HasRequired(i => i.Evento)
                 .WithMany(x => x.IntegranteInstrumentoPuestoEventos)
                 .HasForeignKey(i => i.EventoId);
            HasRequired(i => i.Puesto)
                 .WithMany(x => x.IntegranteInstrumentoPuestoEventos)
                 .HasForeignKey(i => i.PuestoId);
            HasRequired(i => i.Integrante)
                 .WithMany(x => x.IntegranteInstrumentoPuestoEventos)
                 .HasForeignKey(i => i.IntegranteId);
            HasRequired(i => i.Instrumento)
                 .WithMany(x => x.IntegranteInstrumentoPuestoEventos)
                 .HasForeignKey(i => i.InstrumentoId);
        }
    }
}
