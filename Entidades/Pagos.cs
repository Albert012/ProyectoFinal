using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Pagos
    {
        [Key]
        public int PagoId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public Decimal Total { get; set; }

        public Pagos()
        {
            PagoId = 0;
            Fecha = DateTime.Now;
            ClienteId = 0;
            Nombres = string.Empty;
            Total = 0;
        }


    }
}
