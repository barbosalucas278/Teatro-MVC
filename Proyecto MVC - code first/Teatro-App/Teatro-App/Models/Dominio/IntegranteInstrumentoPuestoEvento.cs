using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatro_App
{
    public class IntegranteInstrumentoPuestoEvento : EntidadBase
    {
        public int EventoId { get; set; }
        public int PuestoId { get; set; }
        public int IntegranteId { get; set; }
        public int InstrumentoId { get; set; }

        public Evento Evento { get; set; }
        public Puesto Puesto { get; set; }
        public Integrante Integrante { get; set; }
        public Instrumento Instrumento { get; set; }
    }
}
