using BLL;
using Entidades;
using Microsoft.Reporting.WebForms;
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
    public partial class cProductos : System.Web.UI.Page
    {
        Expression<Func<Productos, bool>> filtro;// = p => true;
        Repositorio<Productos> repositorio = new Repositorio<Productos>();

        public static List<Productos> listProductos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

                listProductos = repositorio.GetList(x => true);

            }

        }


        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {

            int id = 0;
            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);
            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = p => true && p.FechaRegistro >= desde && p.FechaRegistro <= hasta;
                    break;

                case 1://Producto
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = (p => (p.ProductoId == id) && (p.FechaRegistro >= desde && p.FechaRegistro <= hasta));
                    break;

                case 2://Descripcion
                    filtro = (p => p.Descripcion.Contains(CriterioTextBox.Text) && (p.FechaRegistro >= desde && p.FechaRegistro <= hasta));
                    break;
            }

            listProductos = repositorio.GetList(filtro);
            ProductoGridView.DataSource = listProductos;
            ProductoGridView.DataBind();
        }

        public static List<Productos> retornarProducto()
        {
            return listProductos;
        }

        protected void ImprimirLinkButton_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Reportes/ProductosReportViewer.aspx");
        }
    }
}