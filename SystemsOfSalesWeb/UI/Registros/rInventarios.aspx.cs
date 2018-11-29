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
    public partial class rInventarios : System.Web.UI.Page
    {
        string condicion = "[Seleccione]";

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                int id = Utils.ToInt(Request.QueryString["id"]);
                LlenaDropDown();
                if (id > 0)
                {
                    InventarioRepositorio repositorio = new InventarioRepositorio();
                    var inventario = repositorio.Buscar(id);

                    if (inventario != null)
                        Utils.MostrarMensaje(this, "No Hay Resultado", "Error", "error");
                    else
                        LlenaCampos(inventario);
                }
            }
        }
        
        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            InventarioRepositorio repositorio = new InventarioRepositorio();
            Inventarios inventario = repositorio.Buscar(Utils.ToInt(InventarioIdTextBox.Text));

            if (IsValid)
            {
                if (inventario != null)
                {
                    Utils.MostrarMensaje(this, "Hay Resultado", "Exito!!", "info");
                    Limpiar();
                    LlenaCampos(inventario);
                }
                else
                {
                    Utils.MostrarMensaje(this, "No Hay Resultado", "Error", "error");
                    Limpiar();
                }
            }



        }

        //Metodos

        private Inventarios LlenaClase()
        {
            Inventarios inventarios = new Inventarios();

            inventarios.InventarioId = Utils.ToInt(InventarioIdTextBox.Text);
            inventarios.Fecha = Utils.ToDateTime(FechaTextBox.Text);
            inventarios.ProductoId = Utils.ToInt(ProductoDropDownList.SelectedValue);
            inventarios.Descripcion = ProductoDropDownList.Text;
            inventarios.Cantidad = Utils.ToInt(CantidadTextBox.Text);


            return inventarios;
        }

        private void LlenaCampos(Inventarios inventario)
        {
            InventarioIdTextBox.Text = inventario.InventarioId.ToString();
            FechaTextBox.Text = inventario.Fecha.ToShortDateString();
            ProductoDropDownList.Text = inventario.ProductoId.ToString();
            CantidadTextBox.Text = inventario.Cantidad.ToString();
        }

        private void LlenaDropDown()
        {
            Repositorio<Productos> repositorio = new Repositorio<Productos>();
            ProductoDropDownList.DataSource = repositorio.GetList(p => true);
            ProductoDropDownList.DataValueField = "ProductoId";
            ProductoDropDownList.DataTextField = "Descripcion";
            ProductoDropDownList.AppendDataBoundItems = true;
            ProductoDropDownList.DataBind();
        }

        private void Limpiar()
        {
            InventarioIdTextBox.Text = "";
            FechaTextBox.Text  = DateTime.Now.ToString("yyyy-MM-dd");
            ProductoDropDownList.SelectedIndex = 0;
            CantidadTextBox.Text = "";

        }

        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarLinkButton_Click(object sender, EventArgs e)
        {
            InventarioRepositorio repositorio = new InventarioRepositorio();
            Inventarios inventario = repositorio.Buscar(Utils.ToInt(InventarioIdTextBox.Text));

            if (IsValid)
            {
                if (inventario == null)
                {
                    if (repositorio.Guardar(LlenaClase()))
                    {
                        Utils.MostrarMensaje(this, "Guardado", "Exito!!", "success");
                        Limpiar();
                    }
                    else
                    {
                        Utils.MostrarMensaje(this, "No Guardado", "Error", "error");
                        Limpiar();
                    }
                }
                else
                {
                    if (repositorio.Modificar(LlenaClase()))
                    {
                        Utils.MostrarMensaje(this, "Modificado", "Exito!!", "info");
                        Limpiar();
                    }
                    else
                    {
                        Utils.MostrarMensaje(this, "No Modificado", "Error", "error");
                        Limpiar();
                    }

                }
            }
        }

        protected void EliminarLinkButton_Click(object sender, EventArgs e)
        {
            InventarioRepositorio repositorio = new InventarioRepositorio();
            Inventarios inventario = repositorio.Buscar(Utils.ToInt(InventarioIdTextBox.Text));

            if (IsValid)
            {
                if (inventario != null)
                {
                    repositorio.Eliminar(inventario.InventarioId);
                    Utils.MostrarMensaje(this, "Eliminado", "Exito!!", "success");
                    Limpiar();
                }
                else
                {
                    Utils.MostrarMensaje(this, "No Eliminado", "Error", "error");
                    Limpiar();
                }
            }
        }

        protected void CVProducto_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Equals(condicion))
                args.IsValid = false;
            else
                args.IsValid = true;
        }
    }
}