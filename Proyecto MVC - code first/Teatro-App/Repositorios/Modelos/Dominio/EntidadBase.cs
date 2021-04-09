﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class EntidadBase
    {
        public EntidadBase()
        {
            FechaCreacion = DateTime.Now;
            Activo = true;
            MarcaUso = true;
        }
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaBaja { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool Activo { get; set; }
        public bool MarcaUso { get; set; }
    }
}
