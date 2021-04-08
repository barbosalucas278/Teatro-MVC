using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace teatro.Models
{
    public class OrquestaDto
    {
        public int Id { get; set; }
        [DisplayName("Orquesta")]
        public string Nombre { get; set; }
        public string Localidad { get; set; }
    }
}