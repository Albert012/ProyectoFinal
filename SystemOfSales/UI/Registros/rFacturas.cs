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
    public partial class rFacturas : Form
    {
        List<FacturasDetalles> detalles = new List<FacturasDetalles>();

        public rFacturas()
        {
            InitializeComponent();
            LlenaComboBox();
        }

        private void LlenaComboBox()
        {
            Repositorio<Clientes> clientes = new Repositorio<Clientes>();
            Repositorio<Productos> productos = new Repositorio<Productos>();

            NombresComboBox.DataSource = clientes.GetList(c => true);
            NombresComboBox.ValueMember = "ClienteId";
            NombresComboBox.DisplayMember = "Nombres";

            ProductoComboBox.DataSource = productos.GetList(p => true);
            ProductoComboBox.ValueMember = "ProductoId";
            ProductoComboBox.DisplayMember = "Descripcion";

            //FiltrarPrecio();

        }

        private void FiltrarPrecio()
        {
            Productos precio = (Productos)ProductoComboBox.SelectedItem;
            PrecioNumericUpDown.Value = precio.Precio;
        }

        private Facturas LlenaClase()
        {

            Facturas facturas = new Facturas();
            facturas.FacturaId = (int)IdNumericUpDown.Value;
            facturas.Fecha = FechaDateTimePicker.Value.Date;
            facturas.ClienteId = (int)NombresComboBox.SelectedValue;
            facturas.SubTotal = SubTotalNumericUpDown.Value;
            facturas.Itbis = ItbisNumericUpDown.Value;
            facturas.Total = TotalNumericUpDown.Value;

            foreach (DataGridViewRow item in DetalleFacturaDataGridView.Rows)
            {
                facturas.AgregarDetalle(
                    ToInt(item.Cells["Id"].Value),
                    ToInt(item.Cells["FacturaId"].Value),
                    ToInt(item.Cells["ProductoId"].Value),
                    ToInt(item.Cells["Cantidad"].Value),
                    ToInt(item.Cells["Precio"].Value),
                    ToInt(item.Cells["Importe"].Value)
                    );
            }
            return facturas;
        }

        private int ToInt(object valor)
        {
            int retorn = 0;
            int.TryParse(valor.ToString(), out retorn);
            return retorn;
        }

        private bool Validar()
        {
            bool Validar = false;

            if (string.IsNullOrWhiteSpace(NombresComboBox.Text))
            {
                MyErrorProvider.SetError(NombresComboBox, "Debe Registrar Clientes");
                Validar = true;
            }

            if (string.IsNullOrWhiteSpace(ProductoComboBox.Text))
            {
                MyErrorProvider.SetError(ProductoComboBox, "Debe Registrar Productos");
                Validar = true;
            }
            

            return Validar;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Facturas> repositorio = new Repositorio<Facturas>();
            Facturas facturas = FacturasBLL.Buscar((int)IdNumericUpDown.Value);

            if (Validar())
            {
                MessageBox.Show("Hay Campos Que Deben Ser Revisados", "Validacion!!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                MyErrorProvider.Clear();
                return;
            }


            if (facturas == null)
            {
                if (FacturasBLL.Guardar(LlenaClase()))
                {
                    MessageBox.Show("Guardado Correctamente", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                    MessageBox.Show("No Se Pudo Registrar La Factura", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (FacturasBLL.Modificar(LlenaClase()))
                {
                    MessageBox.Show("Modificado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                    MessageBox.Show("No Se Pudo Modificar La Factura", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            IdNumericUpDown.Value = 0;
            FechaDateTimePicker.ResetText();
            NombresComboBox.SelectedIndex = 0;
            ProductoComboBox.SelectedIndex = 0;
            DetalleFacturaDataGridView.DataSource = null;
            SubTotalNumericUpDown.Value = 0;
            ItbisNumericUpDown.Value = 0;
            TotalNumericUpDown.Value = 0;
            CantidadNumericUpDown.Value = 0;
            MyErrorProvider.Clear();

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Facturas> repositorio = new Repositorio<Facturas>();
            Facturas facturas = FacturasBLL.Buscar((int)IdNumericUpDown.Value);

            if (facturas != null)
            {
                FacturasBLL.Eliminar(facturas.FacturaId);
                MessageBox.Show("Eliminado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NuevoButton.PerformClick();
            }
            else
                MessageBox.Show("No Se Puso Eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Facturas> repositorio = new Repositorio<Facturas>();
            Facturas facturas = FacturasBLL.Buscar((int)IdNumericUpDown.Value);

            if (facturas != null)
            {

                LlenaCampos(facturas);
                //detalles = facturas.Detalles;
                //DetalleFacturaDataGridView.DataSource = detalles.ToList();


            }
            else
            {
                MessageBox.Show("No Hay Resultados Para La Busqueda", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NuevoButton.PerformClick();
            }
        }
        private void LlenaCamposCombo(FacturasDetalles facturas)
        {
            ProductoComboBox.DisplayMember = (ProductoComboBox.SelectedIndex = (facturas.ProductoId - 1)).ToString();

        }

        private void LlenaCampos(Facturas facturas)
        {
            IdNumericUpDown.Value = facturas.FacturaId;
            FechaDateTimePicker.Value = facturas.Fecha;
            NombresComboBox.DisplayMember = (NombresComboBox.SelectedIndex = (facturas.ClienteId - 1)).ToString();

            SubTotalNumericUpDown.Value = facturas.SubTotal;
            ItbisNumericUpDown.Value = facturas.Itbis;
            TotalNumericUpDown.Value = facturas.Total;

            DetalleFacturaDataGridView.DataSource = facturas.Detalles;
            DetalleFacturaDataGridView.Columns["Id"].Visible = false;
            DetalleFacturaDataGridView.Columns["FacturaId"].Visible = false;
            DetalleFacturaDataGridView.Columns["ProductoId"].Visible = false;


        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            List<FacturasDetalles> detalle = new List<FacturasDetalles>();
            //Repositorio<Productos> repositorio = new Repositorio<Productos>();
            Productos productos = (Productos)ProductoComboBox.SelectedItem;

            if (CantidadNumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(CantidadNumericUpDown, "Digite una cantidad");
                return;

            }

            if (DetalleFacturaDataGridView.DataSource != null)
            {
                detalle = (List<FacturasDetalles>)DetalleFacturaDataGridView.DataSource;
            }
            SubTotal();
            Itbis();
            Total();

            detalle.Add(new FacturasDetalles(
                id: 0,
                facturaId: (int)IdNumericUpDown.Value,
                productoId: (int)ProductoComboBox.SelectedValue,
                cantidad: (int)CantidadNumericUpDown.Value,
                precio: PrecioNumericUpDown.Value,
                importe: ImporteNumericUpDown.Value
                ));
            //Importe();

            DetalleFacturaDataGridView.DataSource = null;
            DetalleFacturaDataGridView.DataSource = detalle;
            DetalleFacturaDataGridView.Columns["Id"].Visible = false;
            DetalleFacturaDataGridView.Columns["FacturaId"].Visible = false;
            DetalleFacturaDataGridView.Columns["ProductoId"].Visible = false;
            CantidadNumericUpDown.Value = 0;
        }
        //calculando importe
        private Decimal Importe()
        {
            if (CantidadNumericUpDown.Value != 0 && PrecioNumericUpDown.Value != 0)
                return ImporteNumericUpDown.Value = CalculosBLL.CalcularImporte(CantidadNumericUpDown.Value, PrecioNumericUpDown.Value);
            else
                return ImporteNumericUpDown.Value = 0;
        }
        //calcualando subtotal
        private Decimal SubTotal()
        {
            if (ImporteNumericUpDown.Value != 0)
                return SubTotalNumericUpDown.Value += CalculosBLL.CalcularSubTotal(ImporteNumericUpDown.Value);
            else
                return SubTotalNumericUpDown.Value = 0;
        }
        //calculando itbis
        private Decimal Itbis()
        {
            if (SubTotalNumericUpDown.Value != 0)
                return ItbisNumericUpDown.Value = CalculosBLL.CalcularItbis(SubTotalNumericUpDown.Value);
            else
                return ItbisNumericUpDown.Value = 0;
        }
        //calculandp total
        private Decimal Total()
        {
            if (SubTotalNumericUpDown.Value != 0 && ItbisNumericUpDown.Value != 0)
                return TotalNumericUpDown.Value = CalculosBLL.CalcularTotal(SubTotalNumericUpDown.Value, ItbisNumericUpDown.Value);
            else
                return TotalNumericUpDown.Value = 0;
        }

        private void DetalleFacturaDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DetalleFacturaDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ProductoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarPrecio();
        }

        private void CantidadNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Importe();

        }

        private void RemoverButton_Click(object sender, EventArgs e)
        {
           
        }

      
    }

}
