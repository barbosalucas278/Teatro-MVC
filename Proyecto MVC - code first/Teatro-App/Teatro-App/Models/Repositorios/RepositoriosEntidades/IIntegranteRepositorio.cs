using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatro_App.Models.Repositorios.RepositoriosEntidades
{
    interface IIntegranteRepositorio
    {
        Task<Integrante> GetByDni(string dni);
        Task<Integrante> GetByTelefono(string telefono);
        Task<List<Integrante>> GetByApellido(string apellido);
    }
}
