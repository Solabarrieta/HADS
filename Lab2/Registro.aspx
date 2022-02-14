<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Lab2.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Email&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Email" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
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
            <asp:TextBox ID="Pass1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredPass1" runat="server" ControlToValidate="Pass1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>
            Repetir Psw&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Pass2" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredPass2" runat="server" ControlToValidate="Pass2" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="ComparePass" runat="server" ControlToCompare="Pass1" ControlToValidate="Pass2" ErrorMessage="Las dos contraseñas deben ser iguales" ForeColor="Red"></asp:CompareValidator>
        </p>
        <p>
            Rol&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ton ID="Alumno" runat="server" GroupName="Alumno/Profesor" Text="Alumno" />
        </p>
        <p style="margin-left: 80px">
&nbsp;
     &nbsp;
            <asp:RadioButton ID="Profesor" runat="server" GroupName="Alumno/Profesor" Text="Profesor" />
        </p>
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="RegisterButton" runat="server" Text="Registrarse" Width="137px" />
        </p>
    </form>
</body>
</html>
