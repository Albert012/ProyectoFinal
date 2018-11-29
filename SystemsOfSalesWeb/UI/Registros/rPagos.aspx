<%@ Page Title="Pagos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rPagos.aspx.cs" Inherits="SystemsOfSalesWeb.UI.Registros.rPagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentCP" runat="server">
    <div class="card card-register mx-auto mt-5">
        <div class="card-header text-uppercase text-center text-primary">Pagos</div>
        <div class="card-body">

            <div class="form-row">
                <%--PagoId--%>
                <div class="form-group col-md-1">
                    <asp:Label Text="Id" class="text-primary" runat="server" />
                    <asp:TextBox ID="PagoIdTextBox" class="form-control input-group" TextMode="Number" placeholder="0" runat="server" />
                </div>
                <%--Fecha--%>
                <div class="form-group col-md-2">
                    <asp:Label Text="Fecha" runat="server" />
                    <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
                </div>

                <%--Boton--%>
                <div class="col-lg-1 p-0">
                    <asp:LinkButton ID="BuscarLinkButton" OnClick="BuscarLinkButton_Click" CssClass="btn btn-outline-info mt-4" runat="server">
                <span class="fas fa-search"></span>
                     Buscar
            </asp:LinkButton>
                </div>

            </div>

            <div class="form-row">
                <%--Cliente--%>
                <div class="form-group col-md-3">
                    <label for="ClienteDropDownList">Cliente</label>
                    <asp:DropDownList ID="ClienteDropDownList" class="form-control input-sm" runat="server">
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

            <%--Botones--%>
            <div class="panel-footer">
                <div class="justify-content-start">
                    <div class="form-group" style="display: inline-block">
                        <asp:LinkButton ID="NuevoLinkButton"  CssClass="btn btn-outline-info mt-4" runat="server"  >
                            <span class="fas fa-plus"></span>
                            Nuevo
                        </asp:LinkButton>

                        <asp:LinkButton ID="GuardarLinkButton" ValidationGroup="Guardar" CssClass="btn btn-outline-success mt-4" runat="server"  >
                            <span class="fas fa-save"></span>
                            Guardar
                        </asp:LinkButton>

                        <asp:LinkButton ID="EliminarLinkButton" ValidationGroup="Buscar"  CssClass="btn btn-outline-danger mt-4" runat="server"  >
                            <span class="fas fa-trash-alt"></span>
                            Eliminar
                        </asp:LinkButton>
                    </div>
                </div>
            </div>


        </div>
    </div>

</asp:Content>
