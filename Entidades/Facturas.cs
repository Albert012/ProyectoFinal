using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Facturas
    {
        [Key]
        public int FacturaId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal Itbis { get; set; }
        public Decimal Total { get; set; }        

        //public virtual List<FacturasDetalles> Detalles { get; set; }
        [Browsable(false)]
        public virtual ICollection<FacturasDetalles> Detalles { get; set; }

        public Facturas()
        {            
            this.Detalles = new List<FacturasDetalles>();
        }

        //public Facturas(int facturaId, DateTime fecha, int clienteId, Decimal subTotal, Decimal itbis, Decimal total)
        //{
        //    FacturaId = facturaId;
        //    Fecha = fecha;
        //    ClienteId = clienteId;
        //    SubTotal = subTotal;
        //    Itbis = itbis;
        //    Total = Total;
            
        //}

        public void AgregarDetalle(int id, int facturaId, int productoId , int cantidad, Decimal precio, Decimal importe)
        {
            this.Detalles.Add(new FacturasDetalles(id, facturaId, productoId,  cantidad, precio, importe));
        }
    }
}
