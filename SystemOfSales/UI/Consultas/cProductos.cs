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
using System.Linq.Expressions;
using SystemOfSales.UI.Reportes;

namespace SystemOfSales.UI.Consultas
{
    public partial class cProductos : Form
    {
        private List<Productos> productos = new List<Productos>();

        public cProductos()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {

            Expression<Func<Productos, bool>> filtro = pro => true;
            Repositorio<Productos> repositorio = new Repositorio<Productos>();
            int id;

            if (FiltroComboBox.SelectedIndex != 0 && string.IsNullOrWhiteSpace(CriterioTextBox.Text))
            {
                MessageBox.Show("Seleccione Un Filtro y Ingrese Un Criterio De Busqueda", "Fallo Consulta", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }


            switch (FiltroComboBox.SelectedIndex)
            {
                case 0://Todos
                    break;
                case 1://UsuarioId
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = pro => (pro.ProductoId.Equals(id)) && (pro.FechaRegistro >= DesdeDateTimePicker.Value.Date && pro.FechaRegistro <= HastaDateTimePicker.Value.Date);
                    break;
                case 2://Nombre
                    filtro = pro => (pro.Descripcion.Contains(CriterioTextBox.Text)) && (pro.FechaRegistro >= DesdeDateTimePicker.Value.Date && pro.FechaRegistro <= HastaDateTimePicker.Value.Date);
                    break;
                

            }
            productos = repositorio.GetList(filtro);

            ConsultaDataGridView.DataSource = productos;


        }

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            if (productos.Count == 0)
            {
                MessageBox.Show("No Hay Datos Para Mostrar");
                return;
            }
            ListadoProductosReviewer listadoProductosReviewer = new ListadoProductosReviewer(productos);
            listadoProductosReviewer.ShowDialog();
            
        }
    }
}
