<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarPassword.aspx.cs" Inherits="Lab2.CambiarPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Email&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Email" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;
            <asp:Label ID="alertCod" runat="server"></asp:Label>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Solicitar Código" OnClick="Button1_Click" ValidationGroup="1" />
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="1" Visible="False" />
            <asp:Label ID="EnseñarCodigo" runat="server" Text="Aquí aparecerá el código"></asp:Label>
            <br />
            <br />
            Código&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Codigo" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Codigo" ErrorMessage="*" ForeColor="Red" ValidationGroup="2"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Codigo" ErrorMessage="Introduzca un código válido" ForeColor="Red" ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
            <br />
            <br />
            Nueva Pass&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Pass1" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Pass1" ErrorMessage="*" ForeColor="Red" ValidationGroup="2"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Pass1" ErrorMessage="La contraseña debe tener min 6 Caracteres" ForeColor="Red" ValidationExpression=".{6}" ValidationGroup="2"></asp:RegularExpressionValidator>
            <br />
            <br />
            Repetir Pass&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Pass2" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Pass2" ErrorMessage="*" ForeColor="Red" ValidationGroup="2"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="Pass1" ControlToValidate="Pass2" ErrorMessage="Las dos contraseñas deben de ser iguales" ForeColor="Red" ValidationGroup="2"></asp:CompareValidator>
            <br />
            <br />
&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Restablecer Contraseña" OnClick="Button2_Click" ValidationGroup="2" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server"></asp:Label>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server">Volver a inicio</asp:HyperLink>
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="2" Visible="False" />
        </div>
    </form>
</body>
</html>
