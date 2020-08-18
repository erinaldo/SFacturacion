//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cotizacione
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cotizacione()
        {
            this.DetalleCotizaciones = new HashSet<DetalleCotizacione>();
        }
    
        public int CotizacionID { get; set; }
        public int ClienteID { get; set; }
        public System.DateTime Fecha { get; set; }
        public int UserID { get; set; }
        public bool Facturada { get; set; }
        public Nullable<decimal> DescuentoCliente { get; set; }
        public Nullable<int> TipoPagoID { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCotizacione> DetalleCotizaciones { get; set; }
    }
}
