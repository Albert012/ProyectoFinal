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
        Expression<Func<Usuarios, bool>> filtro = p => true;
        Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
        public static List<Usuarios> listUsuarios{ get; set; }

        public static int id_Usuario = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                BingGrid();

            }
        }
        
        private void BingGrid()
        {
            listUsuarios = repositorio.GetList(x => true);
            UsuarioGridView.DataSource = listUsuarios;
            UsuarioGridView.DataBind();
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

        protected void UsuarioGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idUsuario = Convert.ToInt32(UsuarioGridView.DataKeys[e.RowIndex].Values[0]);
            repositorio.Eliminar(idUsuario);
            UsuarioGridView.EditIndex = -1;
            BingGrid();

        }

        protected void UsuarioGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            UsuarioGridView.EditIndex = -1;
            BingGrid();
        }

        protected void UsuarioGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            UsuarioGridView.EditIndex = -1;
            int id = Convert.ToInt32(UsuarioGridView.DataKeys[e.NewEditIndex].Values[0]);
            Usuarios usuarios = repositorio.Buscar(id);
            id_Usuario = usuarios.UsuarioId;
            BingGrid();
            Response.Redirect(@"~\UI\Registros\rUsuarios.aspx");
        }

        public static int RetornarId()
        {
            return id_Usuario;
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~\UI\Registros\rUsuarios.aspx");
        }

        protected void FiltroDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FiltroDropDownList.SelectedIndex == 0)
                CriterioTextBox.ReadOnly = true;
            else
                CriterioTextBox.ReadOnly = false;
        }
    }
}