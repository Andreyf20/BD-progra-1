<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="BDD1.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Profesor" Height="400px" Width="400px" style="font-size: xx-large; background-color: #3366FF" />
            <asp:Button ID="Button2" runat="server" Text="Estudiante" OnClick="Button2_Click" Height="400px" Width="400px" style="font-size: xx-large; background-color: #FF3300" />
        </div>
    </form>
</body>
</html>



