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
using SystemOfSales.UI.Reportes;

namespace SystemOfSales.UI.Registros
{
    public partial class rFacturas : Form
    {
        List<FacturasDetalles> detalles = new List<FacturasDetalles>();
        List<FacturasDetalles> Reporte = new List<FacturasDetalles>();
        public rFacturas()
        {
            InitializeComponent();
            LlenaComboBox();
        }

        //Metodos
        
        private void LlenaComboBox()
        {
            Repositorio<Clientes> clientes = new Repositorio<Clientes>();
            Repositorio<Productos> productos = new Repositorio<Productos>();

            NombresComboBox.DataSource = clientes.GetList(c => true);
            NombresComboBox.ValueMember = "ClienteId";
            NombresComboBox.DisplayMember = "Nombres";

            ProductoComboBox.DataSource = productos.GetList(p => p.Inventario > 0);
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
            facturas.Efectivo = EfectivoNumericUpDown.Value;
            facturas.Devuelta = DevueltaNumericUpDown.Value; 
            facturas.Detalles = detalles;
            
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

            if(DetalleFacturaDataGridView.DataSource == null)
            {
                MyErrorProvider.SetError(DetalleFacturaDataGridView, "Agregue Aun Producto");
                Validar = true;
            }
            if (EfectivoNumericUpDown.Value == 0 && EfectivoNumericUpDown.Enabled == true)
            {
                MyErrorProvider.SetError(EfectivoNumericUpDown, "Ingrese Cantidad De Efectivo Recibida");
                Validar = true;
            }


            return Validar;
        }

        private void Recibo()
        {
            DialogResult result = MessageBox.Show("Quieres Imprimir El Recibo", "Facturacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ImprimirButton.PerformClick();
            }
            else
            {
                NuevoButton.PerformClick();
                return;
            }
        }

        private bool Exitencia()
        {
            bool Exitencia = false;

            Repositorio<Productos> repositorio = new Repositorio<Productos>();
            Productos prodcucto = (Productos)ProductoComboBox.SelectedItem;

            if ((int)CantidadNumericUpDown.Value > prodcucto.Inventario)
            {
                MyErrorProvider.SetError(CantidadNumericUpDown, "De Este Articulo Quedan " + prodcucto.Inventario + " Esta Falta de Inventario");
                Exitencia = true;
            }
            return Exitencia;
        }
               
        //Afectar Cliente

        private void GuardarTotal()
        {
            Repositorio<Clientes> repositorio = new Repositorio<Clientes>();
            Clientes clientes = (Clientes)NombresComboBox.SelectedItem;
            clientes.Balance += TotalNumericUpDown.Value;
            repositorio.Modificar(clientes);
        }
        
        private void ModificarTotal()
        {
            Repositorio<Clientes> repositorio = new Repositorio<Clientes>();
            Clientes clientes = (Clientes)NombresComboBox.SelectedItem;
            Decimal TotalAnt = TotalNumericUpDown.Value - clientes.Balance;
            clientes.Balance += TotalAnt;
            repositorio.Modificar(clientes);
        }

        private void EliminarTotal()
        {
            Repositorio<Clientes> repositorio = new Repositorio<Clientes>();
            Clientes clientes = (Clientes)NombresComboBox.SelectedItem;
            clientes.Balance -= TotalNumericUpDown.Value;
            repositorio.Modificar(clientes);
        }

        //Fin Afectar Clientes
           
        
        private void LlenaCampos(Facturas facturas)
        {
            IdNumericUpDown.Value = facturas.FacturaId;
            FechaDateTimePicker.Value = facturas.Fecha;
            NombresComboBox.DisplayMember = (NombresComboBox.SelectedIndex = (facturas.ClienteId - 1)).ToString();

            SubTotalNumericUpDown.Value = facturas.SubTotal;
            ItbisNumericUpDown.Value = facturas.Itbis;
            TotalNumericUpDown.Value = facturas.Total;
            EfectivoNumericUpDown.Value = facturas.Efectivo;
            DevueltaNumericUpDown.Value = facturas.Devuelta;
            detalles = facturas.Detalles;

            DetalleFacturaDataGridView.DataSource = facturas.Detalles;
            DetalleFacturaDataGridView.Columns["Id"].Visible = false;
            DetalleFacturaDataGridView.Columns["FacturaId"].Visible = false;
            DetalleFacturaDataGridView.Columns["ProductoId"].Visible = false;

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

        private Decimal Devuelta()
        {
            if (EfectivoNumericUpDown.Value != 0 && TotalNumericUpDown.Value != 0)
                return DevueltaNumericUpDown.Value = CalculosBLL.CalcularDevuelta(EfectivoNumericUpDown.Value, TotalNumericUpDown.Value);
            else
                return DevueltaNumericUpDown.Value = 0;
        }

        private void Condicion()
        {
            if (CreditoRadioButton.Checked)
                EfectivoNumericUpDown.Enabled = false;
            else
            {
                EfectivoNumericUpDown.Enabled = true;
               
            }
                
        }

        //Fin Metodos

        private void GuardarButton_Click(object sender, EventArgs e)
        {
           
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
                    if (CreditoRadioButton.Checked)
                    { GuardarTotal(); }
                    MessageBox.Show("Guardado Correctamente", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Recibo();

                }
                else
                    MessageBox.Show("No Se Pudo Registrar La Factura", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (FacturasBLL.Modificar(LlenaClase()))
                {
                    if (CreditoRadioButton.Checked) { ModificarTotal(); }
                    MessageBox.Show("Modificado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Recibo();
                }
                else
                    MessageBox.Show("No Se Pudo Modificar La Factura", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            IdNumericUpDown.Value = 0;
            FechaDateTimePicker.ResetText();
            NombresComboBox.ResetText();
            ProductoComboBox.ResetText();
            DetalleFacturaDataGridView.DataSource = null;
            SubTotalNumericUpDown.Value = 0;
            ItbisNumericUpDown.Value = 0;
            TotalNumericUpDown.Value = 0;
            CantidadNumericUpDown.Value = 0;
            detalles.Clear();
            EfectivoNumericUpDown.Value = 0;
            DevueltaNumericUpDown.Value = 0;
            MyErrorProvider.Clear();

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            
            Facturas facturas = FacturasBLL.Buscar((int)IdNumericUpDown.Value);

            if (facturas != null)
            {
                FacturasBLL.Eliminar(facturas.FacturaId);
                //EliminarTotal();
                MessageBox.Show("Eliminado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NuevoButton.PerformClick();
            }
            else
                MessageBox.Show("No Se Puso Eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            
            Facturas facturas = FacturasBLL.Buscar((int)IdNumericUpDown.Value);

            if (facturas != null)
            {

                LlenaCampos(facturas);                

            }
            else
            {
                MessageBox.Show("No Hay Resultados Para La Busqueda", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NuevoButton.PerformClick();
            }
        }
        
        private void AgregarButton_Click(object sender, EventArgs e)
        {
            Productos productos = (Productos)ProductoComboBox.SelectedItem;

            if (CantidadNumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(CantidadNumericUpDown, "Digite una cantidad");
                return;

            }

            if (Exitencia())
            {
                MessageBox.Show("No Quedan Suficientes Articulos", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SubTotal();
            Itbis();
            Total();

            detalles.Add(new FacturasDetalles(
                id: 0,
                facturaId: (int)IdNumericUpDown.Value,
                productoId: (int)ProductoComboBox.SelectedValue,
                cantidad: (int)CantidadNumericUpDown.Value,
                precio: PrecioNumericUpDown.Value,
                importe: ImporteNumericUpDown.Value               
                ));
           

            DetalleFacturaDataGridView.DataSource = null;
            DetalleFacturaDataGridView.DataSource = detalles.ToList();
            DetalleFacturaDataGridView.Columns["Id"].Visible = false;
            DetalleFacturaDataGridView.Columns["FacturaId"].Visible = false;
            DetalleFacturaDataGridView.Columns["ProductoId"].Visible = false;
            CantidadNumericUpDown.Value = 0;
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

        private void rFacturas_Load(object sender, EventArgs e)
        {

        }

        private void ImprimirRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void EfectivoNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if(EfectivoNumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(EfectivoNumericUpDown, "Ingrese El Efectivo");
                return;
            }

            if(EfectivoNumericUpDown.Value < TotalNumericUpDown.Value)
            {
                MyErrorProvider.SetError(EfectivoNumericUpDown, "El Dinero No Alcanza Para Pagar");
                return;
            }
            else
                Devuelta();
        }

        private void ContadoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Condicion();

        }

        private void CreditoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Condicion();
        }

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            
            if (DetalleFacturaDataGridView.DataSource == null)
            {
                MessageBox.Show("No Hay Datos Para Imprimir");
                return;
            }

            ReciboReviewer reciboReviewer = new ReciboReviewer(detalles);
            reciboReviewer.ShowDialog();
        }
    }

}
