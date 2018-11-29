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
    public partial class cInventarios : System.Web.UI.Page
    {
        Expression<Func<Inventarios, bool>> filtro;// = p => true;
        //Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
        InventarioRepositorio repositorio = new InventarioRepositorio();
        public static List<Inventarios> listInventarios { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                listInventarios = repositorio.GetList(x => true);

            }
        }

        public static List<Inventarios> GetInventarios()
        {
            return listInventarios;
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);

            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0://Todo
                    if(hasta < desde)
                    {
                        Utils.MostrarMensaje(this, "No Se Puede Hacer Consulta Si La Fecha Hasta Es Menor Que La Fecha Desde", "Error", "error");
                        return;
                    }
                    filtro = p => true && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 1://InvenarioId
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = p => p.InventarioId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://ProductoId
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = p => p.ProductoId.Equals(id) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 3://Descripcion
                    filtro = p => p.Descripcion.Contains(CriterioTextBox.Text) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 4://cantidad
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = p => p.Cantidad.Equals(id) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            listInventarios = repositorio.GetList(filtro);
            InventarioGridView.DataSource = listInventarios;
            InventarioGridView.DataBind();
        }

        protected void ImprimirLinkButton_Click(object sender, EventArgs e)
        {
            if (listInventarios.Count > 0)
            {
                Response.Redirect("../Reportes/InventariosReportViewer.aspx");
            }
            else
            {
                Utils.MostrarMensaje(this, "No Hay Datos", "Fallo!!", "error");
            }
        }
    }
}