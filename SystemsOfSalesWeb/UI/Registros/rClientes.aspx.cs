using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemsOfSalesWeb.Utilitarios;

namespace SystemsOfSalesWeb.UI.Registros
{
    public partial class rClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if(!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                int id = Utils.ToInt(Request.QueryString["id"]);
                if(id >0)
                {
                    Repositorio<Clientes> repositorio = new Repositorio<Clientes>();
                    var cliente = repositorio.Buscar(id);

                    if (cliente == null)
                        Utils.MostrarMensaje(this, "No Hay Resultado", "Error", "error");
                    else
                        LlenaCampos(cliente);
                }
            }

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Clientes> repositorio = new Repositorio<Clientes>();
            Clientes cliente = repositorio.Buscar(Utils.ToInt(ClienteIdTextBox.Text));

            if(cliente == null)
            {
                if(repositorio.Guardar(LlenaClase()))
                {
                    Utils.MostrarMensaje(this, "Guardado", "Exito!!", "success");
                    Limpiar();
                }
                else
                {
                    Utils.MostrarMensaje(this, "No Guardado", "Error", "error");
                    Limpiar();
                }
            }
            else
            {
                if (repositorio.Modificar(LlenaClase()))
                {
                    Utils.MostrarMensaje(this, "Modificado", "Exito!!", "info");
                    Limpiar();
                }
                else
                {
                    Utils.MostrarMensaje(this, "No Modificado", "Error", "error");
                    Limpiar();
                }

            }

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Clientes> repositorio = new Repositorio<Clientes>();
            Clientes clientes = repositorio.Buscar(Utils.ToInt(ClienteIdTextBox.Text));

            if(clientes != null)
            {
                repositorio.Eliminar(clientes.ClienteId);
                Utils.MostrarMensaje(this, "Eliminado", "Exito!!", "success");
                Limpiar();
            }
            else
            {
                Utils.MostrarMensaje(this, "No Eliminado", "Error", "error");
                Limpiar();
            }
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Clientes> repositorio = new Repositorio<Clientes>();
            Clientes clientes = repositorio.Buscar(Utils.ToInt(ClienteIdTextBox.Text));

            if (clientes != null)
            {
                Utils.MostrarMensaje(this, "Hay Resultado", "Exito!!", "info");
                Limpiar();
                LlenaCampos(clientes);
            }
            else
            {
                Utils.MostrarMensaje(this, "No Hay Resultado", "Error", "error");
                Limpiar();
            }
        }

        //Metodos

        private Clientes LlenaClase()
        {
            Clientes cliente = new Clientes();
            cliente.ClienteId = Utils.ToInt(ClienteIdTextBox.Text);
            cliente.Fecha = Utils.ToDateTime(FechaTextBox.Text);
            cliente.Nombres = NombreTextBox.Text;
            cliente.Apellidos = ApellidoTextBox.Text;
            cliente.Direccion = DireccionTextBox.Text;
            cliente.Email = EmailTextBox.Text;
            cliente.Cedula = CedulaTextBox.Text;
            cliente.Sexo = SexoDropDownList.Text;
            cliente.Telefono = TelefonoTextBox.Text;
            cliente.Balance = Utils.ToDecimal(BalanceTextBox.Text);

            return cliente;
        }

        private void LlenaCampos(Clientes cliente)
        {
            ClienteIdTextBox.Text = cliente.ClienteId.ToString();
            FechaTextBox.Text = cliente.Fecha.ToString("yyyy-MM-dd");
            NombreTextBox.Text = cliente.Nombres;
            ApellidoTextBox.Text = cliente.Apellidos;
            DireccionTextBox.Text = cliente.Direccion;
            EmailTextBox.Text = cliente.Email;
            CedulaTextBox.Text = cliente.Cedula;
            SexoDropDownList.Text = cliente.Sexo;
            TelefonoTextBox.Text = cliente.Telefono;
            BalanceTextBox.Text = cliente.Balance.ToString();

        }

        private void Limpiar()
        {
            ClienteIdTextBox.Text = "";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            NombreTextBox.Text = "";
            ApellidoTextBox.Text = "";
            DireccionTextBox.Text = "";
            EmailTextBox.Text = "";
            CedulaTextBox.Text = "";
            SexoDropDownList.SelectedIndex = 0;
            TelefonoTextBox.Text = "";
            BalanceTextBox.Text = "";
        }  

    }
}