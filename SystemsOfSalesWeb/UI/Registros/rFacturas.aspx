<%@ Page Title="Factura" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rFacturas.aspx.cs" Inherits="SystemsOfSalesWeb.UI.Registros.rFacturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentCP" runat="server">

    <div class="form-row">
        <%--FacturaId--%>
        <div class="form-group col-md-3">
            <label for="FacturaIdTextBox " class="text-primary">Factura Id</label>
            <asp:TextBox ID="FacturaIdTextBox" class="form-control input-sm" TextMode="Number" runat="server" placeholder="0"></asp:TextBox>
        </div>
        <%--Fecha--%>
        <div class="form-group col-md-3">
            <label for="FechaTextBox">Fecha</label>
            <asp:TextBox ID="FechaTextBox" class="form-control input-sm" TextMode="Date" runat="server"></asp:TextBox>
        </div>
    </div>

    <%--Condicion--%>
    <div class="form-row">
        <div class="form-check form-check-inline">
            <input class="form-check-input" type="radio" name="inlineRadioOptions" id="ContadoInlineRadio" value="option1">
            <label class="form-check-label" for="ContadoInlineRadio">Contado</label>
        </div>
        <div class="form-check form-check-inline">
            <input class="form-check-input" type="radio" name="inlineRadioOptions" id="CreditoInlineRadio" value="option2">
            <label class="form-check-label" for="CreditoInlineRadio">Credito</label>
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
        <%--Producto--%>
        <div class="form-group col-md-3">
            <label for="ProductoTextBox">Producto</label>
            <asp:DropDownList ID="ProductoDropDownList" class="form-control input-sm" runat="server">
                <asp:ListItem Selected="True">[Seleccione]</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <%--DataGridView--%>
    <div class="form-row justify-content-center">
        <div class="col-lg-11">
            <asp:GridView ID="FacturaGridView" runat="server" AllowPaging="true" PageSize="7" CssClass="table table-striped table-hover table-responsive-lg" AutoGenerateColumns="False" OnPageIndexChanging="ClientesGridView_PageIndexChanging" OnRowCancelingEdit="FacturaGridView_RowCancelingEdit" OnRowEditing="FacturaGridView_RowEditing" OnRowUpdating="FacturaGridView_RowUpdating">
                <Columns>
                    <asp:CommandField ControlStyle-CssClass="btn btn-secondary" ButtonType="Button" ShowEditButton="true" />
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="true" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" ReadOnly="true" />
                    <asp:BoundField DataField="Importe" HeaderText="Importe" ReadOnly="true" />
                    
                    <asp:BoundField DataField="Precio" HeaderText="Precio" ReadOnly="true" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <div class="form-row">
        <%--Monto--%>
        <div class="form-group col-md-3">
            <label for="MontoTextBox">Monto</label>
            <asp:TextBox ID="MontoTextBox" class="form-control input-sm" ReadOnly="true" TextMode="Number" runat="server"></asp:TextBox>
        </div>

    </div>

</asp:Content>
