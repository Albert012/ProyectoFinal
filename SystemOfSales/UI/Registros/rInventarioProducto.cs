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
    public partial class rInventarioProducto : Form
    {
        public rInventarioProducto()
        {
            InitializeComponent();
            LlenaComboBox();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            InventarioIdNumericUpDown.Value = 0;
            FechaDateTimePicker.ResetText();
            ProductoComboBox.SelectedIndex = 0;
            CantidadNumericUpDown.Value = 0;
            MyErrorProvider.Clear();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Inventarios> repositorio = new Repositorio<Inventarios>();
            Inventarios inventarios = repositorio.Buscar((int)InventarioIdNumericUpDown.Value);

            if (Validar())
            {
                MessageBox.Show("Hay Campos Que Deben Ser Revisados", "Validacion!!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }


            if (inventarios == null)
            {
                if (InventariosBLL.Guardar(LlenaClase()))
                {
                    MessageBox.Show("Guardado Correctamente", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                    MessageBox.Show("No Se Pudo Registrar El Cliente", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (InventariosBLL.Modificar(LlenaClase()))
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
            Repositorio<Inventarios> repositorio = new Repositorio<Inventarios>();
            Inventarios inventarios = repositorio.Buscar((int)InventarioIdNumericUpDown.Value);

            if (inventarios != null)
            {
                InventariosBLL.Eliminar(inventarios.InventarioId);
                MessageBox.Show("Eliminado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NuevoButton.PerformClick();
            }
            else
                MessageBox.Show("No Se Puso Eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Inventarios> repositorio = new Repositorio<Inventarios>();
            Inventarios inventarios = repositorio.Buscar((int)InventarioIdNumericUpDown.Value);

            if (inventarios != null)
            {
                FechaDateTimePicker.Value = inventarios.Fecha;
                ProductoComboBox.DisplayMember = (ProductoComboBox.SelectedIndex = (inventarios.ProductoId - 1)).ToString();
                CantidadNumericUpDown.Value = inventarios.Cantidad;

            }
            else
            {
                MessageBox.Show("No Hay Resultados Para La Busqueda", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NuevoButton.PerformClick();
            }
        }

        private bool Validar()
        {
            bool Validar = false;

            if(CantidadNumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(CantidadNumericUpDown, "Digite La Cantidad");
                Validar = true;
            }

            return Validar;
        }

        private Inventarios LlenaClase()
        {
            Inventarios inventarios = new Inventarios();
            inventarios.InventarioId = (int)InventarioIdNumericUpDown.Value;
            inventarios.Fecha = FechaDateTimePicker.Value.Date;
            inventarios.ProductoId = (int)ProductoComboBox.SelectedValue;
            inventarios.Descripcion = ProductoComboBox.SelectedItem.ToString();
            inventarios.Cantidad = (int)CantidadNumericUpDown.Value;

            return inventarios;
        }

        private void LlenaComboBox()
        {
            Repositorio<Productos> repositorio = new Repositorio<Productos>();
            ProductoComboBox.DataSource = repositorio.GetList(p => true);
            ProductoComboBox.ValueMember = "ProductoId";
            ProductoComboBox.DisplayMember = "Descripcion";
        }
    }
}
