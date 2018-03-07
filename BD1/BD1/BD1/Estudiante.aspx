<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Estudiante.aspx.cs" Inherits="BD1.Estudiante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ESTUDIANTES</div>
        <p>
            NOMBRE:</p>
        <p>
            <asp:TextBox ID="nombre_estudiante" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="buscar_estudiante" runat="server" Text="Buscar Notas" />
        </p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
