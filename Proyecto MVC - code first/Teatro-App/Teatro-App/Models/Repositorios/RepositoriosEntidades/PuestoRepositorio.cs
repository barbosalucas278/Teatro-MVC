using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teatro_App.Models.Repositorios.RepositoriosEntidades
{
    public class PuestoRepositorio : Repositorio<Puesto>,IPuestoRepositorio
    {
        public PuestoRepositorio(ContextConfig contexto) : base(contexto)
        {

        }
    }
}