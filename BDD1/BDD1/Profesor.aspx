<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profesor.aspx.cs" Inherits="BDD1.Profesor" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #TextAreaInstancias {
            width: 344px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
        </div>
        <asp:Panel ID="PanelMenu" runat="server" Visible="true">
            <asp:Button ID="ButtonInicio" runat="server" Text="Inicio" OnClick="ButtonInicio_Click" />
            <asp:Button ID="ButtonPeriodos" runat="server" Text="Periodos" OnClick="ButtonPeriodos_Click" />
            <asp:Button ID="ButtonGrupos" runat="server" Text="Grupos" OnClick="ButtonGrupos_Click" />
        </asp:Panel>
        <asp:Panel ID="PanelInicio" runat="server" Visible="true">
            <h1>Bienvenido Profesor</h1>
        </asp:Panel>
        <asp:Panel ID="PanelPeriodo" runat="server" Visible="false">
            <h1>Periodos</h1>
            <asp:Button ID="ButtonCrearPeriodo" runat="server" Text="Crear Periodo" OnClick="ButtonCrearPeriodo_Click" />
            <asp:Button ID="ButtonModificarPeriodo" runat="server" Text="Modificar Periodo" OnClick="ButtonModificarPeriodo_Click" />
            <asp:Button ID="ButtonAnularPeriodo" runat="server" Text="Anular Periodo" />
            <asp:Button ID="ButtonTerminarPeriodo" runat="server" Text="Terminar Periodo" />
            <asp:Panel ID="PanelCrearPeriodo" runat="server" Visible="false">
                <h2>Crear Periodo</h2>
                Fecha Inicio:&nbsp;&nbsp; <asp:TextBox ID="TextBoxFechaInicio" runat="server"></asp:TextBox>
                <br />
                Fecha Fin:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxFechaFin" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="ButtonCrearPeriodoOK" runat="server" Text="Aceptar" OnClick="ButtonCrearPeriodoOK_Click" />
            </asp:Panel>
            <asp:Panel ID="PanelModificarPeriodo" runat="server" Visible="false">
                <h2>Modificar Periodo</h2>
                Fecha Inicio:&nbsp; <asp:TextBox ID="TextBoxFechaInicioNew" runat="server"></asp:TextBox>
                <br />
                Fecha Fin:&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxFechaFinNew" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="ButtonModificarPeriodoOK" runat="server" Text="Aceptar" OnClick="ButtonCrearPeriodoOK_Click" />
            </asp:Panel>
        </asp:Panel>
        <asp:Panel ID="PanelGrupos" runat="server" Visible="false">
            <h1>Grupos</h1>
            <asp:Button ID="ButtonCrearGrupo" runat="server" Text="Crear Grupo" OnClick="ButtonCrearGrupo_Click" />
            <asp:Button ID="ButtonModificarGrupo" runat="server" Text="Modificar Grupo" OnClick="ButtonModificarGrupo_Click" />
            <asp:Button ID="ButtonAnularGrupo" runat="server" Text="Anular Grupo" />
            <asp:Button ID="ButtonTerminarGrupo" runat="server" Text="Terminar Grupo" />
            <asp:Panel ID="PanelCrearGrupo" runat="server" Visible="false">
                <h2>Crear Grupo</h2>
                Nombre Grupo:&nbsp; <asp:TextBox ID="TextBoxNombreGrupo" runat="server"></asp:TextBox>
                <br />
                Hora Inicio:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxHoraInicio" runat="server"></asp:TextBox>
                <br />
                Hora Fin:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxHoraFin" runat="server"></asp:TextBox>
                <br />
                Aula:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxAula" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="ButtonAgregarRubros" runat="server" Text="Agregar Rubros" OnClick="ButtonAgregarRubros_Click" style="text-align: center" />
                <asp:Panel ID="PanelCrearRubros" runat="server" Visible="false">
                    <h2>Crear Rubros</h2>
                    Tipo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DropDownListTipoRubro" runat="server" Width="121px">
                        <asp:ListItem>Exámenes</asp:ListItem>
                        <asp:ListItem>Quices</asp:ListItem>
                        <asp:ListItem>Tareas</asp:ListItem>
                        <asp:ListItem>Proyectos</asp:ListItem>
                        <asp:ListItem>Asistencia</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    Porcentaje: <asp:TextBox ID="TextBoxPorcentajeRubro" runat="server" Width="110px"></asp:TextBox>
                    <br />
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                        <asp:ListItem Selected="True">Fijo</asp:ListItem>
                        <asp:ListItem>Variable</asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                    <asp:Button ID="ButtonAgregarRubro" runat="server" Text="Agregar Rubro" OnClick="ButtonAgregarRubro_Click" />
                    <asp:Panel ID="PanelAregarRubro" runat="server" Visible="false">
                        <h2>Agregar Instancias de Rubro</h2>
                        <textarea id="TextAreaInstancias"  runat="server" name="S1" rows="2"></textarea>
                        <br /> 
                        Nombre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxNombreRubro" runat="server"></asp:TextBox>
                        <br />
                        Descripción: <asp:TextBox ID="TextBoxDescripcionRubro" runat="server"></asp:TextBox>
                        <br />
                        Valor:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxValorRubro" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="ButtonAgregarRubroOK" runat="server" Text="Agregar Instancia" OnClick="ButtonAgregarRubroOK_Click" />
                        <asp:Button ID="ButtonInstanciasOK" runat="server" OnClick="ButtonInstanciasOK_Click" Text="Terminar" />
                    </asp:Panel>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="PanelModificarGrupo" runat="server" Visible="false">
                <h2>Modificar Grupo</h2>
                Nombre Grupo:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxNombreGrupoNew" runat="server"></asp:TextBox>
                <br />
                Hora Inicio:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxHoraInicioNew" runat="server"></asp:TextBox>
                <br />
                Hora Fin:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxHoraFinNew" runat="server"></asp:TextBox>
                <br />
                Aula:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxAulaNew" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="ButtonModificarGrupoOK" runat="server" Text="Aceptar" OnClick="ButtonModificarGrupoOK_Click" />
            </asp:Panel>
        </asp:Panel>
    </form>    
</body>
</html>

