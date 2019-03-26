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
    public partial class cClientes : System.Web.UI.Page
    {
        Expression<Func<Clientes, bool>> filtro = p => true;
        Repositorio<Clientes> repositorio = new Repositorio<Clientes>();
        public static List<Clientes> listClientes { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                listClientes = repositorio.GetList(filtro);

            }
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);

            if(hasta.Date < desde.Date)
            {
                Utils.MostrarMensaje(this, "No Sera Posible Hacer Una Consulta Si El Rango Hasta Es Menor Que El Desde!!", "Fechas Invalidas!!", "warning");
                return;
            }

            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = p => true && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 1://ClienteId
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = p => p.ClienteId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://Nombres
                    filtro = p => p.Nombres.Contains(CriterioTextBox.Text) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            listClientes = repositorio.GetList(filtro);
            ClienteGridView.DataSource = listClientes;
            ClienteGridView.DataBind();
        }

        public static List<Clientes> RetornarClientes()
        {
            return listClientes;
        }

        protected void ImprimirLinkButton_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Reportes/ClientesReportViewer.aspx");

        }

        protected void FiltroDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CriterioTextBox.Text = "";

            if(FiltroDropDownList.SelectedIndex == 0)
            {
                CriterioTextBox.ReadOnly = true;

            }
            else
            {
                CriterioTextBox.ReadOnly = false;
            }
        }
    }
}