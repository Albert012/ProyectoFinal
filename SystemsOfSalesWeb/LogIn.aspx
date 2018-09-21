﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="SystemsOfSalesWeb.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Iniciar Sesion</title>

    <link href="Content/css/bootstrap.min.css" rel="stylesheet" />
    <script src="Content/js/bootstrap.min.js"></script>
    <script src="Content/js/jquery-3.3.1.min.js"></script>


    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

</head>
<body>

    <h1 class="text-center text-info">System Of Sales</h1>

    <form id="LogInform" runat="server">
        <div class="container-fluid">
            
            <%--Usuario--%>
            <div class="row">
                <div class="form-group">
                    <label for="UsuarioTextBox" class="col-md-3 control-label input-sm text-success">Usuario:</label>
                    <div class="col-md-10 col-sm-2 col-xs-4">
                        <asp:TextBox ID="UsuarioTextBox" runat="server" placeholder="Usuario" class="form-control input-md" />

                    </div>
                </div>
            </div>

            <%--Contrasena--%>
            <div class="row">
                <div class="form-group">
                    <label for="PassTextBox" class="col-md-3 control-label input-sm text-success">Contraseña:</label>
                    <div class="col-md-10 col-sm-2 col-xs-4">
                        <asp:TextBox ID="PassTextBox" runat="server" TextMode="Password" placeholder="Contraseña" class="form-control input-md" />

                    </div>
                </div>
            </div>

            <%--Botones--%>
            <asp:Button ID="IniciarButton" CssClass="btn btn-info" runat="server" Text="Iniciar" OnClick="IniciarButton_Click" />


        </div>
    </form>

</body>
</html>
