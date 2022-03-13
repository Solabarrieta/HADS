<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertarTarea.aspx.cs" Inherits="Lab2.WebForm10" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 358px">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="CodigoLbl" runat="server" Text="Codigo"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="CodigoText" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="DescripcionLbl" runat="server" Text="Descripción"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="DescripcionText" runat="server" Height="38px" OnTextChanged="TextBox2_TextChanged" Width="505px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="AsignaturaLbl" runat="server" Text="Asignatura"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="AsignaturaDropDown" runat="server" DataSourceID="AsignaturaQuery" DataTextField="codigoAsig" DataValueField="codigoAsig">
            </asp:DropDownList>
        <asp:SqlDataSource ID="AsignaturaQuery" runat="server" ConnectionString="<%$ ConnectionStrings:HADS22-05BConnectionString %>" SelectCommand="SELECT codigoAsig FROM ProfesorGrupo CROSS JOIN GrupoClase WHERE (ProfesorGrupo.email = @email) AND (ProfesorGrupo.codigoGrupo = codigo)">
            <SelectParameters>
                <asp:SessionParameter Name="email" SessionField="correo" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
            <br />
            <br />
            <asp:Label ID="HorasEstimadasLbl" runat="server" Text="Horas Estimadas"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="HorasText" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="TipoTareaLbl" runat="server" Text="Tipo Tarea"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="TipoTareaDropDown" runat="server">
                <asp:ListItem>Examen</asp:ListItem>
                <asp:ListItem>Laboratorio</asp:ListItem>
                <asp:ListItem>Ejercicio</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:Button ID="AddTareaBtn" runat="server" OnClick="AddTarea_Click" Text="Añadir Tarea" />
        </div>
    </form>
</body>
</html>
