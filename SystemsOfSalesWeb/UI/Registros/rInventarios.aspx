<%@ Page Title="Inventario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rInventarios.aspx.cs" Inherits="SystemsOfSalesWeb.UI.Registros.rInventarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentCP" runat="server">

    <div class="form-row">
        <%--InventarioId--%>
        <div class="form-group col-md-2">
            <asp:Label Text="Inventario Id" class="text-primary" runat="server" />
            <asp:TextBox ID="InventarioIdTextBox" class="form-control input-group" TextMode="Number" placeholder="0" runat="server" />
        </div>
        <%--Fecha--%>
        <div class="form-group col-md-2">
            <asp:Label Text="Fecha" runat="server" />
            <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
        </div>

        <%--Boton--%>
        <div class="col-lg-1 p-0">
            <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-outline-info mt-4" runat="server" OnClick="BuscarLinkButton_Click">
                <span class="fas fa-search"></span>
                     Buscar
            </asp:LinkButton>
        </div>

    </div>

    <div class="form-row">
        <%--Producto--%>
        <div class="form-group col-md-3">
            <label for="ProductoDropDownList">Producto</label>
            <asp:DropDownList ID="ProductoDropDownList" class="form-control input-sm" runat="server">
                <asp:ListItem Selected="True">[Seleccione]</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-row">
        <%--Cantidad--%>
        <div class="form-group col-md-3">
            <label for="CantidadTextBox">Cantidad</label>
            <asp:TextBox ID="CantidadTextBox" class="form-control input-sm" TextMode="Number" runat="server" placeholder="0"></asp:TextBox>
        </div>
    </div>

    <div class="form-row">
        <asp:Label Text="" ID="ErroLabel" runat="server" />
    </div>


    <%--Botones--%>
    <div class="panel-footer">
        <div class="justify-content-start">
            <div class="form-group" style="display: inline-block">
                <asp:Button Text="Nuevo" class="btn btn-outline-info btn-md" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                <asp:Button Text="Guardar" class="btn btn-outline-success btn-md" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click" />
                <asp:Button Text="Eliminar" class="btn btn-outline-danger btn-md" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />

            </div>
        </div>
    </div>





</asp:Content>
