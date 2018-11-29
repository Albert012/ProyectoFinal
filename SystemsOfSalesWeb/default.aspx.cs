using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemsOfSalesWeb
{
    public partial class _default : System.Web.UI.Page
    {
        Usuarios userLogin = new Usuarios();
        Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
        List<Usuarios> listUser = new List<Usuarios>();
        string tipo = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }

        }

        protected override void OnPreInit(EventArgs e)
        {
            tipo = LogIn.RetornarTipoUser();
            listUser = repositorio.GetList(u => u.TipoUsuario.Equals(tipo));
            userLogin = (listUser != null && listUser.Count > 0) ? listUser[0] : null;

            if (userLogin != null)
            {
                if (userLogin.TipoUsuario.Equals(TipoUsuario.Administrador.ToString()))
                {
                    Page.MasterPageFile = "~/Site.Master";
                }
                else
                    if (userLogin.TipoUsuario.Equals(TipoUsuario.Cliente.ToString()))
                    {
                        Page.MasterPageFile = "~/SiteClient.Master";
                    }
            }


        }





    }
}