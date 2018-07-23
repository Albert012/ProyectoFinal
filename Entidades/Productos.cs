using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Descripcion { get; set; }
        public Decimal Costo { get; set; }
        public Decimal Precio { get; set; }
        public Decimal Ganancias { get; set; }
        public int Inventario { get; set; }

        public Productos()
        {
            ProductoId = 0;
            FechaRegistro = DateTime.Now;
            Descripcion = string.Empty;
            Costo = 0;
            Precio = 0;
            Ganancias = 0;
            Inventario = 0;
        }
    }
}
