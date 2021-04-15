using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatro_App
{
    public class EntidadBaseConfig<T> : EntityTypeConfiguration<T> where T : EntidadBase
    {
        public EntidadBaseConfig()
        {
            HasKey(e => e.Id);

            Property(e => e.FechaCreacion).IsRequired().HasColumnType("datetime2");
            Property(e => e.FechaBaja).HasColumnType("datetime2");
            Property(e => e.FechaModificacion).HasColumnType("datetime2");
            Property(e => e.UsuarioModificacion).IsRequired().HasMaxLength(150);
            Property(e => e.Activo).IsRequired();
            Property(e => e.MarcaUso).IsRequired();

        }
    }
}
