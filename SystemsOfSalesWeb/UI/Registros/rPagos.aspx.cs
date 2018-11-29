using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemsOfSalesWeb.UI.Registros
{
    public partial class rPagos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
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
    }
}