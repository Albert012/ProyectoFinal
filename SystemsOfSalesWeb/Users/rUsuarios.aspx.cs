using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemsOfSalesWeb.Utilitarios;

namespace SystemsOfSalesWeb
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected Usuarios usuario = new Usuarios();
        protected Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                NombreTextBox.Focus();
            }
        }

        protected void GuardarLinkButton_Click(object sender, EventArgs e)
        {

        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ConfirmarTextBox.Text != PassTextBox.Text)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        private void Limpiar()
        {
            NombreTextBox.Text = "";
            UsuarioTextBox.Text = "";
            EmailTextBox.Text = "";
            PassTextBox.Text = "";
            ConfirmarTextBox.Text = "";
            NombreTextBox.Focus();
        }

        private Usuarios LlenaClase()
        {
            usuario.NombreUsuario = NombreTextBox.Text;
            usuario.Usuario = UsuarioTextBox.Text;
            usuario.Email = EmailTextBox.Text;
            usuario.Contrasena = PassTextBox.Text;
            usuario.TipoUsuario = Convert.ToString(TipoUsuario.Cliente);
            return usuario;
        }

        protected void RegistrarLinkButton_Click(object sender, EventArgs e)
        {
            //usuario = repositorio.Buscar(Utils.ToInt(UsuarioIdTextBox.Text));

            if (IsValid)
            {

                if (repositorio.Guardar(LlenaClase()))
                {
                    Utils.MostrarMensaje(this, "Guardado", "Exito!!", "success");
                    Limpiar();
                    Response.Redirect("../LogIn.aspx");
                }
                else
                {
                    Utils.MostrarMensaje(this, "No Guardado", "Advertencia", "warning");
                    Limpiar();
                }
            }
        }
    }
}