<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="SystemsOfSalesWeb.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Iniciar Sesión</title>

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

    <div class="container col-md-4">
        <div class="card card-login mx-auto mt-5">
            <div class="card-header text-primary text-center text-uppercase">Iniciar Sesión  </div>
            <div class="card-body">
                <form id="form1" runat="server">
                    <div>
                        <div class="form-group">
                            <asp:TextBox ID="EmailTextBox"  class="form-control input-group" AutoCompleteType="Disabled" TextMode="Email" placeholder="Email Address" runat="server" />
                            <asp:RequiredFieldValidator SetFocusOnError="true" ID="RequiredFieldValidator1" Display="Dynamic" ForeColor="Red" ValidationGroup="Login" runat="server" ControlToValidate="EmailTextBox" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="PassTextBox" class="form-control input-group" AutoCompleteType="Disabled" TextMode="Password" placeholder="Password" runat="server" />
                            <asp:RequiredFieldValidator SetFocusOnError="true" ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ForeColor="Red" ValidationGroup="Login" ControlToValidate="PassTextBox" ErrorMessage="*" ></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                             <asp:LinkButton ID="LoginLinkButton"  class="btn btn-lg btn-primary btn-block"  ValidationGroup="Login" runat="server" OnClick="LoginLinkButton_Click">Iniciar</asp:LinkButton>
                        </div>
                        <div class="text-center">
                            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Users/rUsuarios.aspx" runat="server">Crear Cuenta</asp:HyperLink>
                            
                        </div>

                    </div>
                </form>

            </div>
        </div>
    </div>


</body>
</html>
