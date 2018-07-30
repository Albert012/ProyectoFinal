using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;
namespace SystemOfSales.UI.Reportes
{
    public partial class ListadoUsuariosReviewer : Form
    {
        private List<Usuarios> usuarios = null;

        public ListadoUsuariosReviewer(List<Usuarios> Datos)
        {
            InitializeComponent();
            this.usuarios = Datos;
        }

        private void ListadoUsuariosCrystalReportViewer_Load(object sender, EventArgs e)
        {
            ListadoUsuariosReport listadoUsuariosReport = new ListadoUsuariosReport();
            listadoUsuariosReport.SetDataSource(usuarios);

            ListadoUsuariosCrystalReportViewer.ReportSource = listadoUsuariosReport;
            ListadoUsuariosCrystalReportViewer.Refresh();
        }
    }
}
