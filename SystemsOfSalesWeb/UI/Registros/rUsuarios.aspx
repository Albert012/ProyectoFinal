<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="SystemsOfSalesWeb.UI.Registros.rUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentCP" runat="server">

    <div class="panel panel-primary">
        <div class="panel-heading">Registro Usuario </div>
        <div class="panel-body">
            <div class="form-horizontal col-md-12" role="form">
                <%--UsuarioId--%>
                <div class="form-group">
                    <label for="UsuarioIdTextBox" class="text-primary">Usuario ID</label>
                    <asp:TextBox ID="UsuarioIdTextBox" class="form-control input-sm" placeholder="0" runat="server"></asp:TextBox>
                </div>

                <%--Fecha--%>
                <div class="form-group">
                    <label for="FechaTextBox">Fecha</label>
                    <asp:TextBox ID="FechaTextBox" TextMode="Date" class="form-control input-sm" runat="server"></asp:TextBox>
                </div>

                <%--Usuario--%>
                <div class="form-group">
                    <label for="UsuarioTextBox">Usuario</label>
                    <asp:TextBox ID="UsuarioTextBox" class="form-control input-sm" placeholder="Usuario" runat="server"></asp:TextBox>
                </div>

                <%--Nombre--%>
                <div class="form-group">
                    <label for="NombreTextBox">Nombre</label>
                    <asp:TextBox ID="NombreTextBox" class="form-control input-sm" placeholder="Nombre Usuario" runat="server"></asp:TextBox>
                </div>

                <%--Contrasena--%>
                <div class="form-group">
                    <label for="ContrasenaTextBox">Contraseña</label>
                    <asp:TextBox ID="ContrasenaTextBox" class="form-control input-sm" TextMode="Password" placeholder="Contraseña" runat="server"></asp:TextBox>
                </div>

                <%--Confirmar--%>
                <div class="form-group">
                    <label for="ConfirmarTextBox">Confirmar</label>
                    <asp:TextBox ID="ConfirmarTextBox" class="form-control input-sm" TextMode="Password" placeholder="Confirmar Contraseña" runat="server"></asp:TextBox>
                </div>
            </div>
            <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
        </div>

        <%--Botones--%>
        <div class="panel-footer">
            <div class="text-center">
                <div class="form-group" style="display: inline-block">
                    <asp:Button Text="Nuevo" class="btn btn-outline-info btn-md" typr="submit" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                    <asp:Button Text="Guardar" class="btn btn-outline-success btn-md" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click" />
                    <asp:Button Text="Eliminar" class="btn btn-outline-danger btn-md" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />

                </div>
            </div>

        </div>

    </div>

</asp:Content>

