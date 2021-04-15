using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatro_App
{
    public class Orquesta : EntidadBase
    {
        public Orquesta()
        {
            Eventos = new HashSet<Evento>();
        }
        public string Nombre { get; set; }
        public string Localidad { get; set; }
        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
