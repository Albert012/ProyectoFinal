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
    public partial class ReciboReviewer : Form
    {
        List<FacturasDetalles> Detalle = null;

        public ReciboReviewer(List<FacturasDetalles> Datos)
        {
            InitializeComponent();
            this.Detalle = Datos;
        }

        private void ReciboCrystalReportViewer_Load(object sender, EventArgs e)
        {
            ReciboReport reciboReport = new ReciboReport();
            reciboReport.SetDataSource(Detalle);
            ReciboCrystalReportViewer.ReportSource = reciboReport;
            ReciboCrystalReportViewer.Refresh();


        }
    }
}
