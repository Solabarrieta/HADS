<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EliminarCuenta.aspx.cs" Inherits="Lab2.Private.Admin.EliminarCuenta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ButtonType="Button" SelectText="Eliminar" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Private/Admin/Administrador.aspx">Volver</asp:HyperLink>
        </div>
    </form>
</body>
</html>
