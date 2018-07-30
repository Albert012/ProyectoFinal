using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ContextoRepositorio<T> : DbContext where T : class
    {
        public DbSet<T> Entity { get; set; }
        public DbSet<FacturasDetalles> Detalle { get; set; }
        
        public ContextoRepositorio() : base("ConStr")
        {

        }


    }
}
