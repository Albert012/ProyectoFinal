using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    [Serializable]
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string TipoUsuario { get; set; }
        public string Contrasena { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;
            Fecha = DateTime.Now;            
            Email = string.Empty;
            NombreUsuario = string.Empty;
            TipoUsuario = string.Empty;
            Contrasena = string.Empty;
        }

        public Usuarios(int usuarioId, string usuario, string email, string tipoUsuario, string contrasena)
        {
            UsuarioId = usuarioId;            
            Email = email;
            TipoUsuario = tipoUsuario;
            Contrasena = contrasena;
        }
    }
}
