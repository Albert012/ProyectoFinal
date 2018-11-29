using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemsOfSalesWeb.UI.Consultas;

namespace SystemsOfSalesWeb.UI.Reportes
{
    public partial class InventariosReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListadoReportViewer.ProcessingMode = ProcessingMode.Local;
                ListadoReportViewer.Reset();
                ListadoReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\UI\Reportes\InventariosReport.rdlc");
                ListadoReportViewer.LocalReport.DataSources.Clear();
                ListadoReportViewer.LocalReport.DataSources.Add(new ReportDataSource("InventariosDataSet", cInventarios.GetInventarios()));
                ListadoReportViewer.LocalReport.Refresh();
            }
        }
    }
}