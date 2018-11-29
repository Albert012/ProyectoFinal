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
                
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");                
                
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
              
        

        protected void PrecioTextBox_TextChanged(object sender, EventArgs e)
        {
            if (CostoTextBox.Text != "" && PrecioTextBox.Text != "")
            {
                var ganacias = CalculosBLL.CalcularGanancias(Utils.ToDecimal(PrecioTextBox.Text), Utils.ToDecimal(CostoTextBox.Text));
                
                GanaciasTextBox.Text = ganacias.ToString();
            }
                
            else
                GanaciasTextBox.Text = "";
        }

        protected void GanaciasTextBox_TextChanged(object sender, EventArgs e)
        {
            if (GanaciasTextBox.Text != "")
            {
                var precio = CalculosBLL.CalcularPrecio(Utils.ToDecimal(CostoTextBox.Text), Utils.ToDecimal(GanaciasTextBox.Text));

            }             
            else
                PrecioTextBox.Text = "";
        }

        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarLinkButton_Click(object sender, EventArgs e)
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
                    Utils.MostrarMensaje(this, "No Guardado", "Fallo!!", "warning");
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
                    Utils.MostrarMensaje(this, "No Modificado", "Fallo!!", "warning");
                    Limpiar();
                }

            }
        }

        protected void EliminarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Productos> repositorio = new Repositorio<Productos>();
            Productos producto = repositorio.Buscar(Utils.ToInt(ProductoIdTextBox.Text));

            if (producto != null)
            {
                repositorio.Eliminar(producto.ProductoId);
                Utils.MostrarMensaje(this, "Eliminado", "Exito!!", "success");
                Limpiar();
            }
            else
            {
                Utils.MostrarMensaje(this, "No Eliminado", "Fallo!!", "warning");
                Limpiar();
            }
        }

        protected void CostoCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Utils.ToDecimal(CostoTextBox.Text) > Utils.ToDecimal(PrecioTextBox.Text))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void PrecioCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Utils.ToDecimal(PrecioTextBox.Text) < Utils.ToDecimal(CostoTextBox.Text))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    }
}