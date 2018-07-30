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
using System.Linq.Expressions;
using SystemOfSales.UI.Reportes;

namespace SystemOfSales.UI.Consultas
{
    public partial class cUsuarios : Form
    {
        private List<Usuarios> usuarios = new List<Usuarios>();

        public cUsuarios()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Usuarios, bool>> filtro = user => true;
            Repositorio<Usuarios> repositorio = new Repositorio<Usuarios>();
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
                    filtro = user => (user.UsuarioId.Equals(id)) && (user.Fecha >= DesdeDateTimePicker.Value.Date && user.Fecha <= HastaDateTimePicker.Value.Date);
                    break;
                case 2://Usuario
                    filtro = user => (user.Usuario.Contains(CriterioTextBox.Text)) && (user.Fecha >= DesdeDateTimePicker.Value.Date && user.Fecha <= HastaDateTimePicker.Value.Date);
                    break;
                case 3://Nombre
                    filtro = user => (user.NombreUsuario.Contains(CriterioTextBox.Text)) && (user.Fecha >= DesdeDateTimePicker.Value.Date && user.Fecha <= HastaDateTimePicker.Value.Date);
                    break;
                case 4://Tipo
                    filtro = user => (user.TipoUsuario.Contains(CriterioTextBox.Text)) && (user.Fecha >= DesdeDateTimePicker.Value.Date && user.Fecha <= HastaDateTimePicker.Value.Date);
                    break;
               
            }
            usuarios = repositorio.GetList(filtro);

            ConsultaDataGridView.DataSource = usuarios;
        }

        private void ImprimirButton_Click(object sender, EventArgs e)
        {

            if(usuarios.Count == 0)
            {
                MessageBox.Show("No Hay Datos Para Mostrar");
                return;
            }

            ListadoUsuariosReviewer listadoUsuariosReviewer = new ListadoUsuariosReviewer(usuarios);
            listadoUsuariosReviewer.ShowDialog();


        }
    }
}
