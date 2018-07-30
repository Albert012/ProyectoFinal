using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemOfSales.UI.Reportes
{
    public partial class ListadoClientesReviewer : Form
    {
        private List<Clientes> clientes = null;
        public ListadoClientesReviewer(List<Clientes> Datos)
        {
            InitializeComponent();
            this.clientes = Datos;
        }

        private void ListadoClientesCrystalReportViewer_Load(object sender, EventArgs e)
        {
            ListadoClientesReport listadoClientesReport = new ListadoClientesReport();
            listadoClientesReport.SetDataSource(clientes);

            ListadoClientesCrystalReportViewer.ReportSource = listadoClientesReport;
            ListadoClientesCrystalReportViewer.Refresh();
        }
    }
}
