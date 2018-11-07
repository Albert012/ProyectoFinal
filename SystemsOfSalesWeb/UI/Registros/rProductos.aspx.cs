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
    public partial class rProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenaDropDown();

                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                FechaInventarioTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                
                int id = Utils.ToInt(Request.QueryString["id"]);

                if(id > 0)
                {
                    Repositorio<Productos> repositorio = new Repositorio<Productos>();
                    var producto = repositorio.Buscar(id);

                    if (producto == null)
                        Utils.MostrarMensaje(this, "No Hay Resultado", "Error", "error");
                    else
                        LlenaCampos(producto);
                }
            }
            else
            {
                LlenaDropDown();
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Productos> repositorio = new Repositorio<Productos>();
            Productos producto = repositorio.Buscar(Utils.ToInt(ProductoIdTextBox.Text));

            if (producto == null)
            {
                if (repositorio.Guardar(LlenaClase()))
                {
                    Utils.MostrarMensaje(this, "Guardado", "Exito!!", "success");
                    Limpiar();
                }
                else
                {
                    Utils.MostrarMensaje(this, "No Guardado", "Fallo!!", "error");
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
                    Utils.MostrarMensaje(this, "No Modificado", "Fallo!!", "error");
                    Limpiar();
                }

            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Productos> repositorio = new Repositorio<Productos>();
            Productos producto = repositorio.Buscar(Utils.ToInt(ProductoIdTextBox.Text));

            if(producto != null)
            {
                repositorio.Eliminar(producto.ProductoId);
                Utils.MostrarMensaje(this, "Eliminado", "Exito!!", "success");
                Limpiar();
            }
            else
            {
                Utils.MostrarMensaje(this, "No Eliminado", "Fallo!!", "error");
                Limpiar();
            }

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Productos> repositorio = new Repositorio<Productos>();
            Productos producto = repositorio.Buscar(Utils.ToInt(ProductoIdTextBox.Text));

            if (producto != null)
            {
                Utils.MostrarMensaje(this, "Hay Resultado", "Exito!!", "info");
                Limpiar();
                LlenaCampos(producto);
            }
            else
            {
                Utils.MostrarMensaje(this, "No Hay Resultado", "Fallo!!", "error");
                Limpiar();
            }

        }

        //para el modal
        private void LlenaDropDown()
        {
            Repositorio<Productos> repositorio = new Repositorio<Productos>();
            ProductoDropDownList.DataSource = repositorio.GetList(p => true);
            ProductoDropDownList.DataValueField = "ProductoId";
            ProductoDropDownList.DataTextField = "Descripcion";
            ProductoDropDownList.DataBind();
        }




        //Metodos

        private Productos LlenaClase()
        {
            Productos producto = new Productos();

            producto.ProductoId = Utils.ToInt(ProductoIdTextBox.Text);
            producto.FechaRegistro = Utils.ToDateTime(FechaTextBox.Text);
            producto.Descripcion = DescripcionTextBox.Text;
            producto.Costo = Utils.ToDecimal(CostoTextBox.Text);
            producto.Precio = Utils.ToDecimal(PrecioTextBox.Text);
            producto.Ganancias = Utils.ToDecimal( GanaciasTextBox.Text);
            producto.Inventario = Utils.ToInt(InventarioTextBox.Text);

            return producto;
        }

        private void LlenaCampos(Productos productos)
        {
            ProductoIdTextBox.Text = productos.ProductoId.ToString();
            FechaTextBox.Text = productos.FechaRegistro.ToString("yyyy-MM-dd");
            DescripcionTextBox.Text = productos.Descripcion;
            CostoTextBox.Text = productos.Costo.ToString();
            PrecioTextBox.Text = productos.Precio.ToString();
            GanaciasTextBox.Text = productos.Ganancias.ToString();
            InventarioTextBox.Text = productos.Inventario.ToString();
        }

        private void Limpiar()
        {
            ProductoIdTextBox.Text = "";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DescripcionTextBox.Text = "";
            CostoTextBox.Text = "";
            PrecioTextBox.Text = "";
            GanaciasTextBox.Text = "";
            InventarioTextBox.Text = "";

        }

        protected void InventarioLinkButton_Click(object sender, EventArgs e)
        {

            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script> $('#myModal').modal('show');</script>", false);

        }

        private Inventarios LlenaClaseInventario()
        {
            Inventarios inventarios = new Inventarios();

            inventarios.InventarioId = Utils.ToInt(InventarioIdTextBox.Text);            
            inventarios.ProductoId = Utils.ToInt(ProductoDropDownList.SelectedValue);
            inventarios.Descripcion = ProductoDropDownList.Text;
            inventarios.Cantidad = Utils.ToInt(CantidadTextBox.Text);


            return inventarios;
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            InventarioRepositorio repositorio = new InventarioRepositorio();
            Inventarios inventario = repositorio.Buscar(Utils.ToInt(InventarioIdTextBox.Text));

            if (inventario == null)
            {
                if (repositorio.Guardar(LlenaClaseInventario()))
                {
                    Utils.MostrarMensaje(this, "Guardado", "Exito!!", "success");
                    Limpiar();
                }
                else
                {
                    Utils.MostrarMensaje(this, "No Guardado", "Fallo!!", "error");
                    Limpiar();
                }
            }
            else
            {
                if (repositorio.Modificar(LlenaClaseInventario()))
                {
                    Utils.MostrarMensaje(this, "Modificado", "Exito!!", "info");
                    Limpiar();
                }
                else
                {
                    Utils.MostrarMensaje(this, "No Modificado", "Fallo!!", "error");
                    Limpiar();
                }

            }
        }
    }
}