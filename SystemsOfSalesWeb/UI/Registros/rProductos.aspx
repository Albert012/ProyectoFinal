<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rProductos.aspx.cs" Inherits="SystemsOfSalesWeb.UI.Registros.rProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentCP" runat="server">

        <div class="panel panel-primary">
        <div class="panel-heading">Productos</div>
        <div class="panel-body">
            <div class="form-row">
                <%--ProductoId--%>
                <div class="form-group col-md-1">
                    <asp:Label Text="Id" class="text-primary" runat="server" />
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
                         Buscar
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
                </div>
                <%--Precio--%>
                <div class="form-group col-md-2">
                    <label for="PrecioTextBox">Precio</label>
                    <asp:TextBox ID="PrecioTextBox" class="form-control input-sm" AutoCompleteType="Disabled" TextMode="Number" runat="server" placeholder="0"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="PrecioTextBox" ValidationGroup="Guardar" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-row">
                <%--Ganacias--%>
                <div class="form-group col-md-2">
                    <label for="GanaciasTextBox">Ganacias</label>
                    <asp:TextBox ID="GanaciasTextBox" class="form-control input-sm" TextMode="Number" ReadOnly="true" runat="server" placeholder="0"></asp:TextBox>
                </div>

                <%--Inventario--%>
                <div class="form-group col-md-2">
                    <label for="InventarioTextBox">Inventario</label>
                    <asp:TextBox ID="InventarioTextBox" class="form-control input-sm" TextMode="Number" ReadOnly="true" runat="server" placeholder="0"></asp:TextBox>
                </div>

                <%--Boton--%>
                <div class="col-lg-1 p-0">
                    <asp:LinkButton ID="LinkButton" CssClass="btn btn-outline-info mt-4" runat="server" data-toggle="modal" data-target="#myModal">
                    <span class="fas fa-search"></span>
                         Add
                    </asp:LinkButton>
                </div>

            </div>
           
                    <%--Modal para dar inventario--%>
                    <div class="modal fade" id="myModal" tabindex="-1" aria-hidden="true" role="dialog">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title">Inventario</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <div class="form-row">
                                        <%--InventarioId--%>
                                        <div class="form-group col-md-2">
                                            <asp:Label Text="Id" class="text-primary" runat="server" />
                                            <asp:TextBox ID="InventarioIdTextBox" class="form-control input-group" TextMode="Number" placeholder="0" runat="server" />
                                        </div>

                                        <%--Fecha--%>
                                        <div class="form-group col-md-5">
                                            <asp:Label Text="Fecha" runat="server" />
                                            <asp:TextBox ID="FechaInventarioTextBox" class="form-control input-group" TextMode="Date" runat="server" />
                                        </div>

                                    </div>

                                    <div class="form-row">
                                        <%--Producto--%>
                                        <div class="form-group col-md-5">
                                            <label for="ProductoDropDownList">Producto</label>
                                            <asp:DropDownList ID="ProductoDropDownList" AutoPostBack="true" class="form-control input-sm" runat="server">
                                                <asp:ListItem Selected="True">[Seleccione]</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                        <%--Cantidad--%>
                                        <div class="form-group col-md-3">
                                            <label for="CantidadTextBox">Cantidad</label>
                                            <asp:TextBox ID="CantidadTextBox" class="form-control input-sm" TextMode="Number" runat="server" placeholder="0"></asp:TextBox>
                                        </div>

                                    </div>

                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="AddButton" runat="server" class="btn btn-outline-success" Text="Save" OnClick="AddButton_Click" />
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>

                                </div>
                            </div>
                        </div>
                    </div>

            <%--Botones--%>
            <div class="panel-footer">
                <div class="justify-content-start">
                    <div class="form-group" style="display: inline-block">
                        <asp:Button Text="Nuevo" class="btn btn-outline-info btn-md" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                        <asp:Button Text="Guardar" class="btn btn-outline-success btn-md" ValidationGroup="Guardar" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click" />
                        <asp:Button Text="Eliminar" class="btn btn-outline-danger btn-md" ValidationGroup="Buscar" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />

                    </div>
                </div>
            </div>


        </div>
    </div>                   

</asp:Content>
