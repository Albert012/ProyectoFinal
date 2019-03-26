<%@ Page Title="Consulta Usuarios" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="cUsuarios.aspx.cs" Inherits="SystemsOfSalesWeb.UI.Consultas.cUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentCP" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="Panel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="card card-register mx-auto mt-5">
                <div class="card-header text-uppercase text-center text-primary">Consultar Usuarios</div>
                <div class="card-body">
                    <div class="form-row justify-content-center">
                        <%--Filtro--%>
                        <div class="form-group col-md-2">
                            <asp:Label Text="Filtro" class="text-primary" runat="server" />
                            <asp:DropDownList ID="FiltroDropDownList" AutoPostBack="true" OnSelectedIndexChanged="FiltroDropDownList_SelectedIndexChanged" CssClass="form-control" runat="server">
                                <asp:ListItem>Todos</asp:ListItem>
                                <asp:ListItem>UsuarioId</asp:ListItem>
                                <asp:ListItem>Email</asp:ListItem>
                                <asp:ListItem>Usuario</asp:ListItem>
                                <asp:ListItem>Nombre</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <%--Criterio--%>
                        <div class="form-group col-md-3">
                            <asp:Label ID="Label1" runat="server" Text="Buscar">Buscar:</asp:Label>
                            <asp:TextBox ID="CriterioTextBox" ReadOnly="true" AutoCompleteType="Disabled" class="form-control input-group" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-lg-1 p-0">
                            <asp:LinkButton ID="BuscarLinkButton" OnClick="BuscarLinkButton_Click" CssClass="btn btn-outline-info mt-4" runat="server"><span class="fas fa-search"></span> Buscar</asp:LinkButton>
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

                    <div class="form-row justify-content-end">
                        <div class="form-group col-md-3">
                            <asp:LinkButton ID="AgregarButton" CssClass="btn btn-outline-success" OnClick="AgregarButton_Click" runat="server"><span class="fas fa-plus"></span> Agregar</asp:LinkButton>
                        </div>
                    </div>

                    <div class="form-row justify-content-center">
                        <div class="table-responsive">
                            <asp:GridView ID="UsuarioGridView" runat="server" class="table table-condensed table-bordered"
                                AutoGenerateColumns="False" RowStyle-Wrap="false"  ForeColor="#333333" GridLines="Both" OnRowDeleting="UsuarioGridView_RowDeleting"
                                OnRowCancelingEdit="UsuarioGridView_RowCancelingEdit" OnRowEditing="UsuarioGridView_RowEditing" DataKeyNames="UsuarioId">
                                <AlternatingRowStyle BackColor="LightSkyBlue" />
                                <Columns>
                                    <asp:BoundField DataField="UsuarioId" HeaderText="Usuario Id" />
                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                    <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                                    <asp:BoundField DataField="Email" HeaderText="Email" />
                                    <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre Usuario" />
                                    <asp:BoundField DataField="TipoUsuario" HeaderText="Tipo" />

                                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" />
                                </Columns>
                                <HeaderStyle BackColor="LightGreen" Font-Bold="True" />
                            </asp:GridView>
                        </div>
                    </div>


                <%--Botones--%>
                <div class="card-footer">
                    <div class="justify-content-start">
                        <div class="form-group" style="display: inline-block">
                            <asp:LinkButton ID="ImprimirLinkButton" CssClass="btn btn-outline-primary mt-4" OnClick="ImprimirLinkButton_Click" runat="server"><span class="fas fa-print"></span> Imprimir</asp:LinkButton>

                        </div>
                    </div>
                </div>
            </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
