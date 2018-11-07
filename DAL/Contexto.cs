using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Entidades;

namespace DAL
{
    public class Contexto : DbContext
        
    {
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Inventarios> Inventarios { get; set; }
        public DbSet<Pagos> Pagos { get; set; }
        public DbSet<Facturas> Facturas { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}
