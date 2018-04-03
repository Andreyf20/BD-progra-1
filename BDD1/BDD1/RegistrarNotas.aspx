<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarNotas.aspx.cs" Inherits="BDD1.RegistrarNotas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="font-size: xx-large; color: #FFFFFF; background-color: #800000" Text="Regresar" />
        </div>

        <asp:Table id="Table1" runat="server" style="text-align: center" 
            CellPadding="10" 
            GridLines="Both"
            HorizontalAlign="Center">
        </asp:Table>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        
        <br />
        </form>
    </body>
</html>
