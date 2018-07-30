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

namespace SystemOfSales.UI.Registros
{
    public partial class rUsuarios : Form
    {
        public rUsuarios()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UsuarioIdNumericUpDown.Value = 0;
            FechaDateTimePicker.ResetText();
            UsuarioTextBox.Clear();
            NombreTextBox.Clear();
            TipoUsuarioComboBox.SelectedIndex = 0;
            ContrasenaTextBox.Clear();
            ConfirmarTextBox.Clear();
        }

        private Usuarios LlenaClase()
        {
            Usuarios user = new Usuarios();
            user.UsuarioId = (int)UsuarioIdNumericUpDown.Value;
            user.Fecha = FechaDateTimePicker.Value.Date;
            user.Usuario = UsuarioTextBox.Text;
            user.NombreUsuario = NombreTextBox.Text;
            user.TipoUsuario = TipoUsuarioComboBox.Text;
            user.Contrasena = ContrasenaTextBox.Text;
            return user;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();            
            Usuarios user = repositorio.Buscar((int)UsuarioIdNumericUpDown.Value);

            if (Validar())
            {
                MessageBox.Show("Hay Campos Que Deben Ser Revisados", "Validacion!!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }


            if(user == null)
            {
                if (repositorio.Guardar(LlenaClase()))
                {
                    MessageBox.Show("Guardado Correctamente", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                    MessageBox.Show("No Se Pudo Registrar El Usuario", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (repositorio.Modificar(LlenaClase()))
                {
                    MessageBox.Show("Modificado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                    MessageBox.Show("No Se Pudo Modificar El Usuario", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


        }

        private bool Validar()
        {
            bool Validar = false;

            if (string.IsNullOrWhiteSpace(UsuarioTextBox.Text))
            {
                MyErrorProvider.SetError(UsuarioTextBox, "Debes Ingresar El Usuario");
                Validar = true;
            }

            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                MyErrorProvider.SetError(NombreTextBox, "Debes Ingresar El Nombre Del Usuario");
                Validar = true;
            }

            if(string.IsNullOrWhiteSpace(TipoUsuarioComboBox.Text))
            {
                MyErrorProvider.SetError(TipoUsuarioComboBox, "Debes Seleccionar El Tipo De Usuario");
                Validar = true;
            }

            if(string.IsNullOrWhiteSpace(ContrasenaTextBox.Text))
            {
                MyErrorProvider.SetError(ContrasenaTextBox, "Debes Ingresar La Contraseña Del Usuario");
                Validar = true;
            }

            if(string.IsNullOrWhiteSpace(ConfirmarTextBox.Text))
            {
                MyErrorProvider.SetError(ConfirmarTextBox, "Debes Confirmar La Contraseña");
                Validar = true;

            }

            if(ConfirmarTextBox.Text != ContrasenaTextBox.Text)
            {
                MyErrorProvider.SetError(ConfirmarTextBox, "La Constraseña Ingresada No Son Iguales");
                Validar = true;
            }



            return Validar;

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
            Usuarios user = repositorio.Buscar((int)UsuarioIdNumericUpDown.Value);

            if(user != null)
            {
                repositorio.Eliminar(user.UsuarioId);
                MessageBox.Show("Eliminado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NuevoButton.PerformClick();
            }
            else
            {
                MessageBox.Show("No Se Puso Eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                NuevoButton.PerformClick();
            }
                 



        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
            Usuarios user = repositorio.Buscar((int)UsuarioIdNumericUpDown.Value);

            if (user != null)
            {
                UsuarioTextBox.Text = user.Usuario;
                NombreTextBox.Text = user.NombreUsuario;
                FechaDateTimePicker.Value = user.Fecha;
                TipoUsuarioComboBox.Text = user.TipoUsuario;
                ContrasenaTextBox.Text = user.Contrasena;

            }
            else
            {
                MessageBox.Show("No Hay Resultados Para La Busqueda", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NuevoButton.PerformClick();
            }

                

        }

        private void UsuarioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");

            }
        }

        private void NombreTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");

            }
        }

        private void TipoUsuarioComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");

            }
        }

        private void ContrasenaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");

            }
        }

        private void ConfirmarTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");

            }
        }
    }
}
