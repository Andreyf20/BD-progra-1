<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profesor.aspx.cs" Inherits="BDD1.Profesor" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
        </div>
        <asp:Panel ID="PanelMenu" runat="server" Visible="true">
            <asp:Button ID="ButtonPeriodos" runat="server" Text="Periodos" OnClick="ButtonPeriodos_Click" />
            <asp:Button ID="ButtonGrupos" runat="server" Text="Grupos" OnClick="ButtonGrupos_Click" />
        </asp:Panel>
        <asp:Panel ID="PanelPeriodo" runat="server" Visible="false">
            <asp:Button ID="ButtonCrearPeriodo" runat="server" Text="Crear Periodo" />
            <asp:Button ID="ButtonCambiarPeriodo" runat="server" Text="Cambiar Periodo" />
            <asp:Button ID="ButtonAnularPeriodo" runat="server" Text="Anular Periodo" />
            <asp:Button ID="ButtonTerminarPeriodo" runat="server" Text="Terminar Periodo" />
        </asp:Panel>
        <asp:Panel ID="PanelGrupos" runat="server">
            <asp:Button ID="ButtonCrearGrupo" runat="server" Text="Crear Grupo" />
            <asp:Button ID="ButtonCambiarGrupo" runat="server" Text="Cambiar Grupo" />
            <asp:Button ID="ButtonAnularGrupo" runat="server" Text="Anular Grupo" />
            <asp:Button ID="ButtonTerminarGrupo" runat="server" Text="Terminar Grupo" />
        </asp:Panel>
    </form>    
</body>
</html>

