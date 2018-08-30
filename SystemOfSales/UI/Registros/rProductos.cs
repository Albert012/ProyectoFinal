using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;
using BLL;
using DAL;


namespace SystemOfSales.UI.Registros
{
    public partial class rProductos : Form
    {
        public rProductos()
        {
            InitializeComponent();
            FechaVencimientoDateTimePicker.Value = FechaRegistroDateTimePicker.Value.AddYears(1);
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            ProductoIdNumericUpDown.Value = 0;
            FechaRegistroDateTimePicker.ResetText();
            DescripcionTextBox.Clear();
            CostoNumericUpDown.Value = 0;
            PrecioNumericUpDown.Value = 0;
            GananciasNumericUpDown.Value = 0;
            InventarioNumericUpDown.Value = 0;
            MyErrorProvider.Clear();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Productos> repositorio = new Repositorio<Productos>();
            Productos productos = repositorio.Buscar((int)ProductoIdNumericUpDown.Value);

            if (Validar())
            {
                MessageBox.Show("Hay Campos Que Deben Ser Revisados", "Validacion!!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }


            if (productos == null)
            {
                if (repositorio.Guardar(LlenaClase()))
                {
                    MessageBox.Show("Guardado Correctamente", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                    MessageBox.Show("No Se Pudo Registrar El Producto", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (repositorio.Modificar(LlenaClase()))
                {
                    MessageBox.Show("Modificado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                    MessageBox.Show("No Se Pudo Modificar El Producto", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Productos> repositorio = new Repositorio<Productos>();
            Productos productos = repositorio.Buscar((int)ProductoIdNumericUpDown.Value);

            if (productos != null)
            {
                repositorio.Eliminar(productos.ProductoId);
                MessageBox.Show("Eliminado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NuevoButton.PerformClick();
            }
            else
                MessageBox.Show("No Se Puso Eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Productos> repositorio = new Repositorio<Productos>();
            Productos productos = repositorio.Buscar((int)ProductoIdNumericUpDown.Value);

            if (productos != null)
            {
                FechaRegistroDateTimePicker.Value = productos.FechaRegistro;
                FechaVencimientoDateTimePicker.Value = productos.FechaVencimiento;
                DescripcionTextBox.Text = productos.Descripcion;
                CostoNumericUpDown.Value = productos.Costo;
                PrecioNumericUpDown.Value = productos.Precio;
                GananciasNumericUpDown.Value = productos.Ganancias;
                InventarioNumericUpDown.Value = productos.Inventario;
            }
            else
            {
                MessageBox.Show("No Hay Resultados Para La Busqueda", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NuevoButton.PerformClick();
            }
               
        }

        private void FechaRegistroDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            FechaVencimientoDateTimePicker.Value = FechaRegistroDateTimePicker.Value.AddYears(1);
        }

        private bool Validar()
        {
            bool Validar = false;

            if(string.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                MyErrorProvider.SetError(DescripcionTextBox, "Debes Ingresar La Descripcion");
                Validar = true;
            }

            if (CostoNumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(CostoNumericUpDown, "Debes Ingresar El Costo");
                Validar = true;
            }

            if (PrecioNumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(PrecioNumericUpDown, "Debes Ingresar El Precio");
                Validar = true;
            }

            if (GananciasNumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(GananciasNumericUpDown, "Debes Ingresar La Ganancias");
                Validar = true;
            }

           
            return Validar;
        }

        private Productos LlenaClase()
        {
            Productos productos = new Productos();
            productos.ProductoId = (int)ProductoIdNumericUpDown.Value;
            productos.FechaRegistro = FechaRegistroDateTimePicker.Value.Date;
            productos.FechaVencimiento = FechaVencimientoDateTimePicker.Value.Date;
            productos.Descripcion = DescripcionTextBox.Text;
            productos.Costo = CostoNumericUpDown.Value;
            productos.Precio = PrecioNumericUpDown.Value;
            productos.Ganancias = GananciasNumericUpDown.Value;
            productos.Inventario = (int)InventarioNumericUpDown.Value;
            return productos;

        }

        private void DescripcionTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");

            }
        }

        private void CostoNumericUpDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");

            }

        }

        private void PrecioNumericUpDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");

            }
        }

        private void PrecioNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            
            if(CostoNumericUpDown.Value != 0 )
            {
                GananciasNumericUpDown.Value = CalculosBLL.CalcularGanancias(PrecioNumericUpDown.Value, CostoNumericUpDown.Value);
            }
        }

        private void InventarioNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void GananciasNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (GananciasNumericUpDown.Value > 100)
            {
                MyErrorProvider.SetError(GananciasNumericUpDown, "Error");
                return;
            }
            else
                PrecioNumericUpDown.Value = CalculosBLL.CalcularPrecio(CostoNumericUpDown.Value, GananciasNumericUpDown.Value);
        }
    }
}
