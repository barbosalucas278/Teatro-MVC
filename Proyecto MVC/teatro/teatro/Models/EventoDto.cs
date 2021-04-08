using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace teatro.Models
{
    public class EventoDto
    {
        public int Id { get; set; }
        public OrquestaDto Orquesta { get; set; }
        public string Obra { get; set; }
        public System.DateTime Dia { get; set; }
    }
}