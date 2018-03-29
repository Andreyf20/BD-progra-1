<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfesorLogIn.aspx.cs" Inherits="BDD1.ProfesorLogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="text-align:center";>
                Iniciar Sesión para Profesores
            </h1>
        </div>
        <p style="text-align:center; font-size: large;";>
            Correo:
        </p>
        <p style="text-align:center";>
            <asp:TextBox ID="correo_Profesor" runat="server" Width="200px" ></asp:TextBox>
        </p>
        <p style="text-align:center; font-size: large;";>
            Contraseña:
        </p>
        <p style="text-align:center";>
            <asp:TextBox ID="contraseña_Profesor" runat="server" Width="200px"></asp:TextBox>
        </p>
        <p style="text-align:center";>
            <asp:Button ID="buscar_Profesor" runat="server" Text="Buscar Registros" OnClick="buscar_Profesor_Click" Height="50px" Width="200px" style="font-size: x-large; background-color: #3366FF" />
        </p>
    </form>
</body>
</html>
