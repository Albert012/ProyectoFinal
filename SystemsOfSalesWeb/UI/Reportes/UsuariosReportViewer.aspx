<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuariosReportViewer.aspx.cs" Inherits="SystemsOfSalesWeb.UI.Reportes.UsuariosReportViewer" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reporte Usuarios - System Of Sales</title>
    <style>
        html,body,form,#div1{
            height: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div1">

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="ListadoReportViewer" ProcessingMode="Remote" Height="100%" Width="100%"  runat="server">
                <ServerReport ReportPath="" ReportServerUrl="" />
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
