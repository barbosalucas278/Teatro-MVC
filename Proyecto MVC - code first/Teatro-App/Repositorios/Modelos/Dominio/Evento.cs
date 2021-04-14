using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Modelos.Dominio
{
    public class Evento : EntidadBase
    {
        public Evento()
        {
            IntegranteInstrumentoPuestoEventos = new HashSet<IntegranteInstrumentoPuestoEvento>();
        }
        public int OrquestaId { get; set; }
        public string Obra { get; set; }
        public DateTime Dia { get; set; }

        //Relaciones

        public Orquesta Orquesta { get; set; }
        public virtual ICollection<IntegranteInstrumentoPuestoEvento> IntegranteInstrumentoPuestoEventos{ get; set; }
    }
}
