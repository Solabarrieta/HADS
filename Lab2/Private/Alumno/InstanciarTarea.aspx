<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstanciarTarea.aspx.cs" Inherits="Lab2.WebForm9" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            INSTANCIAR TAREA<br />
            <br />
            Usuario
            <asp:TextBox ID="Usuario" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <br />
            Tarea<asp:TextBox ID="Tarea" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <br />
            Horas Est.<asp:TextBox ID="horasEst" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <br />
            Horas Reales<asp:TextBox ID="horasReales" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="instanciarTarea" runat="server" Height="61px" OnClick="instanciarTarea_Click" Text="Instanciar Tarea" Width="144px" />
&nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Private/Alumno/VerTareasEstudiante.aspx">Página Anterior</asp:HyperLink>
            <br />
            <br />
        </div>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="gridTareas" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
