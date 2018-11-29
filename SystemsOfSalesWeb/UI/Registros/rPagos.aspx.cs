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
    public partial class rPagos : System.Web.UI.Page
    {
        string condicion = "[Seleccione]";
        Pagos pago = new Pagos();
        Repositorio<Pagos> repositorio = new Repositorio<Pagos>();
        Repositorio<Clientes> repositorioCliente = new Repositorio<Clientes>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                int id = Utils.ToInt(Request.QueryString["id"]);
                LlenaDropDown();
                if (id > 0)
                {
                   
                    var pago = repositorio.Buscar(id);

                    if (pago != null)
                        Utils.MostrarMensaje(this, "No Hay Resultado", "Error", "error");
                    else
                        LlenaCampos(pago);
                }
            }
        }

        private Pagos LlenaClase()
        {          

            pago.PagoId = Utils.ToInt(PagoIdTextBox.Text);
            pago.Fecha = Utils.ToDateTime(FechaTextBox.Text);
            pago.ClienteId = Utils.ToInt(ClienteDropDownList.SelectedValue);            
            pago.Total = Utils.ToInt(CantidadTextBox.Text);


            return pago;
        }

        private void LlenaCampos(Pagos pago)
        {
            
            FechaTextBox.Text = pago.Fecha.ToString("yyyy-MM-dd");
            ClienteDropDownList.Text = pago.ClienteId.ToString();
            CantidadTextBox.Text = pago.Total.ToString();
        }

        private void LlenaDropDown()
        {
         
            ClienteDropDownList.DataSource = repositorioCliente.GetList(p => true);
            ClienteDropDownList.DataValueField = "ClienteId";
            ClienteDropDownList.DataTextField = "Nombres";
            ClienteDropDownList.AppendDataBoundItems = true;
            ClienteDropDownList.DataBind();
        }

        private void Limpiar()
        {
            PagoIdTextBox.Text = "";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            ClienteDropDownList.SelectedIndex = 0;
            CantidadTextBox.Text = "";

        }

        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {

        }

        protected void GuardarLinkButton_Click(object sender, EventArgs e)
        {

        }

        protected void EliminarLinkButton_Click(object sender, EventArgs e)
        {

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
           
            Pagos pago = repositorio.Buscar(Utils.ToInt(PagoIdTextBox.Text));

            if (IsValid)
            {
                if (pago != null)
                {
                    Utils.MostrarMensaje(this, "Hay Resultado", "Exito!!", "info");
                    Limpiar();
                    LlenaCampos(pago);
                }
                else
                {
                    Utils.MostrarMensaje(this, "No Hay Resultado", "Error", "error");
                    Limpiar();
                }
            }
        }
    }
}