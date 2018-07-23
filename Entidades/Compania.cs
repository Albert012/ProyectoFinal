using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Compania
    {
        [Key]
        public int CompaniaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public string Eslogan { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string RNC { get; set; }

        public Compania()
        {
            CompaniaId = 0;
            Fecha = DateTime.Now;
            Nombre = string.Empty;
            Eslogan = string.Empty;
            Direccion = string.Empty;
            Email = string.Empty;
            Telefono = string.Empty;
            RNC = string.Empty;

        }
    }
}
