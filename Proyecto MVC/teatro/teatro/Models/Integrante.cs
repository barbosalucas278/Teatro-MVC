//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace teatro.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Integrante
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Integrante()
        {
            this.IntegranteInstrumentoPuestoEvento = new HashSet<IntegranteInstrumentoPuestoEvento>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public Nullable<int> Telefono { get; set; }
        public bool Activo { get; set; }
        public string Dni { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IntegranteInstrumentoPuestoEvento> IntegranteInstrumentoPuestoEvento { get; set; }
    }
}
