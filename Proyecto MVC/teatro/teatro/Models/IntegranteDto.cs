using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace teatro.Models
{
    public class IntegranteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public int? Telefono { get; set; }
        public string Dni { get; set; }

    }
}