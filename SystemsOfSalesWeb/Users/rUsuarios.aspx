<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="SystemsOfSalesWeb.rUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registrarse </title>

    <meta name="author" content="Albert De Jesus" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <link href="/Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="/Content/css/StyleSheet.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.bundle.min.js"></script>
    <script src="/Scripts/jquery-3.3.1.min.js"></script>
    <script src="/Scripts/toastr.min.js"></script>
    <link href="/Content/toastr.min.css" rel="stylesheet" />



</head>
<body class="bg-dark">
    <h1 class="text-center text-info">System Of Sales</h1>
    <div class="container col-md-6">
        <div class="card card-register mx-auto mt-5">
            <div class="card-header text-primary text-uppercase text-center">Crear Cuenta</div>
            <div class="card-body">
                <form id="form1" runat="server">
                    <div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:TextBox ID="NombreTextBox" AutoCompleteType="Disabled" class="form-control input-group" placeholder="Nombres" runat="server" />
                                <asp:RequiredFieldValidator ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" ID="RFVNombre" ValidationGroup="Registrar" ControlToValidate="NombreTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group col-md-6">
                                <asp:TextBox ID="UsuarioTextBox" AutoCompleteType="Disabled" class="form-control input-group" placeholder="Usuario" runat="server" />
                                <asp:RequiredFieldValidator ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" ID="RFVApellido" ValidationGroup="Registrar" ControlToValidate="UsuarioTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:TextBox ID="EmailTextBox" AutoCompleteType="Disabled" class="form-control input-group" TextMode="Email" placeholder="Email Address" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Registrar" ControlToValidate="EmailTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:TextBox ID="PassTextBox" AutoCompleteType="Disabled" class="form-control input-group" TextMode="Password" placeholder="Password" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Registrar" ControlToValidate="PassTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group col-md-6">
                                <asp:TextBox ID="ConfirmarTextBox" AutoCompleteType="Disabled" class="form-control input-group" TextMode="Password" placeholder="Confirmar" runat="server" />
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Las contraseñas no coinciden" ControlToValidate="ConfirmarTextBox" ValidationGroup="Registrar" ForeColor="Red" Display="Dynamic" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:LinkButton ID="RegistrarLinkButton" class="btn btn-primary btn-block" ValidationGroup="Registrar" runat="server" OnClick="RegistrarLinkButton_Click" >Registrar</asp:LinkButton>
                        </div>
                        <div class="text-center">
                            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/LogIn.aspx" runat="server">Inicio</asp:HyperLink>
                            <%--<a class="d-block small mt-3" runat="server" href="~/rUsuarios.aspx">Register an Account</a>--%>
                        </div>



                    </div>
                </form>
            </div>
        </div>
    </div>




</body>
</html>
