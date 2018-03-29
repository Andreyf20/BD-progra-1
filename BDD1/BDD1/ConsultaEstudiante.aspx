<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaEstudiante.aspx.cs" Inherits="BDD1.ConsultaEstudiante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="formTitulo" runat="server">
        <div>
            <h1>
                Notas del Estudiante
            </h1>          
        </div>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        </asp:RadioButtonList>
        <asp:Button ID="ButtonOK" runat="server" Text="Escoger Grupo" OnClick="ButtonOK_Click" />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:Table id="Table1" runat="server" style="text-align: center" 
            CellPadding="10" 
            GridLines="Both"
            HorizontalAlign="Center">
        </asp:Table>
    </form>
</body>
</html>
