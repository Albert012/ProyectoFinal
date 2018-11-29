using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    [Serializable]
    public class Facturas
    {
        [Key]
        public int FacturaId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal Itbis { get; set; }
        public Decimal Total { get; set; }
        public Decimal Efectivo { get; set; }
        public Decimal Devuelta { get; set; }


        public virtual List<FacturasDetalles> Detalles { get; set; }
       

        public Facturas()
        {
            FacturaId = 0;
            Fecha = DateTime.Now;
            ClienteId = 0;
            SubTotal = 0;
            Itbis = 0;
            Total = 0;
            Efectivo = 0;
            Devuelta = 0;
            this.Detalles = new List<FacturasDetalles>();
        }

        public void AgregarDetalle(int id, int facturaId, int productoId, string descripcion,  int cantidad, decimal precio, decimal importe)
        {
            this.Detalles.Add(new FacturasDetalles(id, facturaId, productoId, descripcion, cantidad, precio, importe));
        }

    }
}
