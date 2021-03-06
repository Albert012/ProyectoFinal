﻿using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemsOfSalesWeb.UI.Consultas;
using SystemsOfSalesWeb.Utilitarios;

namespace SystemsOfSalesWeb.UI.Registros
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        string condicion = "Seleccione";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarDropDown();
                //FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //int id = Utils.ToInt(Request.QueryString["id"]);

                //if (id > 0)
                //{
                Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
                var usuario = repositorio.Buscar(cUsuarios.id_Usuario);

                if (usuario == null)
                    Utils.MostrarMensaje(this, "No Hay Resultado", "Error", "error");
                else
                    LlenaCampos(usuario);
                //}
            }

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
            Usuarios usuarios = repositorio.Buscar(Utils.ToInt(UsuarioIdTextBox.Text));

            if (IsValid)
            {
                if (usuarios != null)
                {
                    Limpiar();
                    LlenaCampos(usuarios);
                }
                else
                {
                    Limpiar();
                    Utils.MostrarMensaje(this, "No Hay Resultado", "Error", "error");
                }
            }
        }


        //Metodos

        private void LlenarDropDown()
        {


            TipoUsuarioDropDownList.DataSource = Enum.GetValues(typeof(TipoUsuario));
            TipoUsuarioDropDownList.AppendDataBoundItems = true;
            TipoUsuarioDropDownList.DataBind();

        }

        private Usuarios LLenaClase()
        {
            return new Usuarios
            {
                UsuarioId = Utils.ToInt(UsuarioIdTextBox.Text),
                Fecha = Utils.ToDateTime(FechaTextBox.Text),
                Email = EmailTextBox.Text,
                NombreUsuario = NombreTextBox.Text,
                Usuario = UserNameTextBox.Text,
                Contrasena = ContrasenaTextBox.Text,
                TipoUsuario = TipoUsuarioDropDownList.Text
            };


        }

        private void LlenaCampos(Usuarios usuario)
        {
            Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
            usuario = repositorio.Buscar(cUsuarios.id_Usuario);
            if (usuario != null)
            {
                UsuarioIdTextBox.Text = usuario.UsuarioId.ToString();
                FechaTextBox.Text = usuario.Fecha.ToString("yyyy-MM-dd");
                EmailTextBox.Text = usuario.Email; ;
                ContrasenaTextBox.Text = usuario.Contrasena;
                NombreTextBox.Text = usuario.NombreUsuario;
                UserNameTextBox.Text = usuario.Usuario;
                TipoUsuarioDropDownList.Text = usuario.TipoUsuario;
                ContrasenaTextBox.Text = usuario.Contrasena;
            }


        }

        private void Limpiar()
        {
            UsuarioIdTextBox.Text = "";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            EmailTextBox.Text = "";
            NombreTextBox.Text = "";
            ContrasenaTextBox.Text = "";
            ConfirmarTextBox.Text = "";
            TipoUsuarioDropDownList.SelectedIndex = 0;
            cUsuarios.id_Usuario = 0;
        }

        protected void CustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ConfirmarTextBox.Text != ContrasenaTextBox.Text)
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

        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
            Usuarios usuarios = repositorio.Buscar(Utils.ToInt(UsuarioIdTextBox.Text));

            if (IsValid)
            {
                if (usuarios != null)
                {
                    if (repositorio.Modificar(LLenaClase()))
                    {
                        Utils.MostrarMensaje(this, "Modificado", "Exito!!", "info");
                        Limpiar();
                    }
                    else
                    {
                        Utils.MostrarMensaje(this, "No Modificado", "Error", "error");
                        Limpiar();
                    }
                    Response.Redirect(@"~\UI\Consultas\cUsuarios.aspx");
                }
                else
                {
                    if (repositorio.Guardar(LLenaClase()))
                    {
                        Utils.MostrarMensaje(this, "Guardado", "Exito!!", "success");
                        Limpiar();
                    }
                    else
                    {
                        Utils.MostrarMensaje(this, "No Guardado", "Error", "error");
                        Limpiar();
                    }
                    Response.Redirect(@"~\UI\Consultas\cUsuarios.aspx");
                }
            }
        }

        protected void EliminarLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~\UI\Consultas\cUsuarios.aspx");

            /* Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
             Usuarios usuarios = repositorio.Buscar(Utils.ToInt(UsuarioIdTextBox.Text));

             if (IsValid)
             {
                 if (usuarios == null)
                 {
                     Utils.MostrarMensaje(this, "No Eliminado", "Error", "error");
                     Limpiar();
                 }
                 else
                 {
                     repositorio.Eliminar(usuarios.UsuarioId);
                     Utils.MostrarMensaje(this, "Eliminado", "Exito!!", "success");
                     Limpiar();
                 }*/

        }



    }
}