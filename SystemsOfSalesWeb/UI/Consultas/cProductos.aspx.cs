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
    public partial class cProductos : System.Web.UI.Page
    {
        Expression<Func<Productos, bool>> filtro = p => true;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Productos> repositorio = new Repositorio<Productos>();
            int id = 0;
            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = p => true;
                    break;

                case 1://Producto
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = (p => p.ProductoId == id);
                    break;

                case 2://Descripcion
                    filtro = (p => p.Descripcion.Contains(CriterioTextBox.Text));
                    break;


            }

            ProductoGridView.DataSource = repositorio.GetList(filtro);
            ProductoGridView.DataBind();
        }
    }
}