<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Lab2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            E-mail:
            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="Required" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            Password:<asp:TextBox ID="Password" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
&nbsp;<br />
            <asp:HyperLink ID="registro" runat="server" ClientIDMode="AutoID" NavigateUrl="Registro.aspx">Quiero Registrarme</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="CambiarPassword.aspx">Modificar Contraseña</asp:HyperLink>
        </div>
    </form>
</body>
</html>
