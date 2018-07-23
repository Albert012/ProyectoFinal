using System;
using System.Collections.Generic;
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
        public Decimal Total { get; set; }

        public Facturas()
        {
            FacturaId = 0;
            Fecha = DateTime.Now;
            Total = 0;
        }

    }
}
