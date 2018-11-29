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
    public partial class cUsuarios : System.Web.UI.Page
    {
        Expression<Func<Usuarios, bool>> filtro;// = p => true;
        Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
        public static List<Usuarios> listUsuarios{ get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                listUsuarios = repositorio.GetList(x => true);

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
                    filtro = p => true && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 1://UsuarioId
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = p => p.UsuarioId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://Email
                    filtro = p => p.Email.Contains(CriterioTextBox.Text) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 3://Usuario
                    filtro = p => p.Usuario.Contains(CriterioTextBox.Text) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 4://Nombre
                    filtro = p => p.NombreUsuario.Contains(CriterioTextBox.Text) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            listUsuarios = repositorio.GetList(filtro);
            UsuarioGridView.DataSource = listUsuarios;
            UsuarioGridView.DataBind();
        }

        public static List<Usuarios> RetornarUsuarios()
        {
            return listUsuarios;
        }

        protected void ImprimirLinkButton_Click(object sender, EventArgs e)
        {
            if (listUsuarios.Count > 0)
            {
                Response.Redirect("../Reportes/UsuariosReportViewer.aspx");
            }
            else
            {
                Utils.MostrarMensaje(this, "No Hay Datos", "Fallo!!", "error");
            }
        }
    }
}