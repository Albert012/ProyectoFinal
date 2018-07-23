using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Entidades;
using DAL;
using System.Threading;
using System.Threading.Tasks;

namespace SystemOfSales
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void AccederButton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuarios> usuarios = new Repositorio<Usuarios>(new Contexto());
            //List<Usuarios> 
              var  Lista = usuarios.GetList(u => u.Nombre.Equals(UsuarioTextBox.Text) && u.Contrasena.Equals(ContrasenaTextBox.Text));
            Usuarios user = (Lista != null && Lista.Count > 0) ? Lista[0] : null;
           
            if (user != null)
            {
                this.Close();
                Thread hilo = new Thread(AbrirMenu);
                hilo.Start();

                return;
            }
            else
            {
                MessageBox.Show("Usuario No Existe");
                UsuarioTextBox.Clear();
                ContrasenaTextBox.Clear();
            }


        }

        private void AbrirMenu()
        {
            Application.Run(new MainForm());
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UsuarioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void ContrasenaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
                AccederButton.PerformClick();
            }
        }
    }
}
