using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teatro_App.Models.Repositorios.RepositoriosEntidades;

namespace Teatro_App
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ContextConfig _Contexto;
        public IntegranteRepositorio Integrantes { get; private set; }
        public EventoRepositorio Eventos { get; private set; }
        public InstrumentoRepositorio Instrumentos { get; set; }
        public OrquestaRepositorio Orquesta { get; set; }
        public PuestoRepositorio Puestos { get; set; }
        public IntegranteInstrumentoPuestoEventoRepositorio IntegranteInstrumentoPuestoEventos { get; set; }
        public UnidadTrabajo()
        {
            _Contexto = new ContextConfig();
            Integrantes = new IntegranteRepositorio(_Contexto);
            Eventos = new EventoRepositorio(_Contexto);
            Instrumentos = new InstrumentoRepositorio(_Contexto);
            Orquesta = new OrquestaRepositorio(_Contexto);
            Puestos = new PuestoRepositorio(_Contexto);
            IntegranteInstrumentoPuestoEventos = new IntegranteInstrumentoPuestoEventoRepositorio(_Contexto);
        }
        public Task<int> Complete()
        {
            return _Contexto.SaveChangesAsync();
        }

        public void Dispose()
        {
            _Contexto.Dispose();
        }
    }
}

