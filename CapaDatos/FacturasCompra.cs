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
    
    public partial class FacturasCompra
    {
        public int FacturaCompraID { get; set; }
        public int OrdenCompraID { get; set; }
        public string NCF { get; set; }
        public System.DateTime FechaFactura { get; set; }
        public int TipoDePagoID { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ITBIS { get; set; }
        public System.DateTime FechaVencimiento { get; set; }
    
        public virtual OrdenesCompra OrdenesCompra { get; set; }
        public virtual TiposPago TiposPago { get; set; }
    }
}
