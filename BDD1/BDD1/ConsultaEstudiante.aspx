<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaEstudiante.aspx.cs" Inherits="BDD1.ConsultaEstudiante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #formTitulo {
            text-align: center;
        }
        .auto-style1 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="formTitulo" runat="server">
        <div>
            <asp:ImageButton ID="ImageButton1" ImageUrl="~/icon.jpg" runat="server" Height="47px" Width="5%" OnClick="ImageButton1_Click" />
            <h1>
                Notas del Estudiante
            </h1>          
        </div>
        <div class="auto-style1">
        Seleccione el Grupo:
            <asp:Panel ID="Panel1" runat="server">
            </asp:Panel>
        </div>

        <asp:RadioButtonList ID="RadioButtonListGrupos" runat="server" style=" margin: 0 auto;" RepeatDirection="Vertical" AutoPostBack="True" OnSelectedIndexChanged="SelectedIndexChangedGrupo">
        </asp:RadioButtonList>
        <br />
        <asp:Label ID="Label1" runat="server" Visible="false" Text=""></asp:Label>
        <br />
        
        <asp:GridView ID="GridView1" runat="server" style=" margin: 0 auto;">
        </asp:GridView>
    </form>
</body>
</html>
