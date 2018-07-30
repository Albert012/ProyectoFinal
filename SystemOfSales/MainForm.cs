using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SystemOfSales.UI.Consultas;
using SystemOfSales.UI.Registros;

namespace SystemOfSales
{
    public partial class MainForm : Form
    {
        //private static MainForm Menu;

        public MainForm()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Esta Seguro Que Quieres Salir", "Saliendo De SystemOfSales", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result ==DialogResult.Yes)
                Close();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
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
           
        }

        private void tipoUsarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void generoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cUsuarios cUsuarios = new cUsuarios();
            cUsuarios.MdiParent = this.MdiParent;
            cUsuarios.Show();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cClientes cClientes = new cClientes();
            cClientes.MdiParent = this.MdiParent;
            cClientes.Show();
        }

        private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cProductos cProductos = new cProductos();
            cProductos.MdiParent = this.MdiParent;
            cProductos.Show();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rUsuarios rUsuarios = new rUsuarios();
            rUsuarios.MdiParent = this.MdiParent;
            rUsuarios.Show();
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rInventarioProducto inventario = new rInventarioProducto();
            inventario.MdiParent = this.MdiParent;
            inventario.Show();
        }
        

        private void LlenaLabel()
        {
            
            UserStatusLabel.Text = Login.MostrarUser().Usuario;
            TipoStatusLabel.Text = Login.MostrarUser().TipoUsuario;
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            
        }

        private void MainForm_VisibleChanged(object sender, EventArgs e)
        {
            LlenaLabel();
        }

        private void cambioUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.Cambio().Show();
            Login.Cambio().Activate();

        }
    }
}
