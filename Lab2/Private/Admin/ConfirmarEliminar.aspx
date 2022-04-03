<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmarEliminar.aspx.cs" Inherits="Lab2.Private.Admin.ConfirmarEliminart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Eliminar" />
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Private/Admin/EliminarCuenta.aspx">Volver</asp:HyperLink>
        </div>
    </form>
</body>
</html>
