﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profesor.aspx.cs" Inherits="BDD1.Profesor" %>
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
        <div >
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cargar Datos" />
        </div>
        <asp:Panel ID="PanelMenu" runat="server" Visible="true">
            <asp:Button ID="ButtonInicio" runat="server" Text="Inicio" OnClick="ButtonInicio_Click" Width="24%" Height="50px"/>
            <asp:Button ID="ButtonPeriodos" runat="server" Text="Periodos" OnClick="ButtonPeriodos_Click" Width="24%" Height="50px"/>
            <asp:Button ID="ButtonGrupos" runat="server" Text="Grupos" OnClick="ButtonGrupos_Click" Width="24%" Height="50px"/>
            <asp:Button ID="ButtonRegistrarNotas" runat="server" Text="Registrar Notas" OnClick="ButtonRegistrarNotas_Click" Width="24%" Height="50px"/>
        </asp:Panel>
        <asp:Panel style="text-align:center" ID="PanelInicio" runat="server" Visible="true">
            <h1>Bienvenido Profesor</h1>
            <h1>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </h1>
        </asp:Panel>
        <asp:Panel ID="PanelPeriodo" runat="server" Visible="false">
            <h1>Periodos</h1>
            <asp:Button ID="ButtonCrearPeriodo" runat="server" Text="Crear Periodo" OnClick="ButtonCrearPeriodo_Click" Width="24%" Height="50px" />
            <asp:Button ID="ButtonModificarPeriodo" runat="server" Text="Modificar Periodo" OnClick="ButtonModificarPeriodo_Click" Width="24%" Height="50px" />
            <asp:Button ID="ButtonAnularPeriodo" runat="server" Text="Anular Periodo" Width="24%" Height="50px" OnClick="ButtonAnularPeriodo_Click" />
            <asp:Button ID="ButtonTerminarPeriodo" runat="server" Text="Terminar Periodo" Width="24%" Height="50px" OnClick="ButtonTerminarPeriodo_Click" />
            <asp:Panel ID="PanelCrearPeriodo" style="text-align:center" runat="server" Visible="false">
                <h2>Crear Periodo</h2>
                <table style="width:100%; height: 213px;">
                <tr>
                    <td>
                        Fecha Inicio:
                        <asp:Calendar style=" margin: 0 auto;" ID="CalendarInicio" runat="server"></asp:Calendar>
                    </td>
                    <td>
                        Fecha Fin:
                        <asp:Calendar style=" margin: 0 auto;" ID="CalendarFinal" runat="server"></asp:Calendar>
                    </td>
                </tr>
                </table>                
                <asp:Button ID="ButtonCrearPeriodoOK" runat="server" OnClick="ButtonCrearPeriodoOK_Click" Text="Aceptar" />
            </asp:Panel>
            <asp:Panel ID="PanelModificarPeriodo" style="text-align:center" runat="server" Visible="false">
                <h2 >Modificar Periodo</h2>
                Seleccione el ID del Periodo:
                <asp:RadioButtonList style=" margin: 0 auto;" ID="RadioButtonListPeriodos1" runat="server">
                </asp:RadioButtonList>
                Seleccione el estado del periodo:
                <asp:RadioButtonList  style=" margin: 0 auto;" ID="RadioButtonList2" runat="server">
                    <asp:ListItem Selected="True">Activo</asp:ListItem>
                    <asp:ListItem>Inactivo</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <asp:Button ID="ButtonModificarPeriodoOK" runat="server" OnClick="ButtonModificarPeriodoOK_Click" Text="Aceptar" />
            </asp:Panel>
            <asp:Panel ID="PanelAnularPeriodo" style="text-align:center" runat="server" Visible="false">
                <h2 >Anular Periodo</h2>
                Seleccione el ID del Periodo:
                <asp:RadioButtonList style=" margin: 0 auto;" ID="RadioButtonListPeriodos2" runat="server">
                </asp:RadioButtonList>
                <br />
                <asp:Button ID="ButtonAnularPeriodoOK" runat="server" OnClick="ButtonAnularPeriodoOK_Click" Text="Aceptar" />
            </asp:Panel>
            <asp:Panel ID="PanelTerminarPeriodo" style="text-align:center" runat="server" Visible="false">
                <h2 >Terminar Periodo</h2>
                Seleccione el ID del Periodo:
                <asp:RadioButtonList style=" margin: 0 auto;" ID="RadioButtonListPeriodos3" runat="server">
                </asp:RadioButtonList>
                <br />
                <asp:Button ID="ButtonTerminarPeriodoOK" runat="server" OnClick="ButtonTerminarPeriodoOK_Click" Text="Aceptar" />
            </asp:Panel>
        </asp:Panel>
        <asp:Panel ID="PanelGrupos" runat="server" Visible="false">
            <h1>Grupos</h1>
            <asp:Button ID="ButtonCrearGrupo" runat="server" Text="Crear Grupo" OnClick="ButtonCrearGrupo_Click" Width="24%" Height="50px"/>
            <asp:Button ID="ButtonModificarGrupo" runat="server" Text="Modificar Grupo" OnClick="ButtonModificarGrupo_Click" Width="24%" Height="50px" />
            <asp:Button ID="ButtonAnularGrupo" runat="server" Text="Anular Grupo" Width="24%" Height="50px" OnClick="ButtonAnularGrupo_Click" />
            <asp:Button ID="ButtonTerminarGrupo" runat="server" Text="Terminar Grupo" Width="24%" Height="50px" OnClick="ButtonTerminarGrupo_Click" />
            <table style="width:100%;">
                <tr>
                    <td>
                        <asp:Panel ID="PanelCrearGrupo" style="text-align:center" runat="server" Visible="false">
                            <h2 >Crear Grupo</h2>
                            Seleccione el ID del Periodo:
                            <asp:RadioButtonList style=" margin: 0 auto;" ID="RadioButtonListPeriodos4" runat="server">
                            </asp:RadioButtonList>
                            Nombre Curso:&nbsp;
                            <asp:TextBox ID="TextBoxNombreGrupo" runat="server"></asp:TextBox>
                            <br />
                            Código Grupo :&nbsp;&nbsp;
                            <asp:TextBox ID="TextBoxCodigoGrupo" runat="server"></asp:TextBox>
                            <br />
                            <asp:Button ID="ButtonCrearGrupoOK" runat="server" OnClick="ButtonCrearGrupoOK_Click"  Text="Crear Grupo" />
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel style="text-align:center" ID="PanelCrearRubros" runat="server" Visible="false">
                    <h2 >Crear Rubros</h2>
                    Tipo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DropDownListTipoRubro" runat="server" Width="121px">
                        
                    </asp:DropDownList>
                    <br />
                    Porcentaje: <asp:TextBox ID="TextBoxPorcentajeRubro"   runat="server" Width="110px"></asp:TextBox>
                    <br />
                    <asp:RadioButtonList style=" margin: 0 auto;" ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Selected="True">Fijo</asp:ListItem>
                        <asp:ListItem>Variable</asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                            <asp:Label ID="LabelCantidad" runat="server" Text="Cantidad"></asp:Label>
                            <asp:TextBox ID="TextBoxCantidadRubro"  runat="server" Width="110px"></asp:TextBox>
                    <br />
                    <asp:Button  ID="ButtonAgregarRubro" runat="server" Text="Agregar Rubro" OnClick="ButtonAgregarRubro_Click" />
                            <asp:Button ID="ButtonGrupoOK" runat="server" OnClick="ButtonGrupoOK_Click" Text="Terminar" />
                </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel style="text-align:center" ID="PanelAregarRubro" runat="server" Visible="false">
                        <h2>Agregar Instancias de Rubro</h2>
                        <textarea id="TextAreaInstancias"  runat="server" name="S1" rows="2"></textarea>
                        <br /> 
                        Nombre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxNombreRubro" runat="server"></asp:TextBox>
                        <br />
                        Descripción: <asp:TextBox ID="TextBoxDescripcionRubro" runat="server"></asp:TextBox>
                        <br />
                        Valor:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxValorRubro" runat="server"></asp:TextBox>
                        <br />
                        <asp:Calendar style=" margin: 0 auto;" ID="CalendarEvaluacion" runat="server"></asp:Calendar>
                        <asp:Button ID="ButtonAgregarRubroOK" runat="server" Text="Agregar Instancia" OnClick="ButtonAgregarRubroOK_Click" />
                        <asp:Button ID="ButtonInstanciasOK" runat="server" OnClick="ButtonInstanciasOK_Click" Text="Terminar" />
                    </asp:Panel>
                    </td>
                </tr>
            </table>
            
            <asp:Panel ID="PanelModificarGrupo" style="text-align:center" runat="server" Visible="false">
                <h2>Modificar Grupo</h2>
                Seleccione el ID del Periodo:
                <asp:RadioButtonList style=" margin: 0 auto;" ID="RadioButtonListPeriodos5" runat="server" OnSelectedIndexChanged="SelectedIndexChangedPeriodo" AutoPostBack="True">
                </asp:RadioButtonList>
                <asp:RadioButtonList style=" margin: 0 auto;" ID="RadioButtonListGrupos1" runat="server" OnSelectedIndexChanged="SelectedIndexChangedGrupo" AutoPostBack="True">
                </asp:RadioButtonList>
                Nombre Grupo:&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBoxNombreGrupoNew" runat="server"></asp:TextBox>
                <br />
                Código Grupo :&nbsp;&nbsp;
                <asp:TextBox ID="TextBoxCodigoGrupoNew" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="ButtonModificarGrupoOK" runat="server" OnClick="ButtonModificarGrupoOK_Click" Text="Aceptar" />
            </asp:Panel>
            <asp:Panel ID="PanelAnularGrupo" style="text-align:center" runat="server" Visible="false">
                <h2 >Anular Grupo</h2>
                Seleccione el ID del Periodo:
                <asp:RadioButtonList style=" margin: 0 auto;" ID="RadioButtonListPeriodos6" runat="server" OnSelectedIndexChanged="SelectedIndexChangedPeriodo" AutoPostBack="True">
                </asp:RadioButtonList>
                <asp:RadioButtonList style=" margin: 0 auto;" ID="RadioButtonListGrupos2" runat="server" AutoPostBack="True">
                </asp:RadioButtonList>
                <br />
                <asp:Button ID="ButtonAnularGrupoOK" runat="server" OnClick="ButtonAnularGrupoOK_Click" Text="Aceptar" />
            </asp:Panel>
            <asp:Panel ID="PanelTerminarGrupo" style="text-align:center" runat="server" Visible="false">
                <h2 >Terminar Grupo</h2>
                Seleccione el ID del Periodo:
                <asp:RadioButtonList style=" margin: 0 auto;" ID="RadioButtonListPeriodos7" runat="server" OnSelectedIndexChanged="SelectedIndexChangedPeriodo" AutoPostBack="True">
                </asp:RadioButtonList>
                <asp:RadioButtonList style=" margin: 0 auto;" ID="RadioButtonListGrupos3" runat="server" AutoPostBack="True">
                </asp:RadioButtonList>
                <br />
                <asp:Button ID="ButtonTerminarGrupoOK" runat="server" OnClick="ButtonTerminarGrupoOK_Click" Text="Aceptar" />
            </asp:Panel>
        </asp:Panel>
        <asp:Panel style="text-align:center" ID="PanelRegistrarNotas" runat="server" Visible="false">
            <h1>Registrar Notas</h1>
            Seleccione el ID del Periodo:
                <asp:RadioButtonList style=" margin: 0 auto;" ID="RadioButtonListPeriodos8" runat="server" OnSelectedIndexChanged="SelectedIndexChangedPeriodo" AutoPostBack="True">
                </asp:RadioButtonList>
                <asp:RadioButtonList style=" margin: 0 auto;" ID="RadioButtonListGrupos4" runat="server" OnSelectedIndexChanged="SelectedIndexChangedGrupo" AutoPostBack="True">
                </asp:RadioButtonList>
            <asp:Button ID="ButtonOKGrupo" runat="server" Visible="false" OnClick="ButtonOKGrupo_Click" Text="Aceptar" />
        </asp:Panel>
    </form>    
</body>
</html>

