<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerTareasProfesor.aspx.cs" Inherits="Lab2.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 141px">
    <form id="form1" runat="server">
        <div style="height: 64px; width: 567px; text-align: center; margin-left: 440px">
            <asp:Label ID="Titulo" runat="server" Font-Size="X-Large" Text="Profesor"></asp:Label>
            <br />
            <asp:Label ID="Titulo0" runat="server" Font-Size="X-Large" Text="Gestionar tareas genéricas"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LogoutBtn" runat="server">Cerrar Sesión</asp:LinkButton>
        </div>
        <asp:DropDownList ID="CodAsignatura" runat="server" DataSourceID="AsignaturaQuery" DataTextField="codigoGrupo" DataValueField="codigoGrupo" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>Seleccionar</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="AsignaturaQuery" runat="server" ConnectionString="<%$ ConnectionStrings:HADS22-05BConnectionString %>" SelectCommand="SELECT [codigoGrupo] FROM [ProfesorGrupo] WHERE ([email] = @email)">
            <SelectParameters>
                <asp:SessionParameter Name="email" SessionField="correo" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="TareasGenericas" runat="server" AutoGenerateColumns="False" DataKeyNames="codigo" DataSourceID="TareasQuery">
            <Columns>
                <asp:BoundField DataField="codigo" HeaderText="codigo" ReadOnly="True" SortExpression="codigo" />
                <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                <asp:BoundField DataField="codAsig" HeaderText="codAsig" SortExpression="codAsig" />
                <asp:BoundField DataField="hEstimadas" HeaderText="hEstimadas" SortExpression="hEstimadas" />
                <asp:CheckBoxField DataField="explotacion" HeaderText="explotacion" SortExpression="explotacion" />
                <asp:BoundField DataField="tipoTarea" HeaderText="tipoTarea" SortExpression="tipoTarea" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="TareasQuery" runat="server" ConnectionString="<%$ ConnectionStrings:HADS22-05BConnectionString %>" SelectCommand="SELECT * FROM [TareaGenerica] WHERE ([codAsig] = @codAsig)">
            <SelectParameters>
                <asp:SessionParameter Name="codAsig" SessionField="asignatura" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
