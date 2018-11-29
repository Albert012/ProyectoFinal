<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rProductos.aspx.cs" Inherits="SystemsOfSalesWeb.UI.Registros.rProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentCP" runat="server">

        <div class="card card-register mx-auto mt-5">
        <div class="card-header text-uppercase text-center text-primary">Productos</div>
        <div class="card-body">
            <div class="form-row">
                <%--ProductoId--%>
                <div class="form-group col-md-1">
                    <asp:Label Text="Id" class="text-primary " runat="server" />
                    <asp:TextBox ID="ProductoIdTextBox" class="form-control input-group" TextMode="Number" placeholder="0" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ProductoIdTextBox" ValidationGroup="Buscar" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <%--Fecha--%>
                <div class="form-group col-md-2">
                    <asp:Label Text="Fecha" runat="server" />
                    <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
                </div>

                <%--Boton--%>
                <div class="col-lg-1 p-0">
                    <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-outline-info mt-4" ValidationGroup="Buscar" runat="server" OnClick="BuscarLinkButton_Click">
                    <span class="fas fa-search"></span>                         
                    </asp:LinkButton>
                </div>

            </div>

            <div class="form-row">
                <%--Descripcion--%>
                <div class="form-group col-md-3">
                    <label for="DescripcionTextBox">Descripcion</label>
                    <asp:TextBox ID="DescripcionTextBox" class="form-control input-sm" runat="server" AutoCompleteType="Disabled" placeholder="Descripcion"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="DescripcionTextBox" ValidationGroup="Guardar" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-row">
                <%--Costo--%>
                <div class="form-group col-md-2">
                    <label for="CostoTextBox">Costo</label>
                    <asp:TextBox ID="CostoTextBox" class="form-control input-sm" AutoCompleteType="Disabled" TextMode="Number" placeholder="0" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="CostoTextBox" ValidationGroup="Guardar" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CostoCustomValidator" runat="server" ControlToValidate="CostoTextBox" ValidationGroup="Guardar" ForeColor="Red" Display="Dynamic" ErrorMessage="El Costo No Puede Ser Mayor Que El Precio" OnServerValidate="CostoCustomValidator_ServerValidate"></asp:CustomValidator>
                </div>
                <%--Precio--%>
                <div class="form-group col-md-2">
                    <label for="PrecioTextBox">Precio</label>
                    <asp:TextBox ID="PrecioTextBox" class="form-control input-sm" AutoCompleteType="Disabled" TextMode="Number" runat="server" placeholder="0" OnTextChanged="PrecioTextBox_TextChanged"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="PrecioTextBox" ValidationGroup="Guardar" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="PrecioCustomValidator" runat="server" ControlToValidate="PrecioTextBox" ValidationGroup="Guardar" ForeColor="Red" Display="Dynamic" ErrorMessage="El Precio No Puede Ser Menor Que El Costo" OnServerValidate="PrecioCustomValidator_ServerValidate"></asp:CustomValidator>
                </div>
            </div>

            <div class="form-row">
                <%--Ganacias--%>
                <div class="form-group col-md-2">
                    <label for="GanaciasTextBox">Ganacias</label>
                    <asp:TextBox ID="GanaciasTextBox" class="form-control input-sm" TextMode="Number" ReadOnly="true" runat="server" placeholder="0" OnTextChanged="GanaciasTextBox_TextChanged"></asp:TextBox>
                </div>

                <%--Inventario--%>
                <div class="form-group col-md-2">
                    <label for="InventarioTextBox">Inventario</label>
                    <asp:TextBox ID="InventarioTextBox" class="form-control input-sm" TextMode="Number" ReadOnly="true" runat="server" placeholder="0"></asp:TextBox>
                </div>
            </div>           

            <%--Botones--%>
            <div class="card-footer">
                <div class="justify-content-start">
                    <div class="form-group" style="display: inline-block">

                        <asp:LinkButton ID="NuevoLinkButton"  CssClass="btn btn-outline-info mt-4" runat="server" OnClick="NuevoLinkButton_Click">
                            <span class="fas fa-plus"></span>
                            Nuevo
                        </asp:LinkButton>

                        <asp:LinkButton ID="GuardarLinkButton" ValidationGroup="Guardar" CssClass="btn btn-outline-success mt-4" runat="server" OnClick="GuardarLinkButton_Click">
                            <span class="fas fa-save"></span>
                            Guardar
                        </asp:LinkButton>

                        <asp:LinkButton ID="EliminarLinkButton" ValidationGroup="Buscar"  CssClass="btn btn-outline-danger mt-4" runat="server" OnClick="EliminarLinkButton_Click">
                            <span class="fas fa-trash-alt"></span>
                            Eliminar
                        </asp:LinkButton>
                       
                    </div>
                </div>
            </div>


        </div>
    </div>                   

</asp:Content>
