<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportarTareaXML.aspx.cs" Inherits="Lab2.WebForm11" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="SeleccionarTareaLbl" runat="server" Text="Seleccionar Asignatura a Importar :"></asp:Label>
            <br />
            <br />
            <asp:DropDownList ID="AsignaturasList" runat="server" OnSelectedIndexChanged="AsignaturasList_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="ImportarBtn" runat="server" Text="Importar XML" OnClick="ImportarBtn_Click" />
            <asp:Xml ID="xmlTable" runat="server"></asp:Xml>
            <asp:Label ID="ControlMsg" runat="server" ForeColor="#CC0000"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
