using Repositorios.Modelos.Dominio;
using Repositorios.Modelos.Dominio.ContextConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Modelos
{
    public class ContextConfig : DbContext
    {
        public ContextConfig() : base("name=TeatroApp")
        {
        }
        public virtual DbSet<Integrante> Integrante { get; set; }
        public virtual DbSet<Puesto> Puesto { get; set; }
        public virtual DbSet<Instrumento> Instrumento { get; set; }
        public virtual DbSet<Orquesta> Orquesta { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<IntegranteInstrumentoPuestoEvento> IntegranteInstrumentoPuestoEvento { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new IntegranteConfig());
            modelBuilder.Configurations.Add(new PuestoConfig());
            modelBuilder.Configurations.Add(new InstrumentoConfig());
            modelBuilder.Configurations.Add(new OrquestaConfig());
            modelBuilder.Configurations.Add(new EventoConfig());
            modelBuilder.Configurations.Add(new IntegranteInstrumentoPuestoEventoConfig());
        }
    }
}
