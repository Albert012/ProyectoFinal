<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="SystemsOfSalesWeb.UI.Registros.rUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentCP" runat="server">
    <div class="card card-register mx-auto mt-5">
        <div class="card-header text-uppercase text-center text-primary">Usuarios</div>
        <div class="card-body">
            <div class="form-row">
                <%--UsuarioId--%>
                <div class="form-group col-md-1">
                    <asp:Label Text="Id" class="text-primary" runat="server" />
                    <asp:TextBox ID="UsuarioIdTextBox" class="form-control input-group" TextMode="Number" placeholder="0" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="UsuarioIdTextBox" ValidationGroup="Buscar" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <%--Fecha--%>
                <div class="form-group col-md-2">
                    <asp:Label Text="Fecha" runat="server" />
                    <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
                    <asp:RequiredFieldValidator ID="RFVFFecha" ValidationGroup="Guardar" ControlToValidate="FechaTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <%--Boton--%>
                <div class="col-lg-1 p-0">
                    <asp:LinkButton ID="BuscarLinkButton" ValidationGroup="Buscar" CssClass="btn btn-outline-info mt-4" runat="server" OnClick="BuscarLinkButton_Click">
                <span class="fas fa-search"></span>
                     Buscar
            </asp:LinkButton>
                </div>

            </div>

            <div class="form-row">
                <%--Email--%>
                <div class="form-group col-md-3">
                    <label for="UsuarioTextBox">Email Address</label>
                    <asp:TextBox ID="EmailTextBox" class="form-control input-sm" TextMode="Email" AutoCompleteType="Disabled" placeholder="Email Address" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="EmailTextBox" ValidationGroup="Guardar" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <%--Nombre--%>
                <div class="form-group col-md-3">
                    <label for="NombreTextBox">Nombres</label>
                    <asp:TextBox ID="NombreTextBox" class="form-control input-sm" AutoCompleteType="Disabled" placeholder="Nombre Completo" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="NombreTextBox" ValidationGroup="Guardar" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="NombreTextBox" ForeColor="Red" Display="Dynamic" ErrorMessage="Porfavor Digite Solo Letras" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                </div>
            </div>


            <div class="form-row">
                <%--Contrasena--%>
                <div class="form-group col-md-2">
                    <label for="ContrasenaTextBox">Contraseña</label>
                    <asp:TextBox ID="ContrasenaTextBox" class="form-control input-sm" AutoCompleteType="Disabled" TextMode="Password" placeholder="Contraseña" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ContrasenaTextBox" ValidationGroup="Guardar" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <%--Confirmar--%>
                <div class="form-group col-md-2">
                    <label for="ConfirmarTextBox">Confirmar</label>
                    <asp:TextBox ID="ConfirmarTextBox" class="form-control input-sm" AutoCompleteType="Disabled" TextMode="Password" placeholder="Confirmar" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator" runat="server" ControlToValidate="ConfirmarTextBox" ValidationGroup="Guardar" ForeColor="Red" Display="Dynamic" ErrorMessage="Contraseña No Coinciden  " OnServerValidate="CustomValidator_ServerValidate"></asp:CustomValidator>
                </div>

            </div>           

            <div class="form-row">
                <%--Tipo Usuario--%>
                <div class="form-group col-md-3">
                    <label for="TipoUsuarioDropDownList">Tipo Usuario</label>
                    <asp:DropDownList ID="TipoUsuarioDropDownList" class="form-control input-sm" runat="server">
                        <asp:ListItem Selected="True">Seleccione</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TipoUsuarioDropDownList" ValidationGroup="Guardar" ForeColor="Red" Display="Dynamic" ErrorMessage="Seleccione Un Tipo De Usuario " OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                </div>
            </div>

            <%--Botones--%>
            <div class="card-footer">
                <div class="justify-content-start">
                    <div class="form-group" style="display: inline-block">
                        <asp:LinkButton ID="NuevoLinkButton"  CssClass="btn btn-outline-info mt-4" runat="server" OnClick="NuevoLinkButton_Click" >
                            <span class="fas fa-plus"></span>
                            Nuevo
                        </asp:LinkButton>

                        <asp:LinkButton ID="GuardarLinkButton" ValidationGroup="Guardar" CssClass="btn btn-outline-success mt-4" runat="server" OnClick="GuardarLinkButton_Click" >
                            <span class="fas fa-save"></span>
                            Guardar
                        </asp:LinkButton>

                        <asp:LinkButton ID="EliminarLinkButton" ValidationGroup="Buscar"  CssClass="btn btn-outline-danger mt-4" runat="server" OnClick="EliminarLinkButton_Click" >
                            <span class="fas fa-trash-alt"></span>
                            Eliminar
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

