using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Teatro_App.Models.Repositorios.RepositoriosEntidades
{
    public class InstrumentoRepositorio : Repositorio<Instrumento>, IInstrumentoRepositorio
    {
        public InstrumentoRepositorio(ContextConfig contexto) : base(contexto)
        {
        }
        
    }
}