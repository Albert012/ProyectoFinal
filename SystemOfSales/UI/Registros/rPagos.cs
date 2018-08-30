using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemOfSales.UI.Registros
{
    public partial class rPagos : Form
    {
        public rPagos()
        {
            InitializeComponent();
            LlenaComboBox();
        }
        private bool Validar()
        {
            bool Validar = false;

            if (TotalNumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(TotalNumericUpDown, "Digite La Cantidad");
                Validar = true;
            }

            if (TotalNumericUpDown.Value > BalanceNumericUpDown.Value)
            {
                MyErrorProvider.SetError(TotalNumericUpDown, "No Puedes Pagar Mas De Lo Que Debes");
                Validar = true;
            }

            return Validar;
        }

        private Pagos LlenaClase()
        {
            Pagos pago = new Pagos();
            pago.PagoId = (int)PagoIdNumericUpDown.Value;
            pago.Fecha = FechaDateTimePicker.Value.Date;
            pago.ClienteId = (int)ClientesComboBox.SelectedValue;
            pago.Nombres = ClientesComboBox.SelectedItem.ToString();
            pago.Total = (int)TotalNumericUpDown.Value;

            return pago;
        }

        private void FiltrarBalance()
        {
            Clientes balance = (Clientes)ClientesComboBox.SelectedItem;
            BalanceNumericUpDown.Value = balance.Balance;
        }


        private void LlenaComboBox()
        {
            Repositorio<Clientes> repositorio = new Repositorio<Clientes>();
            ClientesComboBox.DataSource = repositorio.GetList(p => p.Balance > 0);
            ClientesComboBox.ValueMember = "ClienteId";
            ClientesComboBox.DisplayMember = "Nombres";
        }
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            PagoIdNumericUpDown.Value = 0;
            FechaDateTimePicker.ResetText();
            ClientesComboBox.SelectedIndex = 0;
            TotalNumericUpDown.Value = 0;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Pagos> repositorio = new Repositorio<Pagos>();
            Pagos pagos = repositorio.Buscar((int)PagoIdNumericUpDown.Value);

            if (Validar())
            {
                MessageBox.Show("Hay Campos Que Deben Ser Revisados", "Validacion!!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }


            if (pagos == null)
            {
                if (PagosBLL.Guardar(LlenaClase()))
                {
                    MessageBox.Show("Guardado Correctamente", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                    MessageBox.Show("No Se Pudo Registrar El Pago", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (PagosBLL.Modificar(LlenaClase()))
                {
                    MessageBox.Show("Modificado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                    MessageBox.Show("No Se Pudo Modificar El Pago", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Pagos> repositorio = new Repositorio<Pagos>();
            Pagos pagos = repositorio.Buscar((int)PagoIdNumericUpDown.Value);

            if (pagos != null)
            {
                FechaDateTimePicker.Value = pagos.Fecha;
                ClientesComboBox.DisplayMember = (ClientesComboBox.SelectedItem = (pagos.ClienteId)).ToString();
                TotalNumericUpDown.Value = pagos.Total;

            }
            else
            {
                MessageBox.Show("No Hay Resultados Para La Busqueda", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NuevoButton.PerformClick();
            }
        }

        private void ClientesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarBalance();
        }
    }
}
