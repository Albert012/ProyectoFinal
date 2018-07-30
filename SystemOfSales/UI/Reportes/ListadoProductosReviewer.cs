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
    public partial class ListadoProductosReviewer : Form
    {
        private List<Productos> productos = null;
        public ListadoProductosReviewer(List<Productos> Datos)
        {
            InitializeComponent();
            this.productos = Datos;
        }

        private void ListadoProductosCrystalReportViewer_Load(object sender, EventArgs e)
        {
            ListadoProductosReport listadoProductosReport = new ListadoProductosReport();
            listadoProductosReport.SetDataSource(productos);

            ListadoProductosCrystalReportViewer.ReportSource = listadoProductosReport;
            ListadoProductosCrystalReportViewer.Refresh();
        }
    }
}
