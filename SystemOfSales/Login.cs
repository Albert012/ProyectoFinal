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
using SystemOfSales.UI.Registros;

namespace SystemOfSales
{
    public partial class Login : Form
    {
        private static Usuarios UserLogin = null;
        private static Login Unico = null;

        public Login()
        {
            InitializeComponent();
            
        }

        public static Entidades.Usuarios MostrarUser()
        {
            return UserLogin;
        }

        public static Login Cambio()
        {
            if (Unico == null)
                Unico = new Login();
            return Unico;
        }
               

        private void AccederButton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuarios> usuarios = new Repositorio<Usuarios>();
            var  Lista = usuarios.GetList(u => u.Usuario.Equals(UsuarioTextBox.Text) && u.Contrasena.Equals(ContrasenaTextBox.Text));
            Usuarios user = (Lista != null && Lista.Count > 0) ? Lista[0] : null;                   


            if (user != null)
            {
                this.Close();
                UserLogin = user;
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

        private void NoUsuarioCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(NoUsuarioCheckBox.Checked)
            {
                MessageBox.Show("Debes Ponerte En Contacto Con El Administrador Si Quieres Formar Parte De Este Sistema", "Error Capa 8", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NoUsuarioCheckBox.Checked = false;
                return;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Unico = null;
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
