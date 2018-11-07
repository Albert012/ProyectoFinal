using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemsOfSalesWeb.Utilitarios;

namespace SystemsOfSalesWeb.UI.Registros
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        string condicion = "Seleccione";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                int id = Utils.ToInt(Request.QueryString["id"]);

                if (id > 0)
                {
                    Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
                    var usuario = repositorio.Buscar(id);

                    if (usuario == null)
                        MostrarMensaje(TiposMensaje.Error, "Registro No Encontrado");
                    else
                        LlenaCampos(usuario);
                }
            }

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();

            Usuarios usuarios = repositorio.Buscar(Utils.ToInt(UsuarioIdTextBox.Text));

            //usuarios = LLenaClase();

            if(usuarios == null)
            {
                if (repositorio.Guardar(LLenaClase()))
                {
                    MostrarMensaje(TiposMensaje.Sucess, "Guardado Correctamente");
                    Limpiar();
                }
                else
                {
                    MostrarMensaje(TiposMensaje.Error, "No Se Pudo Guardar");
                    Limpiar();
                }
            }
            else
            {
                if (repositorio.Modificar(LLenaClase()))
                {
                    MostrarMensaje(TiposMensaje.Sucess, "Modificado Correctamente");
                    Limpiar();
                }
                else
                {
                    MostrarMensaje(TiposMensaje.Error, "No Se Pudo Modificar");
                    Limpiar();
                }

            }


            //bool paso = false;

            //if (usuarios.UsuarioId == 0)
            //    paso = repositorio.Guardar(usuarios);
            //else
            //    paso = repositorio.Modificar(usuarios);


            //if (paso)
            //{
            //    MostrarMensaje(TiposMensaje.Sucess, "Guardado Correctamente");
            //    Limpiar();
            //}
            //else
            //    MostrarMensaje(TiposMensaje.Error, "No Se Pudo Guardar Correctamente");

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
            Usuarios usuarios = repositorio.Buscar(Utils.ToInt(UsuarioIdTextBox.Text));

            if(usuarios != null)
            {
                repositorio.Eliminar(usuarios.UsuarioId);
                MostrarMensaje(TiposMensaje.Sucess, "Guardado Correctamente");
                Limpiar();
            }
            else
            {
                MostrarMensaje(TiposMensaje.Error, "No Se Pudo Eliminar");
                Limpiar();
            }


        }


        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
            Usuarios usuarios = repositorio.Buscar(Utils.ToInt(UsuarioIdTextBox.Text));

            if(usuarios != null)
            {
                Limpiar();
                LlenaCampos(usuarios);
            }
            else
            {
                Limpiar();
                MostrarMensaje(TiposMensaje.Error, "No Se Pudo Encontrar");
            }


        }

        protected void BuscarLinkButton_Click1(object sender, EventArgs e)
        {

        }



        //Metodos


        private Usuarios LLenaClase()
        {
            Usuarios usuario = new Usuarios();
            usuario.UsuarioId = Utils.ToInt(UsuarioIdTextBox.Text);
            usuario.Fecha = Utils.ToDateTime(FechaTextBox.Text);
            usuario.Usuario = UsuarioTextBox.Text;
            usuario.NombreUsuario = NombreTextBox.Text;
            usuario.Contrasena = ContrasenaTextBox.Text;
            usuario.TipoUsuario = TipoUsuarioDropDownList.Text;

            return usuario;
        }

        private void LlenaCampos(Usuarios usuario)
        {
            UsuarioIdTextBox.Text = usuario.UsuarioId.ToString();
            FechaTextBox.Text = usuario.Fecha.ToString();
            UsuarioTextBox.Text = usuario.Usuario;
            NombreTextBox.Text = usuario.NombreUsuario;
            TipoUsuarioDropDownList.Text = usuario.TipoUsuario;
            ContrasenaTextBox.Text = usuario.Contrasena;

        }

        private void Limpiar()
        {
            UsuarioIdTextBox.Text = "";
            FechaTextBox.Text = "";
            UsuarioTextBox.Text = "";
            NombreTextBox.Text = "";
            ContrasenaTextBox.Text = "";
            ConfirmarTextBox.Text = "";
            TipoUsuarioDropDownList.SelectedIndex = 0;
        }

        void MostrarMensaje(TiposMensaje tipo, string mensaje)
        {
            ErrorLabel.Text = mensaje;
            if (tipo == TiposMensaje.Sucess)
                ErrorLabel.CssClass = "alert-success";
            else
                ErrorLabel.CssClass = "alert-danger";
        }

        protected void CustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if(ConfirmarTextBox.Text != ContrasenaTextBox.Text)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Equals(condicion))
                args.IsValid = false;
            else
                args.IsValid = true;
        }


        //Metodos
    }
}