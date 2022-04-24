<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profesor.aspx.cs" Inherits="Lab2.WebForm6" %>

<%@ Register Src="~/Users.ascx" TagPrefix="uc1" TagName="Users" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div aria-atomic="False">
            <asp:LinkButton ID="VerTareasBtn" runat="server" OnClick="VerTareasBtn_Click">Ver Tareas Genéricas</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="ImportarTareasBtn" runat="server" OnClick="ImportarTareasBtn_Click">Importar Tareas</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="ExportarTareasBtn" runat="server" OnClick="ExportarTareasBtn_Click">Exportar Tareas</asp:LinkButton>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Private/Admin/Administrador.aspx">Administrar</asp:HyperLink>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Private/Profesor/VerHorasMedias.aspx">Ver Horas Medias</asp:HyperLink>
            <br />
            <uc1:Users runat="server" id="Users" />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cerrar Sesión" />
            <br />
        </div>
    </form>
</body>
</html>
