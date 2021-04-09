using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Dominio
{
    class Context : DbContext
    {
        public Context() : base("name=Teatro-App")
        {
        }       
    }
}
