using Repositorios.Modelos.Dominio;
using Repositorios.Modelos.Dominio.ContextConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Teatro_App.Models
{
    public class ContextConfig : DbContext
    {
        public ContextConfig() : base("name=TeatroApp")
        {
        }
        public virtual DbSet<Integrante> Integrantes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new IntegranteConfig());
        }
    }
}