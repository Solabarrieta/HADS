<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Users.ascx.cs" Inherits="Lab2.Users" %>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        USUARIOS LOGUEADOS
        <asp:Label ID="StudentsCount" runat="server" Text="0"></asp:Label>
        &nbsp;Alumnos y
        <asp:Label ID="TeachersCount" runat="server" Text="0"></asp:Label>
        &nbsp;Profesores
        <br />
        <br />
        Alumnos&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Profesores<br />
        <asp:ListBox ID="StudentsList" runat="server" Width="136px"></asp:ListBox>
        <asp:ListBox ID="TeachersList" runat="server" Width="136px"></asp:ListBox>
        <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="5000">
        </asp:Timer>
    </ContentTemplate>
</asp:UpdatePanel>

