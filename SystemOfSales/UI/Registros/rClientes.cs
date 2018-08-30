using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;
using DAL;
using BLL;


namespace SystemOfSales.UI.Registros
{
    public partial class rClientes : Form
    {
        public rClientes()
        {
            InitializeComponent();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            ClienteIdNumericUpDown.Value = 0;
            FechaDateTimePicker.ResetText();
            NombresTextBox.Clear();
            DireccionTextBox.Clear();
            CedulaMaskedTextBox.Clear();
            SexoComboBox.SelectedIndex = 0;
            TelefonoMaskedTextBox.Clear();
            BalanceNumericUpDown.Value = 0;
            MyErrorProvider.Clear();

        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Clientes> repositorio = new Repositorio<Clientes>();            
            Clientes cliente = repositorio.Buscar((int)ClienteIdNumericUpDown.Value);
            MyErrorProvider.Clear();
            if (Validar())
            {
                MessageBox.Show("Hay Campos Que Deben Ser Revisados", "Validacion!!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }


            if (cliente == null)
            {
                if (repositorio.Guardar(LlenaClase()))
                {
                    MessageBox.Show("Guardado Correctamente", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                    MessageBox.Show("No Se Pudo Registrar El Cliente", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (repositorio.Modificar(LlenaClase()))
                {
                    MessageBox.Show("Modificado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                    MessageBox.Show("No Se Pudo Modificar El Cliente", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Clientes> repositorio = new Repositorio<Clientes>();
            Clientes cliente = repositorio.Buscar((int)ClienteIdNumericUpDown.Value);

            if(cliente != null)
            {
                repositorio.Eliminar(cliente.ClienteId);
                MessageBox.Show("Eliminado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NuevoButton.PerformClick();
            }
            else
                MessageBox.Show("No Se Puso Eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Clientes> repositorio = new Repositorio<Clientes>();
            Clientes clientes = repositorio.Buscar((int)ClienteIdNumericUpDown.Value);

            if (clientes != null)
            {
                ClienteIdNumericUpDown.Value = clientes.ClienteId;
                FechaDateTimePicker.Value = clientes.Fecha;
                NombresTextBox.Text = clientes.Nombres;
                DireccionTextBox.Text = clientes.Direccion;
                CedulaMaskedTextBox.Text = clientes.Cedula;
                TelefonoMaskedTextBox.Text = clientes.Telefono;
                SexoComboBox.Text = clientes.Sexo;
                BalanceNumericUpDown.Value = clientes.Balance;
                
            }
            else
            {
                MessageBox.Show("No Hay Resultados Para La Busqueda", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NuevoButton.PerformClick();
            }
                
        }

        private Clientes LlenaClase()
        {
            Clientes clientes = new Clientes();
            clientes.ClienteId = (ClienteIdNumericUpDown.Value == 0) ? 0 : (int)ClienteIdNumericUpDown.Value;
            clientes.Fecha = FechaDateTimePicker.Value.Date;
            clientes.Nombres = NombresTextBox.Text;
            clientes.Direccion = DireccionTextBox.Text;
            clientes.Sexo = SexoComboBox.Text;
            clientes.Cedula = CedulaMaskedTextBox.Text;
            clientes.Telefono = TelefonoMaskedTextBox.Text;
            //clientes.Ingresos = IngresosNumericUpDown.Value;
            clientes.Balance = BalanceNumericUpDown.Value;
            return clientes;
        }

        private bool Validar()
        {
            bool Validar = false;

            if(string.IsNullOrWhiteSpace(NombresTextBox.Text))
            {
                MyErrorProvider.SetError(NombresTextBox, "Debes Llenar Los Nombres");
                Validar = true;
            }

            if(string.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                MyErrorProvider.SetError(DireccionTextBox, "Debes Llenar La Direccion");
                Validar = true;
            }

            if(CedulaMaskedTextBox.Text.Length < 13 )//&& (CedulaMaskedTextBox.Text.Substring(0,2)=="056" || CedulaMaskedTextBox.Text.Substring(0, 2) == "402"))
            {
                MyErrorProvider.SetError(CedulaMaskedTextBox, "Debes Llenar Completo La Cedula");
                Validar = true;
            }

            if (string.IsNullOrWhiteSpace(SexoComboBox.Text))
            {
                MyErrorProvider.SetError(SexoComboBox, "Debes Selccionar El Sexo");
                Validar = true;
            }

            if (TelefonoMaskedTextBox.Text.Length  < 12)// && ( TelefonoMaskedTextBox.Text.Substring(0,2) == "809" || TelefonoMaskedTextBox.Text.Substring(0, 2) == "829" || TelefonoMaskedTextBox.Text.Substring(0, 2) == "849"))
            {
                MyErrorProvider.SetError(TelefonoMaskedTextBox, "Debes Llenar Completo El Telefono");
                Validar = true;
            }

            return Validar;
        }

        private void NombresTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
                
            }
        }

        private void CedulaMaskedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void SexoComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void DireccionTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void TelefonoMaskedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
                
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void CedulaMaskedTextBox_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if(!e.IsValidInput)
            {
                toolTip1.ToolTipTitle = "Cedula Invalida";
                toolTip1.Show("Ingrese la cedual en el formato de 056-8967547-8",CedulaMaskedTextBox,0,-20,5000);
            }            
        }

        private void CedulaMaskedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            toolTip1.Hide(CedulaMaskedTextBox);
        }
    }
}
