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
    public partial class rFacturas : System.Web.UI.Page
    {
        protected Facturas factura = new Facturas();
        private Repositorio<Clientes> repositorioCliente = new Repositorio<Clientes>();
        private Repositorio<Productos> repositorioProducto = new Repositorio<Productos>();
        private FacturaRepositorio FacturaRepositorio = new FacturaRepositorio();

        private List<FacturasDetalles> detalles = new List<FacturasDetalles>();
        private Repositorio<FacturasDetalles> repositorioDetalle = new Repositorio<FacturasDetalles>();

        string condicion = "[Seleccione]";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

                //ViewState["Detalle"] = new FacturasDetalles();
                LlenarDropDownListProductos();
                LlenarDropDownListClientes();
                //BindGrid();
                //ViewState.Add("FDetalle", detalles);
                ViewState["Factura"] = new Facturas();


            }
            /*else
            {
                detalles = (List<FacturasDetalles>)ViewState["FDetalle"];
            }*/
        }

        private void FiltraPrecio()
        {
            if (ProductoDropDownList.Text != condicion)
            {
                int id = Convert.ToInt32(ProductoDropDownList.SelectedValue);
                PrecioTextBox.Text = repositorioProducto.Buscar(id).Precio.ToString();
            }
            else
            {
                PrecioTextBox.Text = "";
            }
        }

        protected void BindGrid()
        {
            FacturaGridView.DataSource = ((Facturas)ViewState["Factura"]).Detalles;
            FacturaGridView.DataBind();
        }

        //private bool Lista()
        //{
        //    return repositorioDetalle.GetList(x => true).Count == 0;
        //}

        private List<FacturasDetalles> ListaVacia()
        {
            List<FacturasDetalles> facturas = new List<FacturasDetalles>();
            facturas.Add(new FacturasDetalles());
            return facturas;
        }

        private Facturas LlenaClase()
        {
            factura = (Facturas)ViewState["Factura"];
            factura.FacturaId = Utils.ToInt(FacturaIdTextBox.Text);
            factura.Fecha = Utils.ToDateTime(FechaTextBox.Text);
            factura.ClienteId = Utils.ToInt(ClienteDropDownList.SelectedValue);
            factura.Total = Utils.ToDecimal(MontoTextBox.Text);
           // factura.Detalles = detalles;
            return factura;
        }

        private void Limpiar()
        {
            FacturaIdTextBox.Text = "";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            ClienteDropDownList.SelectedIndex = 0;
            ProductoDropDownList.SelectedIndex = 0;            
            CantidadTextBox.Text = "";
            PrecioTextBox.Text = "";
            ImporteTextBox.Text = "";
            MontoTextBox.Text = "";
            FacturaGridView.DataSource = null;
            FacturaGridView.DataBind();
            ViewState["Factura"] = null;

            //BindGrid();

        }


        private void LlenarCampos(Facturas facturas)
        {
            ClienteDropDownList.SelectedValue = factura.ClienteId.ToString();
            FacturaGridView.DataSource = factura.Detalles;
            FacturaGridView.DataBind();
            MontoTextBox.Text = factura.Total.ToString();
        }

        private void LlenarDropDownListProductos()
        {
            ProductoDropDownList.DataSource = repositorioProducto.GetList(x => x.Inventario > 0);
            ProductoDropDownList.DataValueField = "ProductoId";
            ProductoDropDownList.DataTextField = "Descripcion";
            ProductoDropDownList.AppendDataBoundItems = true;
            ProductoDropDownList.DataBind();
            FiltraPrecio();

        }

        private void LlenarDropDownListClientes()
        {
            ClienteDropDownList.DataSource = repositorioCliente.GetList(x => true);
            ClienteDropDownList.DataValueField = "ClienteId";
            ClienteDropDownList.DataTextField = "Nombres";
            ClienteDropDownList.AppendDataBoundItems = true;
            ClienteDropDownList.DataBind();
        }
        private string SubTotal()
        {
            decimal monto = 0;
            foreach (var item in factura.Detalles )
            {
                monto += CalculosBLL.CalcularSubTotal(item.Importe);
            }
            return MontoTextBox.Text = monto.ToString();
        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                /*if (FacturaGridView.Rows.Count != 0)
                {
                    factura.Detalles = (List<FacturasDetalles>)ViewState["FDetalle"];

                }
              
                 var facturas = FacturaRepositorio.Buscar(Utils.ToInt(FacturaIdTextBox.Text));

                 if(facturas == null)
                 {
                     if(factura.Detalles.Exists(x=> x.ProductoId.Equals(Utils.ToInt(ProductoDropDownList.SelectedValue))))
                     {
                         var producto = factura.Detalles.Where(x => x.ProductoId.Equals(Utils.ToInt(ProductoDropDownList.SelectedValue)));

                     }

                     if (((FacturasDetalles)ViewState["Detalle"]).Id != 0)
                     {
                         factura.Detalles.Add(new FacturasDetalles(((FacturasDetalles)ViewState["Detalle"]).Id, Utils.ToInt(FacturaIdTextBox.Text), Utils.ToInt(ProductoDropDownList.SelectedValue), ProductoDropDownList.Text, Utils.ToInt(CantidadTextBox.Text), Utils.ToDecimal(PrecioTextBox.Text), Utils.ToDecimal(ImporteTextBox.Text)));
                     }
                     else
                         factura.Detalles.Add(new FacturasDetalles(0, Utils.ToInt(FacturaIdTextBox.Text), Utils.ToInt(ProductoDropDownList.SelectedValue), ProductoDropDownList.SelectedItem.ToString(), Utils.ToInt(CantidadTextBox.Text), Utils.ToDecimal(PrecioTextBox.Text), Utils.ToDecimal(ImporteTextBox.Text)));
                     ViewState["Detalle"] = new FacturasDetalles();
                 }
                 else
                 {
                     factura.Detalles.Add(new FacturasDetalles(0, Utils.ToInt(FacturaIdTextBox.Text), Utils.ToInt(ProductoDropDownList.SelectedValue), ProductoDropDownList.SelectedItem.ToString(), Utils.ToInt(CantidadTextBox.Text), Utils.ToDecimal(PrecioTextBox.Text), Utils.ToDecimal(ImporteTextBox.Text)));
                     ViewState["Detalle"] = factura.Detalles;
                 }
                 //SubTotal();
                 FacturaGridView.DataSource = ViewState["Detalle"];
                 FacturaGridView.DataBind();*/


                var facturaAnt = FacturaRepositorio.Buscar(Utils.ToInt(FacturaIdTextBox.Text));

                if(facturaAnt == null)
                {
                    Utils.MostrarMensaje(this, "Agregado", "Exito!!", "info");
                    factura = (Facturas)ViewState["Factura"];
                    factura.AgregarDetalle(0, Utils.ToInt(FacturaIdTextBox.Text), Utils.ToInt(ProductoDropDownList.SelectedValue), ProductoDropDownList.SelectedItem.ToString(), Utils.ToInt(CantidadTextBox.Text), Utils.ToDecimal(PrecioTextBox.Text), Utils.ToDecimal(ImporteTextBox.Text));

                }
                else
                {
                    Utils.MostrarMensaje(this, "Agregado", "Exito!!", "info");
                    facturaAnt = (Facturas)ViewState["Modificar"];
                    facturaAnt.Detalles.Add(new FacturasDetalles(0, Utils.ToInt(FacturaIdTextBox.Text), Utils.ToInt(ProductoDropDownList.SelectedValue), ProductoDropDownList.SelectedItem.ToString(), Utils.ToInt(CantidadTextBox.Text), Utils.ToDecimal(PrecioTextBox.Text), Utils.ToDecimal(ImporteTextBox.Text)));
                    //factura.AgregarDetalle(0, Utils.ToInt(FacturaIdTextBox.Text), Utils.ToInt(ProductoDropDownList.SelectedValue), ProductoDropDownList.SelectedItem.ToString(), Utils.ToInt(CantidadTextBox.Text), Utils.ToDecimal(PrecioTextBox.Text), Utils.ToDecimal(ImporteTextBox.Text));

                }
                ViewState["Factura"] = factura;
                this.BindGrid();
                SubTotal();

                //aqui
                /*Utils.MostrarMensaje(this, "Agregado", "Exito!!", "info");
                     factura = (Facturas)ViewState["Factura"];
                     factura.AgregarDetalle(0, Utils.ToInt(FacturaIdTextBox.Text), Utils.ToInt(ProductoDropDownList.SelectedValue), ProductoDropDownList.SelectedItem.ToString(), Utils.ToInt(CantidadTextBox.Text), Utils.ToDecimal(PrecioTextBox.Text), Utils.ToDecimal(ImporteTextBox.Text));

                     ViewState["Factura"] = factura;
                     this.BindGrid();
                     SubTotal();*/
                //aqui nitido



                /*detalles.Add(new FacturasDetalles(
                    id: 0,
                    facturaId: Utils.ToInt(FacturaIdTextBox.Text),
                    productoId: Utils.ToInt(ProductoDropDownList.SelectedValue),
                    descripcion: ProductoDropDownList.Text,
                    cantidad: Utils.ToInt(CantidadTextBox.Text),
                    precio: Utils.ToDecimal(PrecioTextBox.Text),
                    importe: Utils.ToDecimal(ImporteTextBox.Text)
                    ));*/

                //SubTotal();


            }




        }

        protected void ProductoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltraPrecio();
        }

        protected void ProductoDropDownList_TextChanged(object sender, EventArgs e)
        {
            FiltraPrecio();
        }

        protected void CantidadTextBox_TextChanged(object sender, EventArgs e)
        {

            ImporteTextBox.Text = CalculosBLL.CalcularImporte(Utils.ToDecimal(CantidadTextBox.Text), Utils.ToDecimal(PrecioTextBox.Text)).ToString();

        }

        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarLinkButton_Click(object sender, EventArgs e)
        {


            if (IsValid)
            {
                factura = FacturaRepositorio.Buscar(Utils.ToInt(FacturaIdTextBox.Text));

                if (factura == null)
                {
                    if (FacturaRepositorio.Guardar(LlenaClase()))
                    {
                        Utils.MostrarMensaje(this, "Guardado", "Exito!!", "success");
                        Limpiar();
                    }
                    else
                    {
                        Utils.MostrarMensaje(this, "No Guardado", "Advertencia", "warning");
                        Limpiar();
                    }
                }
                else
                {
                    if (FacturaRepositorio.Modificar(LlenaClase()))
                    {
                        Utils.MostrarMensaje(this, "Modificado", "Exito!!", "info");
                        Limpiar();
                    }
                    else
                    {
                        Utils.MostrarMensaje(this, "No Modificado", "Advertencia", "warning");
                        Limpiar();
                    }

                }
            }

        }

        protected void EliminarLinkButton_Click(object sender, EventArgs e)
        {
            GridViewRow grid = FacturaGridView.SelectedRow;
            //int id = Convert.ToInt32(FacturaGridView.DataKeys[grid.RowIndex].Value);
            List<FacturasDetalles> lista = (List<FacturasDetalles>)ViewState["Detalle"];
            Repositorio<Facturas> repositorio = new Repositorio<Facturas>();
            Facturas facturas = repositorio.Buscar(Utils.ToInt(FacturaIdTextBox.Text));

            if (IsValid)
            {
                if (facturas != null)
                {
                    FacturaRepositorio.Eliminar(facturas.FacturaId);                    
                    ViewState["Detalle"] = lista;
                    FacturaGridView.DataSource = ViewState["Detalle"];
                    FacturaGridView.DataBind();
                    Utils.MostrarMensaje(this, "Eliminado", "Exito!!", "success");
                    Limpiar();
                }
                else
                {
                    Utils.MostrarMensaje(this, "No Eliminado", "Advertencia", "warning");
                    Limpiar();
                }
            }






        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {

            if (IsValid)
            {
                factura = FacturaRepositorio.Buscar(Utils.ToInt(FacturaIdTextBox.Text));

                if (factura != null)
                {
                    Utils.MostrarMensaje(this, "Hay Resultado", "Exito!!", "info");
                    LlenarCampos(factura);

                }
                else
                {
                    Utils.MostrarMensaje(this, "No Hay Resultado", "Fallo!!", "warning");
                }
            }

        }

        protected void MontoTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        protected void CVClientes_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Equals(condicion))
                args.IsValid = false;
            else
                args.IsValid = true;
        }

        protected void CVProducto_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Equals(condicion))
                args.IsValid = false;
            else
                args.IsValid = true;
        }

        protected void CVCantidad_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Equals(0))
                args.IsValid = false;
            else
                args.IsValid = true;
        }

        protected void CVImporte_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Equals(0))
                args.IsValid = false;
            else
                args.IsValid = true;
        }

        protected void ImporteTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ImporteTextBox.Text != "")
                MontoTextBox.Text = CalculosBLL.CalcularSubTotal(Utils.ToDecimal(ImporteTextBox.Text)).ToString();
            else
                MontoTextBox.Text = "";
        }

        protected void CondicionRadioButton_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void FacturaGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FacturaGridView.DataSource = ViewState["Factura"];
            FacturaGridView.PageIndex = e.NewPageIndex;
            FacturaGridView.DataBind();
        }
    }

}