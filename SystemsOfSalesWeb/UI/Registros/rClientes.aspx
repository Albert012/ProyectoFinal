<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rClientes.aspx.cs" Inherits="SystemsOfSalesWeb.UI.Registros.rClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentCP" runat="server">

    <div class="card card-register mx-auto mt-5">
        <div class="card-header text-uppercase text-center text-primary">Clientes</div>
        <div class="card-body">

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
                     <%--Buscar--%>
            </asp:LinkButton>
                </div>

            </div>

            <div class="form-row">
                <%--Nombre--%>
                <div class="form-group col-md-3">
                    <asp:Label Text="Nombre" runat="server" />
                    <asp:TextBox ID="NombreTextBox" class="form-control input-sm" AutoCompleteType="Disabled" runat="server" placeholder="Nombres"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVNombre" ValidationGroup="Guardar" ControlToValidate="NombreTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="NombreTextBox" ForeColor="Red" Display="Dynamic" ErrorMessage="Porfavor Digite Solo Letras" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                     </div>

                <%--Apellido--%>
                <div class="form-group col-md-3">
                    <asp:Label Text="Apellido" runat="server" />
                    <asp:TextBox ID="ApellidoTextBox" class="form-control input-sm" AutoCompleteType="Disabled" runat="server" placeholder="Apellidos"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVApellido" ValidationGroup="Guardar" ControlToValidate="ApellidoTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="ApellidoTextBox" ForeColor="Red" Display="Dynamic" ErrorMessage="Porfavor Digite Solo Letras" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                </div>

            </div>


            <div class="form-row">
                <%--Direccion--%>
                <div class="form-group col-md-3">
                    <asp:Label Text="Direccion" runat="server" />
                    <asp:TextBox ID="DireccionTextBox" class="form-control input-sm" AutoCompleteType="Disabled" runat="server" placeholder="Direccion"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Guardar" ControlToValidate="DireccionTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <%--Email--%>
                <div class="form-group col-md-3">
                    <asp:Label Text="Email" runat="server" />
                    <asp:TextBox ID="EmailTextBox" class="form-control input-sm" AutoCompleteType="Disabled" TextMode="Email" runat="server" placeholder="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Guardar" ControlToValidate="EmailTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

            </div>

            <div class="form-row">
                <%--Cedula--%>
                <div class="form-group col-md-2">
                    <asp:Label Text="Cedula" runat="server" />
                    <asp:TextBox ID="CedulaTextBox" class="form-control input-sm" AutoCompleteType="Disabled" runat="server" MaxLength="11" placeholder="Cedula"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Guardar" ControlToValidate="CedulaTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="IdRegularExpressionValidator" runat="server" ControlToValidate="CedulaTextBox" ForeColor="Red" Display="Dynamic" ErrorMessage="Porfavor ingrese un numero" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                </div>

                <%--Telefono--%>
                <div class="form-group col-md-2">
                    <asp:Label Text="Télefono" runat="server" />
                    <asp:TextBox ID="TelefonoTextBox" class="form-control input-sm" AutoCompleteType="Disabled" runat="server" TextMode="Phone" MaxLength="10" placeholder="Telefono"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Guardar" ControlToValidate="TelefonoTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TelefonoTextBox" ForeColor="Red" Display="Dynamic" ErrorMessage="Porfavor ingrese un numero" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                </div>

            </div>

            <div class="form-row">
                <%--Sexo--%>
                <div class="form-group col-md-2">
                    <asp:Label Text="Sexo" runat="server" />
                    <asp:DropDownList ID="SexoDropDownList" class="form-control input-sm" runat="server">
                        <asp:ListItem Selected="True">Seleccione</asp:ListItem>
                        <asp:ListItem Text="Masculino" />
                        <asp:ListItem Text="Femenino" />
                    </asp:DropDownList>
                    <asp:CustomValidator ID="SexoCustomValidator" runat="server" ValidationGroup="Guardar" ControlToValidate="SexoDropDownList" ErrorMessage="Seleccione Un Sexo" Display="Dynamic" ForeColor="Red" OnServerValidate="SexoCustomValidator_ServerValidate" ></asp:CustomValidator>
                </div>
                <%--Balance--%>
                <div class="form-group col-md-2">
                    <asp:Label Text="Balance" runat="server" />
                    <asp:TextBox ID="BalanceTextBox" class="form-control input-sm" runat="server" ReadOnly="true" TextMode="Number" placeholder="0"></asp:TextBox>
                </div>
            </div>

            <%--Botones--%>
            <div class="card-footer">
                <div class="justify-content-start">
                    <div class="form-group" style="display: inline-block">
                        <asp:LinkButton ID="NuevoLinkButton" CssClass="btn btn-outline-info mt-4" runat="server" OnClick="NuevoLinkButton_Click">
                            <span class="fas fa-plus"></span>
                            Nuevo
                        </asp:LinkButton>

                        <asp:LinkButton ID="GuardarLinkButton" ValidationGroup="Guardar" CssClass="btn btn-outline-success mt-4" runat="server" OnClick="GuardarLinkButton_Click">
                            <span class="fas fa-save"></span>
                            Guardar
                        </asp:LinkButton>

                        <asp:LinkButton ID="EliminarLinkButton" ValidationGroup="Buscar" CssClass="btn btn-outline-danger mt-4" runat="server" OnClick="EliminarLinkButton_Click">
                            <span class="fas fa-trash-alt"></span>
                            Eliminar
                        </asp:LinkButton>
                    </div>
                </div>
            </div>


        </div>
    </div>



</asp:Content>
