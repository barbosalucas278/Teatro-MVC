using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace teatro.Models.ViewModels
{
    public class IntegranteViewModel
    {
        public IntegranteDto Integrante { get; set; }
        public List<IntegranteDto> ListaIntegrantes { get; set; }
    }
}