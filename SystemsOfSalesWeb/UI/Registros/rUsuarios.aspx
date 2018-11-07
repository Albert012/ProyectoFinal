<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="SystemsOfSalesWeb.UI.Registros.rUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentCP" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">Productos</div>
        <div class="panel-body">
            <div class="form-row">
                <%--UsuarioId--%>
                <div class="form-group col-md-1">
                    <asp:Label Text="Usuario Id" class="text-primary" runat="server" />
                    <asp:TextBox ID="UsuarioIdTextBox" class="form-control input-group" TextMode="Number" placeholder="0" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="UsuarioIdTextBox" ValidationGroup="Buscar" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <%--Fecha--%>
                <div class="form-group col-md-2">
                    <asp:Label Text="Fecha" runat="server" />
                    <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
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
                <%--Usuario--%>
                <div class="form-group col-md-4">
                    <label for="UsuarioTextBox">Usuario</label>
                    <asp:TextBox ID="UsuarioTextBox" class="form-control input-sm" placeholder="Usuario" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="UsuarioTextBox" ValidationGroup="Guardar" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-row">
                <%--Nombre--%>
                <div class="form-group col-md-4">
                    <label for="NombreTextBox">Nombres</label>
                    <asp:TextBox ID="NombreTextBox" class="form-control input-sm" placeholder="Nombre Completo" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="NombreTextBox" ValidationGroup="Guardar" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>


            <div class="form-row">
                <%--Contrasena--%>
                <div class="form-group col-md-4">
                    <label for="ContrasenaTextBox">Contraseña</label>
                    <asp:TextBox ID="ContrasenaTextBox" class="form-control input-sm" TextMode="Password" placeholder="Contraseña" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ContrasenaTextBox" ValidationGroup="Guardar" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-row">
                <%--Confirmar--%>
                <div class="form-group col-md-4">
                    <label for="ConfirmarTextBox">Confirmar</label>
                    <asp:TextBox ID="ConfirmarTextBox" class="form-control input-sm" TextMode="Password" placeholder="Confirmar Contraseña" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator" runat="server" ControlToValidate="ConfirmarTextBox" ValidationGroup="Guardar" ForeColor="Red" Display="Dynamic" ErrorMessage="Esta Contraseña Es Invalida " OnServerValidate="CustomValidator_ServerValidate"></asp:CustomValidator>
                </div>
            </div>

            <div class="form-row">
                <%--Tipo Usuario--%>
                <div class="form-group col-md-4">
                    <label for="TipoUsuarioDropDownList">Tipo Usuario</label>
                    <asp:DropDownList ID="TipoUsuarioDropDownList" class="form-control input-sm" runat="server">
                        <asp:ListItem Selected="True">Seleccione</asp:ListItem>
                        <asp:ListItem Text="Administrador" />
                        <asp:ListItem Text="Empleado" />
                    </asp:DropDownList>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TipoUsuarioDropDownList" ValidationGroup="Guardar" ForeColor="Red" Display="Dynamic" ErrorMessage="Seleccione Un Tipo De Usuario " OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                </div>
            </div>


            <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>

            <%--Botones--%>
            <div class="panel-footer">
                <div class="justify-content-start">
                    <div class="form-group" style="display: inline-block">
                        <asp:Button Text="Nuevo" class="btn btn-outline-info btn-md" type="submit" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                        <asp:Button Text="Guardar" class="btn btn-outline-success btn-md" runat="server" ValidationGroup="Guardar" ID="GuadarButton" OnClick="GuadarButton_Click" />
                        <asp:Button Text="Eliminar" class="btn btn-outline-danger btn-md" ValidationGroup="Buscar" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />

                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>

