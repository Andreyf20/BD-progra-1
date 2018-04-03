
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="BDD1.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Profesor" Height="200px" Width="740px" style="font-size: xx-large; background-color: #3366FF; font-weight: 700;" Font-Bold="True" Font-Size="XX-Large" /></td>
                    <td><asp:Button ID="Button2" runat="server" Text="Estudiante" OnClick="Button2_Click" Height="200px" Width="740px" style="font-size: xx-large; background-color: #FF3300; font-weight: 700;" /></td>
                </tr>
            </table>
                <asp:Panel ID="Panel1" runat="server" Visible="false">
            <div>
                <h1 ;="" style="text-align:center">Iniciar Sesión para Profesores </h1>
            </div>
            <p ;="" style="text-align:center; font-size: xx-large;">
                &nbsp;</p>
            <p ;="" style="text-align:center; font-size: xx-large;">
                Correo:
            </p>
            <p ;="" style="text-align:center">
                <asp:TextBox ID="correo_Profesor" runat="server" CssClass="auto-style1" Width="350px"></asp:TextBox>
            </p>
            <p ;="" style="text-align:center; font-size: xx-large;">
                Contraseña:
            </p>
            <p ;="" style="text-align:center">
                <asp:TextBox ID="contraseña_Profesor" runat="server" CssClass="auto-style1" Width="350px"></asp:TextBox>
            </p>
            <p ;="" style="text-align:center">
                <asp:Button ID="buscar_Profesor" runat="server" Height="50px" OnClick="buscar_Profesor_Click" style="font-size: xx-large; background-color: #3366FF" Text="Buscar Registros" Width="350px" />
            </p>
            <p ;="" style="text-align:center">
                <asp:Label ID="Label1" runat="server" style="font-weight: 700; font-size: xx-large" Text="Label" Visible="False"></asp:Label>
            </p>
        </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server" Visible="false" >
        <div>
            <h1 style="text-align:center";>
                Iniciar Sesión para Estudiantes
            </h1>
        </div>
        <p style="text-align:center; font-size: xx-large;";>
            &nbsp;</p>
        <p style="text-align:center; font-size: xx-large;";>
            Correo:
        </p>
        <p style="text-align:center";>
            <asp:TextBox ID="correo_Estudiante" runat="server" style="font-size: large" Width="350px" ></asp:TextBox>
        </p>
        <p style="text-align:center; font-size: xx-large;";>
            Contraseña:
        </p>
        <p style="text-align:center";>
            <asp:TextBox ID="contraseña_Estudiante" runat="server" style="font-size: large" Width="350px" ></asp:TextBox>
        </p>
        <p style="text-align:center";>
            <asp:Button ID="buscar_estudiante" runat="server" Text="Buscar Notas" OnClick="buscar_estudiante_Click" Height="50px" Width="350px" style="font-size: xx-large; background-color: #3366FF" />
        </p>
        <p style="text-align:center";>
            <asp:Label ID="Label2" runat="server" style="font-weight: 700; font-size: xx-large" Text="Label" Visible="False"></asp:Label>
        </p>
        </asp:Panel>
        </div>
    </form>
</body>
</html>



