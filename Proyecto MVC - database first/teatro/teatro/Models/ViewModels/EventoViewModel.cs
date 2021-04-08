using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace teatro.Models.ViewModels
{
    public class EventoViewModel
    {
        public EventoDto Evento { get; set; }


        public List<EventoDto> ListaEventos { get; set; }


        [DisplayName("Orquesta")]

        public List<OrquestaDto> ListaOrquestas { get; set; }
    }
}