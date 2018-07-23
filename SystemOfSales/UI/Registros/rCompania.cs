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
    public partial class rCompania : Form
    {
        public rCompania()
        {
            InitializeComponent();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            CompaniaIdNumericUpDown.Value = 0;
            FechaDateTimePicker.ResetText();
            NombreTextBox.Clear();
            EsloganTextBox.Clear();
            DireccionTextBox.Clear();
            EmailTextBox.Clear();
            TelefonoMaskedTextBox.Clear();
            RNCMaskedTextBox.Clear();
            MyErrorProvider.Clear();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Compania> repositorio = new Repositorio<Compania>(new Contexto());
            Compania compania = repositorio.Buscar((int)CompaniaIdNumericUpDown.Value);

            if (Validar())
            {
                MessageBox.Show("Hay Campos Que Deben Ser Revisados", "Validacion!!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }


            if (compania == null)
            {
                if (repositorio.Guardar(LlenaClase()))
                {
                    MessageBox.Show("Guardado Correctamente", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                    MessageBox.Show("No Se Pudo Registrar La Compañia", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (repositorio.Modificar(LlenaClase()))
                {
                    MessageBox.Show("Modificado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                    MessageBox.Show("No Se Pudo Modificar La Compañia", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Compania> repositorio = new Repositorio<Compania>(new Contexto());
            Compania compania = repositorio.Buscar((int)CompaniaIdNumericUpDown.Value);

            if (compania != null)
            {
                repositorio.Eliminar(compania.CompaniaId);
                MessageBox.Show("Eliminado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NuevoButton.PerformClick();
            }
            else
                MessageBox.Show("No Se Puso Eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Compania> repositorio = new Repositorio<Compania>(new Contexto());
            Compania compania = repositorio.Buscar((int)CompaniaIdNumericUpDown.Value);

            if (compania != null)
            {
                FechaDateTimePicker.Value = compania.Fecha;
                NombreTextBox.Text = compania.Nombre;
                DireccionTextBox.Text = compania.Direccion;
                EsloganTextBox.Text = compania.Eslogan;
                TelefonoMaskedTextBox.Text = compania.Telefono;
                EmailTextBox.Text = compania.Email;
                RNCMaskedTextBox.Text = compania.RNC;
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

            if(string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                MyErrorProvider.SetError(NombreTextBox, "Debes Ingresar El Nombre");
                Validar = true;
            }

            if (string.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                MyErrorProvider.SetError(DireccionTextBox, "Debes Ingresar La Direccion");
                Validar = true;
            }

            if (string.IsNullOrWhiteSpace(EsloganTextBox.Text))
            {
                MyErrorProvider.SetError(EsloganTextBox, "Debes Ingresar El Eslogan");
                Validar = true;
            }

            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MyErrorProvider.SetError(EmailTextBox, "Debes Ingresar El Email");
                Validar = true;
            }

            if (string.IsNullOrWhiteSpace(TelefonoMaskedTextBox.Text))
            {
                MyErrorProvider.SetError(TelefonoMaskedTextBox, "Debes Ingresar El Telefono");
                Validar = true;
            }

            if (string.IsNullOrWhiteSpace(RNCMaskedTextBox.Text))
            {
                MyErrorProvider.SetError(RNCMaskedTextBox, "Debes Ingresar El RNC");
                Validar = true;
            }

            return Validar;
        }

        private Compania LlenaClase()
        {
            Compania compania = new Compania();
            compania.CompaniaId = (int)CompaniaIdNumericUpDown.Value;
            compania.Fecha = FechaDateTimePicker.Value.Date;
            compania.Nombre = NombreTextBox.Text;
            compania.Direccion = DireccionTextBox.Text;
            compania.Eslogan = EsloganTextBox.Text;
            compania.Telefono = TelefonoMaskedTextBox.Text;
            compania.RNC = RNCMaskedTextBox.Text;
            return compania;
        }

    }
}
