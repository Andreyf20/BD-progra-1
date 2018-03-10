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
        <p style="text-align:center";>
            Correo:
        </p>
        <p style="text-align:center";>
            <asp:TextBox ID="correo_Profesor" runat="server" ></asp:TextBox>
        </p>
        <p style="text-align:center";>
            Contraseña:
        </p>
        <p style="text-align:center";>
            <asp:TextBox ID="contraseña_Profesor" runat="server"></asp:TextBox>
        </p>
        <p style="text-align:center";>
            <asp:Button ID="buscar_Profesor" runat="server" Text="Buscar Registros" OnClick="buscar_Profesor_Click" Height="43px" Width="136px" />
        </p>
    </form>
</body>
</html>
