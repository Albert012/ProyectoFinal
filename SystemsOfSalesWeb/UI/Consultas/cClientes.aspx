<%@ Page Title="Consulta Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cClientes.aspx.cs" Inherits="SystemsOfSalesWeb.UI.Consultas.cClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentCP" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="Panel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="card card-register mx-auto mt-5">
                <div class="card-header text-uppercase text-center text-primary">Consultar Clientes</div>
                <div class="card-body">

                    <div class="form-row justify-content-center">
                        <%--Filtro--%>
                        <div class="form-group col-md-2">
                            <asp:Label Text="Filtro" class="text-primary" runat="server" />
                            <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server" OnSelectedIndexChanged="FiltroDropDownList_SelectedIndexChanged">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>ClienteId</asp:ListItem>
                                <asp:ListItem>Nombre</asp:ListItem>
                                <asp:ListItem>Apellido</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <%--Criterio--%>
                        <div class="form-group col-md-3">
                            <asp:Label ID="Label1" runat="server" Text="Buscar">Buscar:</asp:Label>
                            <asp:TextBox ID="CriterioTextBox" AutoCompleteType="Disabled" class="form-control input-group" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-lg-1 p-0">
                            <asp:LinkButton ID="BuscarLinkButton"  CssClass="btn btn-outline-info mt-4" OnClick="BuscarLinkButton_Click" runat="server">
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
                        <asp:GridView ID="ClienteGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="LightSkyBlue" />
                            <Columns>
                                <asp:BoundField DataField="ClienteId" HeaderText="Id" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
                                <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
                                <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                                <asp:BoundField DataField="Cedula" HeaderText="Cédula" />
                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                <asp:BoundField DataField="Sexo" HeaderText="Sexo" />
                                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                                <asp:BoundField DataField="Balance" HeaderText="Balance" />

                            </Columns>
                            <HeaderStyle BackColor="LightGreen" Font-Bold="True" />
                        </asp:GridView>
                    </div>

                    <%--Botones--%>
                    <div class="card-footer">
                        <div class="justify-content-start">
                            <div class="form-group" style="display: inline-block">
                                <asp:LinkButton ID="ImprimirLinkButton" CssClass="btn btn-outline-info mt-4" OnClick="ImprimirLinkButton_Click" runat="server">
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
