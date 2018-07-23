using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SystemOfSales.UI.Registros;


namespace SystemOfSales
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esperamos Que Nos Vuelva A Visitar", "Saliendo De SystemOfSales", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rUsuarios user = new rUsuarios();
            user.MdiParent = this.MdiParent;
            user.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rClientes cliente = new rClientes();
            cliente.MdiParent = this.MdiParent;
            cliente.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rProductos producto = new rProductos();
            producto.MdiParent = this.MdiParent;
            producto.Show();
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rFacturas factura = new rFacturas();
            factura.MdiParent = this.MdiParent;
            factura.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rCompania compania = new rCompania();
            compania.MdiParent = this.MdiParent;
            compania.Show();
        }

        private void tipoUsarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rTipoUsuario tipouser = new rTipoUsuario();
            tipouser.MdiParent = this.MdiParent;
            tipouser.Show();
        }

        private void generoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rGenero genero = new rGenero();
            genero.MdiParent = this.MdiParent;
            genero.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
