using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatro_App
{
    public class Instrumento : EntidadBase
    {
        public Instrumento()
        {
            IntegranteInstrumentoPuestoEventos = new HashSet<IntegranteInstrumentoPuestoEvento>();
        }
        public virtual ICollection<IntegranteInstrumentoPuestoEvento> IntegranteInstrumentoPuestoEventos { get; set; }
    }
}
