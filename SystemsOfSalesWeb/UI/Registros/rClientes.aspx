<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rClientes.aspx.cs" Inherits="SystemsOfSalesWeb.UI.Registros.rClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentCP" runat="server">

    <div class="panel panel-primary">
        <div class="panel-heading">Clientes</div>
        <div class="panel-body">

            <div class="form-row">
                <%--ClienteId--%>
                <div class="form-group col-md-1">
                    <asp:Label Text="Id" class="text-primary" runat="server" />
                    <asp:TextBox ID="ClienteIdTextBox" class="form-control input-group" AutoCompleteType="None" TextMode="Number" placeholder="0" runat="server" />
                    <asp:RequiredFieldValidator ID="RFVClienteId" ValidationGroup="Buscar" ControlToValidate="ClienteIdTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <%--Fecha--%>
                <div class="form-group col-md-2">
                    <asp:Label Text="Fecha" runat="server" />
                    <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
                    <asp:RequiredFieldValidator ID="RFVFFecha" ValidationGroup="Guardar" ControlToValidate="FechaTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <%--Boton--%>
                <div class="col-lg-1 p-0">
                    <asp:LinkButton ID="BuscarLinkButton" ValidationGroup="Buscar" CssClass="btn btn-outline-info mt-4" runat="server" OnClick="BuscarLinkButton_Click">
                <span class="fas fa-search"></span>
                     Buscar
            </asp:LinkButton>
                </div>

            </div>

            <div class="form-row">
                <%--Nombre--%>
                <div class="form-group col-md-3">
                    <label for="NombreTextBox">Nombres</label>
                    <asp:TextBox ID="NombreTextBox" class="form-control input-sm" AutoCompleteType="Disabled" runat="server" placeholder="Nombres"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVNombre" ValidationGroup="Guardar" ControlToValidate="NombreTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <%--Apellido--%>
                <div class="form-group col-md-3">
                    <label for="ApellidoTextBox">Apellidos</label>
                    <asp:TextBox ID="ApellidoTextBox" class="form-control input-sm" AutoCompleteType="Disabled" runat="server" placeholder="Apellidos"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVApellido" ValidationGroup="Guardar" ControlToValidate="ApellidoTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

            </div>


            <div class="form-row">
                <%--Direccion--%>
                <div class="form-group col-md-3">
                    <label for="DireccionTextBox">Direccion</label>
                    <asp:TextBox ID="DireccionTextBox" class="form-control input-sm" AutoCompleteType="Disabled" runat="server" placeholder="Direccion"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Guardar" ControlToValidate="DireccionTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <%--Email--%>
                <div class="form-group col-md-3">
                    <label for="EmailTextBox">Email</label>
                    <asp:TextBox ID="EmailTextBox" class="form-control input-sm" AutoCompleteType="Disabled" type="email" runat="server" placeholder="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Guardar" ControlToValidate="EmailTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

            </div>

            <div class="form-row">
                <%--Cedula--%>
                <div class="form-group col-md-2">
                    <label for="CedulaTextBox">Cedula</label>
                    <asp:TextBox ID="CedulaTextBox" class="form-control input-sm" AutoCompleteType="Disabled" runat="server" MaxLength="11" placeholder="Cedula"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Guardar" ControlToValidate="CedulaTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <%--Telefono--%>
                <div class="form-group col-md-2">
                    <label for="TelefonoTextBox">Telefono</label>
                    <asp:TextBox ID="TelefonoTextBox" class="form-control input-sm" AutoCompleteType="Disabled" runat="server" MaxLength="10" placeholder="Telefono"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Guardar" ControlToValidate="TelefonoTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

            </div>

            <div class="form-row">
                <%--Sexo--%>
                <div class="form-group col-md-2">
                    <label for="SexoDropDownList">Sexo</label>
                    <asp:DropDownList ID="SexoDropDownList" class="form-control input-sm" runat="server">
                        <asp:ListItem Selected="True">[Seleccione]</asp:ListItem>
                        <asp:ListItem Text="Masculino" />
                        <asp:ListItem Text="Femenino" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Guardar" ControlToValidate="SexoDropDownList" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <%--Balance--%>
                <div class="form-group col-md-2">
                    <label for="BalanceTextBox">Balance</label>
                    <asp:TextBox ID="BalanceTextBox" class="form-control input-sm" runat="server" ReadOnly="true" TextMode="Number" placeholder="0"></asp:TextBox>
                </div>
            </div>

            <%--Botones--%>
            <div class="panel-footer">
                <div class="justify-content-start">
                    <div class="form-group" style="display: inline-block">
                        <asp:Button Text="Nuevo" class="btn btn-outline-info btn-md mt-4" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                        <asp:Button Text="Guardar" class="btn btn-outline-success btn-md mt-4" ValidationGroup="Guardar" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click" />
                        <asp:Button Text="Eliminar" class="btn btn-outline-danger btn-md mt-4" runat="server" ValidationGroup="Buscar" ID="EliminarButton" OnClick="EliminarButton_Click" />

                    </div>
                </div>
            </div>


        </div>
    </div>



</asp:Content>
