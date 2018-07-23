using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Generos
    {
        public int GeneroId { get; set; }
        public string Descripcion { get; set; }

        public Generos()
        {
            GeneroId = 0;
            Descripcion = string.Empty;
        }


    }
}
