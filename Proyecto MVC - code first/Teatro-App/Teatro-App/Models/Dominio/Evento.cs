using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatro_App
{
    public class Evento : EntidadBase
    {
        public Evento()
        {
            IntegranteInstrumentoPuestoEventos = new HashSet<IntegranteInstrumentoPuestoEvento>();
        }
        public int OrquestaId { get; set; }
        public DateTime Dia { get; set; }

        //Relaciones

        public Orquesta Orquesta { get; set; }
        public virtual ICollection<IntegranteInstrumentoPuestoEvento> IntegranteInstrumentoPuestoEventos{ get; set; }
    }
}
