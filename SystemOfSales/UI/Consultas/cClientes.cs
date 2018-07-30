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
    public partial class cClientes : Form
    {
        private List<Clientes> clientes = new List<Clientes>();

        public cClientes()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Clientes, bool>> filtro = cli => true;
            Repositorio<Clientes> repositorio = new Repositorio<Clientes>();
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
                    filtro = cli => (cli.ClienteId.Equals(id)) && (cli.Fecha >= DesdeDateTimePicker.Value.Date && cli.Fecha <= HastaDateTimePicker.Value.Date);
                    break;
                case 2://Nombre
                    filtro = cli => (cli.Nombres.Contains(CriterioTextBox.Text)) && (cli.Fecha >= DesdeDateTimePicker.Value.Date && cli.Fecha <= HastaDateTimePicker.Value.Date);
                    break;
                case 3://Direccion
                    filtro = cli => (cli.Direccion.Contains(CriterioTextBox.Text)) && (cli.Fecha >= DesdeDateTimePicker.Value.Date && cli.Fecha <= HastaDateTimePicker.Value.Date);
                    break;
                case 4://Cedula
                    filtro = cli => (cli.Cedula.Contains(CriterioTextBox.Text)) && (cli.Fecha >= DesdeDateTimePicker.Value.Date && cli.Fecha <= HastaDateTimePicker.Value.Date);
                    break;

            }

            clientes = repositorio.GetList(filtro);
            ConsultaDataGridView.DataSource = clientes;
        }

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            if (clientes.Count == 0)
            {
                MessageBox.Show("No Hay Datos Para Mostrar");
                return;
            }

            ListadoClientesReviewer listadoClientesReviewer = new ListadoClientesReviewer(clientes);
            listadoClientesReviewer.ShowDialog();
            
        }
    }
}
