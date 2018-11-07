<%@ Page Title="Consulta Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cClientes.aspx.cs" Inherits="SystemsOfSalesWeb.UI.Consultas.cClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentCP" runat="server">

    <div class="panel panel-primary">
        <div class="panel-heading">Clientes</div>
        <div class="panel-body">

            <div class="form-row justify-content-center">
                <%--Filtro--%>
                <div class="form-group col-md-2">
                    <asp:Label Text="Filtro" class="text-primary" runat="server" />
                    <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>ClienteId</asp:ListItem>
                        <asp:ListItem>Fecha</asp:ListItem>
                        <asp:ListItem>Nombre</asp:ListItem>
                        <asp:ListItem>Apellido</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <%--Criterio--%>
                <div class="form-group col-md-3">
                    <asp:Label ID="Label1" runat="server" Text="Buscar">Buscar:</asp:Label>
                    <asp:TextBox ID="CriterioTextBox" class="form-control input-group" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-1 p-0">
                    <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-outline-info mt-4" runat="server">
                <span class="fas fa-search"></span>
                 Buscar
            </asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
