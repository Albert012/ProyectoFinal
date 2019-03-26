<%@ Page Title="Inventario" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="rInventarios.aspx.cs" Inherits="SystemsOfSalesWeb.UI.Registros.rInventarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentCP" runat="server">
    <div class="card card-register mx-auto mt-5">
        <div class="card-header text-uppercase text-center text-primary">Dar Inventario a Producto</div>
        <div class="card-body">
            <div class="form-row">
                <%--InventarioId--%>
                <div class="form-group col-md-1">
                    <asp:Label Text="Id" class="text-primary" runat="server" />
                    <asp:TextBox ID="InventarioIdTextBox" class="form-control input-group" TextMode="Number" placeholder="0" runat="server" />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="InventarioIdTextBox" ValidationGroup="Buscar" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
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
            </asp:LinkButton>
                </div>

            </div>

            <div class="form-row">
                <%--Producto--%>
                <div class="form-group col-md-2">
                    <label for="ProductoDropDownList">Producto</label>
                    <asp:DropDownList ID="ProductoDropDownList" class="form-control input-sm" runat="server">
                        <asp:ListItem Selected="True">[Seleccione]</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CustomValidator ID="CVProducto" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="ProductoDropDownList" ValidationGroup="Guardar" ErrorMessage="Seleccione Un Producto" OnServerValidate="CVProducto_ServerValidate"></asp:CustomValidator>

                </div>

                <%--Cantidad--%>
                <div class="form-group col-md-1">
                    <label for="CantidadTextBox">Cantidad</label>
                    <asp:TextBox ID="CantidadTextBox" class="form-control input-sm" AutoCompleteType="Disabled" TextMode="Number" runat="server" placeholder="0"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="CantidadTextBox" ValidationGroup="Guardar" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>


            </div>

            <%--GridDetalle--%>
           <%-- <div class="form-row justify-content-center">
                <asp:GridView ID="DetalleInventarioGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="LightSkyBlue" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" />
                        <asp:BoundField DataField="ProductoId" HeaderText="Producto Id" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    </Columns>
                    <HeaderStyle BackColor="LightSeaGreen" Font-Bold="True" />
                </asp:GridView>
            </div>--%>




            <%--Botones--%>
            <div class="card-footer">
                <div class="justify-content-start">
                    <div class="form-group" style="display: inline-block">
                        <asp:LinkButton ID="NuevoLinkButton"  CssClass="btn btn-outline-info mt-4" runat="server" OnClick="NuevoLinkButton_Click"  >
                            <span class="fas fa-plus"></span>
                            Nuevo
                        </asp:LinkButton>

                        <asp:LinkButton ID="GuardarLinkButton" ValidationGroup="Guardar" CssClass="btn btn-outline-success mt-4" runat="server" OnClick="GuardarLinkButton_Click"  >
                            <span class="fas fa-save"></span>
                            Guardar
                        </asp:LinkButton>

                        <asp:LinkButton ID="EliminarLinkButton" ValidationGroup="Buscar"  CssClass="btn btn-outline-danger mt-4" runat="server" OnClick="EliminarLinkButton_Click"  >
                            <span class="fas fa-trash-alt"></span>
                            Eliminar
                        </asp:LinkButton>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
