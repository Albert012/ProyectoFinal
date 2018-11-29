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
    public partial class cPagos : System.Web.UI.Page
    {
        Expression<Func<Pagos, bool>> filtro;// = p => true;
        Repositorio<Pagos> repositorio = new Repositorio<Pagos>();
        public static List<Pagos> listPagos{ get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                listPagos = repositorio.GetList(x => true);

            }
        }

        public static List<Pagos> GetPagos()
        { return listPagos; }
             

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

                case 1://PagoId
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = p => p.PagoId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://Nombres
                    filtro = p => p.Nombres.Contains(CriterioTextBox.Text) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 3://ClienteId
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = p => p.ClienteId.Equals(id) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 4://Total
                   decimal total = Utils.ToDecimal(CriterioTextBox.Text);
                    filtro = p => p.Total.Equals(total) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            listPagos = repositorio.GetList(filtro);
            PagosGridView.DataSource = listPagos;
            PagosGridView.DataBind();
        }

        protected void ImprimirLinkButton_Click(object sender, EventArgs e)
        {
            if (listPagos.Count > 0)
            {
                Response.Redirect("../Reportes/PagosReportViewer.aspx");
            }
            else
            {
                Utils.MostrarMensaje(this, "No Hay Datos", "Fallo!!", "error");
            }
        }
    }
}