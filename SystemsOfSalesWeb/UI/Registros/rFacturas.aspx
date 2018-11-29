<%@ Page Title="Factura" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rFacturas.aspx.cs" Inherits="SystemsOfSalesWeb.UI.Registros.rFacturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentCP" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <%--<asp:UpdatePanel ID="Panel" runat="server" UpdateMode="Conditional">--%>
        <%--<ContentTemplate>--%>
            <div class="card card-register mx-auto mt-5">
                <div class="card-header text-uppercase text-center text-primary">Facturacion</div>
                <div class="card-body">

                    <div class="form-row">
                        <%--FacturaId--%>
                        <div class="form-group col-md-1">
                            <asp:Label Text="Id" class="text-primary" runat="server" />
                            <asp:TextBox ID="FacturaIdTextBox" class="form-control input-sm" TextMode="Number" runat="server" placeholder="0"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVId" ValidationGroup="Buscar" ControlToValidate="FacturaIdTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <%--Fecha--%>
                        <div class="form-group col-md-2">
                            <asp:Label Text="Fecha" runat="server" />
                            <asp:TextBox ID="FechaTextBox" class="form-control input-sm" TextMode="Date" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVFFecha" ValidationGroup="Guardar" ControlToValidate="FechaTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                        <%--Boton--%>
                        <div class="col-lg-1 p-0">
                            <asp:LinkButton ID="BuscarLinkButton" ValidationGroup="Buscar" CssClass="btn btn-outline-info mt-4" runat="server" OnClick="BuscarLinkButton_Click">
                                <span class="fas fa-search"></span>
                                     Buscar
                            </asp:LinkButton>
                        </div>

                        <div class="form-group align-content-end col-md-6 ">
                            <asp:Label Text="Condicion" runat="server" />
                            <asp:RadioButtonList runat="server" RepeatDirection="Vertical" OnSelectedIndexChanged="CondicionRadioButton_SelectedIndexChanged" ID="CondicionRadioButton" AutoPostBack="true" ti CssClass="text-primary">
                                <asp:ListItem Selected="True" Value="1" Text="Credito" ></asp:ListItem>
                                <asp:ListItem Value ="0" Text="Contado"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div class="form-row">
                        <%--Cliente--%>
                        <div class="form-group col-md-3">
                            <asp:Label Text="Cliente" runat="server" />
                            <asp:DropDownList ID="ClienteDropDownList" AutoPostBack="true" class="form-control input-sm" runat="server">
                                <asp:ListItem Selected="True">[Seleccione]</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CustomValidator ID="CVClientes" runat="server" ErrorMessage="Seleccione Un Cliente" ControlToValidate="ClienteDropDownList" ValidationGroup="Guardar" ForeColor="Red" Display="Dynamic" OnServerValidate="CVClientes_ServerValidate"></asp:CustomValidator>
                        </div>
                        <%--Producto--%>
                        <div class="form-group col-md-3">
                            <asp:Label Text="Producto" runat="server" />
                            <asp:DropDownList ID="ProductoDropDownList" class="form-control input-sm" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ProductoDropDownList_SelectedIndexChanged" OnTextChanged="ProductoDropDownList_TextChanged">
                                <asp:ListItem Selected="True">[Seleccione]</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CustomValidator ID="CVProducto" runat="server" ErrorMessage="Seleccione Un Producto" ControlToValidate="ProductoDropDownList" ValidationGroup="Agregar" ForeColor="Red" Display="Dynamic" OnServerValidate="CVProducto_ServerValidate"></asp:CustomValidator>
                        </div>

                        <%--Precio--%>
                        <div class="form-group col-md-1">
                            <asp:Label Text="Precio" runat="server" />
                            <%--<asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">--%>
                                <%--<ContentTemplate>--%>
                                    <asp:TextBox ID="PrecioTextBox" class="form-control input-sm" AutoPostBack="true" ReadOnly="true" TextMode="Number" runat="server" placeholder="0"></asp:TextBox>
                                <%--</ContentTemplate>--%>
                            <%--</asp:UpdatePanel>--%>
                        </div>

                        <%--Cantidad--%>
                        <div class="form-group col-md-1">
                            <asp:Label Text="Cantidad" runat="server" />
                            <%--<asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Always">--%>
                                <%--<ContentTemplate>--%>
                                    <asp:TextBox ID="CantidadTextBox" class="form-control input-sm" AutoPostBack="true" AutoCompleteType="Disabled" TextMode="Number" runat="server" placeholder="0" OnTextChanged="CantidadTextBox_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="Agregar" ControlToValidate="CantidadTextBox" ErrorMessage="No Hay Cantidad"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="CVCantidad" ForeColor="Red" Display="Dynamic" runat="server" ValidationGroup="Agregar" ControlToValidate="CantidadTextBox" ErrorMessage="Cantidad Invalida" OnServerValidate="CVCantidad_ServerValidate"></asp:CustomValidator>
                                <%--</ContentTemplate>--%>
                            <%--</asp:UpdatePanel>--%>

                        </div>

                        <%--Importe--%>
                        <div class="form-group col-md-1">
                            <asp:Label Text="Importe" runat="server" />
                            <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">--%>
                                <%--<ContentTemplate>--%>
                                    <asp:TextBox ID="ImporteTextBox" class="form-control input-sm" AutoPostBack="true" AutoCompleteType="Disabled" TextMode="Number" runat="server" placeholder="0" OnTextChanged="ImporteTextBox_TextChanged"></asp:TextBox>
                                <%--</ContentTemplate>--%>
                            <%--</asp:UpdatePanel>--%>
                            <asp:CustomValidator ID="CVImporte" ForeColor="Red" Display="Dynamic" runat="server" ValidationGroup="Agregar" ControlToValidate="ImporteTextBox" ErrorMessage="No Hay Importe Para Agregar" OnServerValidate="CVImporte_ServerValidate"></asp:CustomValidator>
                        </div>


                        <div class="col-lg-1 p-0">
                            <asp:LinkButton ID="LinkButton" CssClass="btn btn-outline-success mt-4" ValidationGroup="Agregar" runat="server" OnClick="LinkButton_Click">
                                <span class="fa fa-plus"></span>
                                     Add
                            </asp:LinkButton>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <%--DataGridView--%>
                            <div class="form-row justify-content-center">
                                <div class="col-lg-11">
                                    <asp:GridView ID="FacturaGridView" OnPageIndexChanging="FacturaGridView_PageIndexChanging" runat="server" AllowPaging="true" CellPadding="4" PageSize="7" ForeColor="#333333" GridLines="None" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False">
                                        <AlternatingRowStyle BackColor="LightSkyBlue" />
                                        <Columns>
                                            <asp:CommandField ControlStyle-CssClass="btn btn-secondary" ButtonType="Button" ShowEditButton="true" />
                                            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="true" />
                                            <asp:BoundField DataField="ProductoId" HeaderText="Producto Id" ReadOnly="true" />
                                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" ReadOnly="true" />
                                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" ReadOnly="true" />
                                            <asp:BoundField DataField="Precio" HeaderText="Precio" ReadOnly="true" />
                                            <asp:BoundField DataField="Importe" HeaderText="Importe" ReadOnly="true" />
                                        </Columns>
                                        <HeaderStyle BackColor="LightSeaGreen" Font-Bold="True" />
                                    </asp:GridView>
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="form-row">
                        <%--Monto--%>
                        <div class="form-group col-md-3">
                            <label for="MontoTextBox">Monto</label>
                            <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">--%>
                                <%--<ContentTemplate>--%>
                                    <asp:TextBox ID="MontoTextBox" class="form-control input-sm" AutoPostBack="true" AutoCompleteType="Disabled" TextMode="Number" runat="server" OnTextChanged="MontoTextBox_TextChanged"></asp:TextBox>
                                <%--</ContentTemplate>--%>
                            <%--</asp:UpdatePanel>--%>
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
        <%--</ContentTemplate>--%>
    <%--</asp:UpdatePanel>--%>
</asp:Content>
