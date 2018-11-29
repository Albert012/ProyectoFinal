using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemsOfSalesWeb.Utilitarios;

namespace SystemsOfSalesWeb.UI.Consultas
{
    public partial class cFacturas : System.Web.UI.Page
    {
        Expression<Func<Facturas, bool>> filtro;// = p => true;
        FacturaRepositorio FacturaRepositorio = new FacturaRepositorio();
        public static List<Facturas> listFacturas { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                listFacturas = FacturaRepositorio.GetList(x => true);

            }
        }

        public static List<Facturas> GetFacturas()
        {
            return listFacturas;
                            
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);

            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = p => true && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 1://FacturaId
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = p => p.FacturaId.Equals(id) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://ClienteId
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = p => p.ClienteId.Equals(id) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 3://monto
                    decimal monto = Utils.ToDecimal(CriterioTextBox.Text);
                    filtro = p => p.ClienteId.Equals(monto) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            listFacturas = FacturaRepositorio.GetList(filtro);
            FacturaGridView.DataSource = listFacturas;
            FacturaGridView.DataBind();
        }

        protected void ImprimirLinkButton_Click(object sender, EventArgs e)
        {
            if (listFacturas.Count > 0)
            {
                Response.Redirect("../Reportes/FacturasReportViewer.aspx");
            }
            else
            {
                Utils.MostrarMensaje(this, "No Hay Datos", "Fallo!!", "error");
            }
        }
    }
}