<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerTareasProfesor.aspx.cs" Inherits="Lab2.WebForm5" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<ajaxToolkit:ConfirmButtonExtender ID="InsertarTareaBtn" runat="server" />

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 124px;
            margin-left: 640px;
        }
        .auto-style2 {
            height: 64px;
            width: 567px;
        }
    </style>
</head>
<body style="height: 429px">
    <form id="form1" runat="server">
        <div style="text-align: center; margin-left: 440px" class="auto-style2">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="CodAsignatura" runat="server" AutoPostBack="True" DataSourceID="AsignaturaQuery" DataTextField="codigoAsig" DataValueField="codigoAsig" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem>Seleccionar</asp:ListItem>
                    </asp:DropDownList>
                    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="codigo" DataSourceID="TareasQuery" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ShowEditButton="True" />
                            <asp:BoundField DataField="codigo" HeaderText="codigo" ReadOnly="True" SortExpression="codigo" />
                            <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                            <asp:BoundField DataField="codAsig" HeaderText="codAsig" SortExpression="codAsig" />
                            <asp:BoundField DataField="hEstimadas" HeaderText="hEstimadas" SortExpression="hEstimadas" />
                            <asp:CheckBoxField DataField="explotacion" HeaderText="explotacion" SortExpression="explotacion" />
                            <asp:BoundField DataField="tipoTarea" HeaderText="tipoTarea" SortExpression="tipoTarea" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Titulo" runat="server" Font-Size="X-Large" Text="Profesor"></asp:Label>
            <br />
            <asp:Label ID="Titulo0" runat="server" Font-Size="X-Large" Text="Gestionar tareas genéricas"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LogoutBtn" runat="server" OnClick="LogoutBtn_Click">Cerrar Sesión</asp:LinkButton>
        </div>
        <asp:SqlDataSource ID="AsignaturaQuery" runat="server" ConnectionString="<%$ ConnectionStrings:HADS22-05BConnectionString %>" SelectCommand="SELECT codigoAsig FROM ProfesorGrupo CROSS JOIN GrupoClase WHERE (ProfesorGrupo.email = @email) AND (ProfesorGrupo.codigoGrupo = codigo)">
            <SelectParameters>
                <asp:SessionParameter Name="email" SessionField="correo" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <br />
        <asp:SqlDataSource ID="TareasQuery" runat="server" ConnectionString="<%$ ConnectionStrings:HADS22-05BConnectionString %>" SelectCommand="SELECT codigo, descripcion, codAsig, hEstimadas, explotacion, tipoTarea FROM TareaGenerica WHERE (codAsig = @codAsig) " >
            <SelectParameters>
                <asp:SessionParameter Name="codAsig" SessionField="asignatura" />
            </SelectParameters>

        </asp:SqlDataSource>
        <br />
            <asp:Button ID="insertarTareaBtn" runat="server" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" Height="33px" OnClick="InsertarTareaBtn_Click" Text="Insertar Tarea" />
        <ajaxToolkit:ConfirmButtonExtender ID="insertarTareaBtn_ConfirmButtonExtender" runat="server" BehaviorID="insertarTareaBtn_ConfirmButtonExtender" ConfirmText="" TargetControlID="insertarTareaBtn" />
    </form>
</body>
</html>
