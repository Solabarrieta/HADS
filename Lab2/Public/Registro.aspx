<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Lab2.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
        <asp:Timer ID="Timer1" runat="server" Interval="10000" OnTick="Timer1_Tick">
        </asp:Timer>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                
                Email&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="Email" runat="server" OnTextChanged="Email_TextChanged"></asp:TextBox>
                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Email" ErrorMessage="Email Incorrecto" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                &nbsp;<asp:Label ID="Si" runat="server" ForeColor="#00CC00" Text="SÍ" Visible="False"></asp:Label>
                <asp:Label ID="No" runat="server" ForeColor="Red" Text="NO" Visible="False"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        <p>
            Nombre&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Nombre" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredNombre" runat="server" ControlToValidate="Nombre" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>
            Apellidos&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="Apellidos" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredApellidos" runat="server" ControlToValidate="Apellidos" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>
            Password&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Pass1" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredPass1" runat="server" ControlToValidate="Pass1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Debe tener al menos 6 caracteres" ForeColor="Red" ValidateRequestMode="Enabled" ValidationExpression=".{6,}" ControlToValidate="Pass1"></asp:RegularExpressionValidator>
        </p>
        <p>
            Repetir Psw&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Pass2" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredPass2" runat="server" ControlToValidate="Pass2" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="ComparePass" runat="server" ControlToCompare="Pass1" ControlToValidate="Pass2" ErrorMessage="Las dos contraseñas deben ser iguales" ForeColor="Red"></asp:CompareValidator>
        </p>
        <p>
            Rol<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RadioButtonList1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem Value="Alumno"></asp:ListItem>
                <asp:ListItem>Profesor</asp:ListItem>
            </asp:RadioButtonList>
        </p>
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="RegisterButton" runat="server" Text="Registrarse" Width="137px" OnClick="RegisterButton_Click" />
        </p>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" />
        <p>
            <asp:Label ID="Label1" runat="server" ForeColor="#CC0000"></asp:Label>
        </p>
        <p>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Public/Inicio.aspx">Volver a inicio</asp:HyperLink>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
