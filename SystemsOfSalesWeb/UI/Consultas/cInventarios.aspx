<%@ Page Title="Consulta Inventarios" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="cInventarios.aspx.cs" Inherits="SystemsOfSalesWeb.UI.Consultas.cInventarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentCP" runat="server">
      <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="Panel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="card card-register mx-auto mt-5">
                <div class="card-header text-uppercase text-center text-primary">Consultar Inventarios</div>
                <div class="card-body">
                    <div class="form-row justify-content-center">
                        <%--Filtro--%>
                        <div class="form-group col-md-2">
                            <asp:Label Text="Filtro" class="text-primary" runat="server" />
                            <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>InventarioId</asp:ListItem>
                                <asp:ListItem>ProductoId</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <%--Criterio--%>
                        <div class="form-group col-md-3">
                            <asp:Label ID="Label1" runat="server" Text="Buscar">Buscar:</asp:Label>
                            <asp:TextBox ID="CriterioTextBox" class="form-control input-group" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-lg-1 p-0">
                            <asp:LinkButton ID="BuscarLinkButton" OnClick="BuscarLinkButton_Click" CssClass="btn btn-outline-info mt-4" runat="server">
                <span class="fas fa-search"></span>
                 Buscar
            </asp:LinkButton>
                        </div>
                    </div>

                    <%--Rango fecha--%>
                    <div class="form-row justify-content-center">
                        <div class="form-group col-md-2">
                            <asp:Label Text="Desde" class="text-primary" runat="server" />
                            <asp:TextBox ID="DesdeTextBox" class="form-control input-group" TextMode="Date" runat="server" />

                        </div>

                        <div class="form-group col-md-2">
                            <asp:Label Text="Hasta" class="text-primary" runat="server" />
                            <asp:TextBox ID="HastaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
                        </div>
                    </div>

                    <div class="form-row justify-content-center">
                        <asp:GridView ID="InventarioGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="LightSkyBlue" />
                            <Columns>
                                <asp:BoundField DataField="InventarioId" HeaderText="Inventario Id" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                <asp:BoundField DataField="ProductoId" HeaderText="Producto Id" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            </Columns>
                            <HeaderStyle BackColor="LightGreen" Font-Bold="True" />
                        </asp:GridView>
                    </div>


                    <%--Botones--%>
                    <div class="card-footer">
                        <div class="justify-content-start">
                            <div class="form-group" style="display: inline-block">
                                <asp:LinkButton ID="ImprimirLinkButton" OnClick="ImprimirLinkButton_Click" CssClass="btn btn-outline-info mt-4"  runat="server">
                            <span class="fas fa-print"></span>
                            Imprimir
                                </asp:LinkButton>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
