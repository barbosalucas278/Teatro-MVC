﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Modelos.Dominio
{
    public class Puesto : EntidadBase
    {
        public Puesto()
        {
            IntegranteInstrumentoPuestoEventos = new HashSet<IntegranteInstrumentoPuestoEvento>();
        }
        public string  Nombre { get; set; }
        //Relaciones
        public virtual ICollection<IntegranteInstrumentoPuestoEvento> IntegranteInstrumentoPuestoEventos { get; set; }
    }
}
