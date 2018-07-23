using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class TiposUsuarios
    {
        public int TipoId { get; set; }
        public string Descripcion { get; set; }

        public TiposUsuarios()
        {
            TipoId = 0;
            Descripcion = string.Empty;
        }

    }
}
