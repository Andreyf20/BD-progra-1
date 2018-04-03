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
        Seleccione el ID del Periodo:
        <asp:RadioButtonList ID="RadioButtonListPeriodos" runat="server" style=" margin: 0 auto;" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonListPeriodos_SelectedIndexChanged">
        </asp:RadioButtonList>
        <br />
        Seleccione el Grupo:
        <asp:RadioButtonList ID="RadioButtonListGrupos" runat="server" style=" margin: 0 auto;" RepeatDirection="Vertical">
        </asp:RadioButtonList>
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
