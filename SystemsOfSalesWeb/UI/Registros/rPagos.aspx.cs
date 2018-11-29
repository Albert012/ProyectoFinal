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
        Repositorio<Pagos> repositorio = new Repositorio<Pagos>();

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

        private void LlenaDropDown()
        {

        }

        private void LlenaCampos(Pagos pagos)
        {

        }

        private  void Limpiar()
        {

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