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
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenaDropDown();

            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                int id = Utils.ToInt(Request.QueryString["id"]);

                if (id > 0)
                {
                    InventarioRepositorio repositorio = new InventarioRepositorio();
                    var inventario = repositorio.Buscar(id);

                    if (inventario != null)
                        MostrarMensaje(TiposMensaje.Error, "Registro No Encontrado");
                    else
                        LlenaCampos(inventario);
                }
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            InventarioRepositorio repositorio = new InventarioRepositorio();
            Inventarios inventario = repositorio.Buscar(Utils.ToInt(InventarioIdTextBox.Text));

            if (inventario == null)
            {
                if (repositorio.Guardar(LlenaClase()))
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
                if (repositorio.Modificar(LlenaClase()))
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


        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            InventarioRepositorio repositorio = new InventarioRepositorio();
            Inventarios inventario = repositorio.Buscar(Utils.ToInt(InventarioIdTextBox.Text));

            if (inventario != null)
            {
                repositorio.Eliminar(inventario.InventarioId);
                MostrarMensaje(TiposMensaje.Sucess, "Eliminado Correctamente");
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
            InventarioRepositorio repositorio = new InventarioRepositorio();
            Inventarios inventario = repositorio.Buscar(Utils.ToInt(InventarioIdTextBox.Text));

            if(inventario != null)
            {
                Limpiar();
                LlenaCampos(inventario);
            }
            else
            {
                MostrarMensaje(TiposMensaje.Error, "No Se Pudo Encontrar");
                Limpiar();
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
            ProductoDropDownList.DataBind();
        }

        private void Limpiar()
        {
            InventarioIdTextBox.Text = "";
            FechaTextBox.Text = "";
            ProductoDropDownList.SelectedIndex = 0;
            CantidadTextBox.Text = "";

        }

        void MostrarMensaje(TiposMensaje tipo, string msj)
        {
            ErroLabel.Text = msj;
            if (tipo == TiposMensaje.Sucess)
                ErroLabel.CssClass = "alert-success";
            else
                ErroLabel.CssClass = "alert-danger";
        }

    }
}