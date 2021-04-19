using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatro_App
{
    public class Integrante : EntidadBase
    {
        public Integrante()
        {
            IntegranteInstrumentoPuestoEventos = new HashSet<IntegranteInstrumentoPuestoEvento>();
        }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Telefono { get; set; }
        public string Dni { get; set; }
        public virtual ICollection<IntegranteInstrumentoPuestoEvento> IntegranteInstrumentoPuestoEventos { get; set; }
    }
}
