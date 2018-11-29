using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    [Serializable]
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Cedula { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public Decimal Balance { get; set; }


        public Clientes()
        {
            ClienteId = 0;
            Fecha = DateTime.Now;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            Direccion = string.Empty;
            Cedula = string.Empty;
            Email = string.Empty;
            Sexo = string.Empty;
            Telefono = string.Empty;            
            Balance = 0;
        }

        public override string ToString()
        {
            return Nombres + Apellidos ;
        }
    }
}
