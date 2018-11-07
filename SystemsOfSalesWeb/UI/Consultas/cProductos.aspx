<%@ Page Title="Consulta Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cProductos.aspx.cs" Inherits="SystemsOfSalesWeb.UI.Consultas.cProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentCP" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">Productos</div>
        <div class="panel-body">
            <div class="form-row justify-content-center">
                <%--Filtro--%>
                <div class="form-group col-md-2">
                    <asp:Label Text="Filtro" class="text-primary" runat="server" />
                    <asp:DropDownList ID="FiltroDropDownList"  CssClass="form-control" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>ProductoId</asp:ListItem>
                        <asp:ListItem>Descripcion</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <%--Criterio--%>
                <div class="form-group col-md-3">
                    <asp:Label ID="Label1" runat="server" Text="Buscar">Buscar:</asp:Label>
                    <asp:TextBox ID="CriterioTextBox" AutoCompleteType="Disabled" class="form-control input-group" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-1 p-0">
                    <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-outline-info mt-4" runat="server" OnClick="BuscarLinkButton_Click">
                <span class="fas fa-search"></span>
                 Buscar
            </asp:LinkButton>
                </div>
            </div>

            <div class="form-row justify-content-center">
                <asp:GridView ID="ProductoGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="LightSkyBlue" />
                    
                    <Columns>
                        <asp:BoundField DataField="ProductoId" HeaderText="Producto Id" />
                        <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                        <asp:BoundField DataField="Costo" HeaderText="Costo" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                        <asp:BoundField DataField="Ganancias" HeaderText="Ganancias" />
                        <asp:BoundField DataField="Inventario" HeaderText="Inventario" />

                    </Columns>
                    <HeaderStyle BackColor="LightSeaGreen" Font-Bold="True" />
                    
                    
                </asp:GridView>

            </div>
        </div>
    </div>

</asp:Content>
