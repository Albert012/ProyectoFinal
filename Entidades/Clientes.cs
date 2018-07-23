using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Cedula { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        //public Decimal Ingresos { get; set; }
        //public Decimal Balance { get; set; }


        public Clientes()
        {
            ClienteId = 0;
            Fecha = DateTime.Now;
            Nombres = string.Empty;
            Direccion = string.Empty;
            Cedula = string.Empty;
            Sexo = string.Empty;
            Telefono = string.Empty;
            //Ingresos = 0;
            //Balance = 0;
        }

    }
}
