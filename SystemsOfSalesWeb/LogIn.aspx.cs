using BLL;


using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemsOfSalesWeb.UI.Registros;
using SystemsOfSalesWeb.Utilitarios;

namespace SystemsOfSalesWeb
{
    public partial class LogIn : System.Web.UI.Page
    {
        private Usuarios usuario = new Usuarios();
        private Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
        List<Usuarios> userList = new List<Usuarios>();
        private static string tipoUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                EmailTextBox.Focus();

            }
        }

        private void Limpiar()
        {
            EmailTextBox.Text = "";
            PassTextBox.Text = "";
            EmailTextBox.Focus();
        }

        public static string RetornarTipoUser()
        {
            return tipoUsuario;
        }

        protected void LoginLinkButton_Click(object sender, EventArgs e)
        {
            userList = repositorio.GetList(u => u.Email.Equals(EmailTextBox.Text) && u.Contrasena.Equals(PassTextBox.Text));
            usuario = (userList != null && userList.Count > 0) ? userList[0] : null;

            if (usuario != null)
            {
                tipoUsuario = usuario.TipoUsuario;
                FormsAuthentication.RedirectFromLoginPage(usuario.NombreUsuario, true);
            }
            else
            {
                Utils.MostrarMensaje(this, "Esta Cuenta No Existe", "Error", "error");
                Limpiar();
            }



        }
    }
}