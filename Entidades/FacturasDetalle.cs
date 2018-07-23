using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class FacturasDetalle
    {
        [Key]
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public int Cantidad { get; set; }
        public Decimal Importe { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal Itbis { get; set; }
        public Decimal Total { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Productos Producto { get; set; }


        public FacturasDetalle()
        {

        }
    }
}
