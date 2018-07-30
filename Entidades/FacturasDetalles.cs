using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class FacturasDetalles
    {
        [Key]
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }       
        public int Cantidad { get; set; }
        public Decimal Precio { get; set; }
        public Decimal Importe { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Productos Producto { get; set; }


        public FacturasDetalles()
        {
            Id = 0;
            FacturaId = 0; 
        }

        public FacturasDetalles(int id, int facturaId, int productoId, int cantidad, decimal precio, decimal importe)
        {
            this.Id = id;
            this.FacturaId = facturaId;
            this.ProductoId = productoId;
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.Importe = importe;
        }
    }
}
