<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alumno.aspx.cs" Inherits="Lab2.WebForm7" %>

<%@ Register Src="~/Users.ascx" TagPrefix="uc1" TagName="Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Gestión Web de Tareas-Dedicación Alumnos<br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Private/Alumno/VerTareasEstudiante.aspx">Tareas Genéricas</asp:HyperLink>
            <br />
            <br />
            <uc1:Users runat="server" ID="Users" />

            <br />

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cerrar Sesión" />
        </div>
    </form>
</body>
</html>
