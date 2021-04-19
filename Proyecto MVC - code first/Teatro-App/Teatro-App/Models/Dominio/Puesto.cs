using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatro_App
{
    public class Puesto : EntidadBase
    {
        public Puesto()
        {
            IntegranteInstrumentoPuestoEventos = new HashSet<IntegranteInstrumentoPuestoEvento>();
        }
        //Relaciones
        public virtual ICollection<IntegranteInstrumentoPuestoEvento> IntegranteInstrumentoPuestoEventos { get; set; }
    }
}
