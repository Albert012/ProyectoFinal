using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{   
    public class Inventarios
    {
        [Key]
        public int InventarioId { get; set; }
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }

        public Inventarios()
        {
            InventarioId = 0;
            ProductoId = 0;
            Descripcion = string.Empty;
            Fecha = DateTime.Now;
            Cantidad = 0;
        }


    }
}
