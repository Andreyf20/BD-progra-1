﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfesorWindow.aspx.cs" Inherits="BDD1.ProfesorWindow" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #TextAreaInstancias {
            width: 344px;
        }
        .auto-style1 {
            color: #FFFFFF;
            font-size: xx-large;
        }
        .auto-style2 {
            color: #FFFFFF;
            font-size: xx-large;
            background-color: #3333FF;
        }
        .auto-style4 {
            font-size: xx-large;
        }
        .auto-style5 {
            font-size: xx-large;
            color: #FFFFFF;
            background-color: #800000;
        }
        .auto-style6 {
            color: #FFFFFF;
            font-size: xx-large;
            background-color: #800080;
        }
        .auto-style7 {
            font-size: large;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div >
        </div>
        <asp:Panel ID="PanelMenu" runat="server" Visible="true" BackColor="#3333FF">
            <asp:Button ID="ButtonInicio" runat="server" Text="Inicio" OnClick="ButtonInicio_Click" Width="24%" Height="50px" BorderStyle="None" CssClass="auto-style2"/>
            <asp:Button ID="ButtonPeriodos" runat="server" Text="Periodos" OnClick="ButtonPeriodos_Click" Width="24%" Height="50px" BackColor="#3333FF" BorderStyle="None" CssClass="auto-style1" Font-Size="XX-Large"/>
            <asp:Button ID="ButtonGrupos" runat="server" Text="Grupos" OnClick="ButtonGrupos_Click" Width="24%" Height="50px" BorderStyle="None" CssClass="auto-style2"/>
            <asp:Button ID="ButtonRegistrarNotas" runat="server" Text="Registrar Notas" OnClick="ButtonRegistrarNotas_Click" Width="24%" Height="50px" BorderStyle="None" CssClass="auto-style2"/>
        </asp:Panel>
        <asp:Panel style="text-align:center" ID="PanelInicio" runat="server" Visible="true">
            
            <h1>
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </h1>
            <h1>
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </h1>
        </asp:Panel>
        <asp:Panel ID="PanelPeriodo" runat="server" Visible="false">
            <h1>Periodos</h1>
            <asp:Button ID="ButtonCrearPeriodo" runat="server" Text="Crear Periodo" OnClick="ButtonCrearPeriodo_Click" Width="49%" Height="50px" CssClass="auto-style6" />
            <asp:Button ID="ButtonAnularPeriodo" runat="server" Text="Anular o Terminar Periodo" Width="49%" Height="50px" OnClick="ButtonAnularPeriodo_Click" CssClass="auto-style6" />
            <asp:Panel ID="PanelCrearPeriodo" style="text-align:center" runat="server" Visible="false">
                <h2 style="font-size: xx-large">Crear Periodo</h2>
                <table style="width:100%; height: 213px;">
                <tr>
                    <td>
                        <span class="auto-style4">Fecha Inicio: </span>
                        <asp:Calendar style=" margin: 0 auto;" ID="CalendarInicio" runat="server"></asp:Calendar>
                    </td>
                    <td>
                        <span class="auto-style4">Fecha Fin</span>:
                        <asp:Calendar style=" margin: 0 auto;" ID="CalendarFinal" runat="server"></asp:Calendar>
                    </td>
                </tr>
                </table>                
                <asp:Button ID="ButtonCrearPeriodoOK" runat="server" OnClick="ButtonCrearPeriodoOK_Click" Text="Aceptar" CssClass="auto-style5" Height="75px" Width="200px" />
            </asp:Panel>
            
            <asp:Panel ID="PanelAnularPeriodo" style="text-align:center" runat="server" Visible="false">
                <h2 class="auto-style4" >Anular Periodo</h2>
                <span class="auto-style7">Seleccione el ID del Periodo: </span>
                <asp:RadioButtonList style=" margin: 0 auto;" ID="RadioButtonListPeriodos2" runat="server" RepeatDirection="Horizontal">
                </asp:RadioButtonList>
                <br />
                <asp:Button ID="ButtonAnularPeriodoOK" runat="server" OnClick="ButtonAnularPeriodoOK_Click" Text="Anular" CssClass="auto-style5" Height="75px" Width="200px" />
                <asp:Button ID="ButtonTerminarPeriodoOK" runat="server" CssClass="auto-style5" Height="75px" OnClick="ButtonTerminarPeriodoOK_Click" Text="Terminar" Width="200px" />
            </asp:Panel>
        </asp:Panel>
        <asp:Panel ID="PanelGrupos" runat="server" Visible="false">
            <h1>Grupos</h1>
            <asp:Button ID="ButtonCrearGrupo" runat="server" Text="Crear Grupo" OnClick="ButtonCrearGrupo_Click" Width="33%" Height="50px" CssClass="auto-style6"/>
            <asp:Button ID="ButtonModificarGrupo" runat="server" Text="Modificar Grupo" OnClick="ButtonModificarGrupo_Click" Width="33%" Height="50px" CssClass="auto-style6"/>
            <asp:Button ID="ButtonAnularGrupo" runat="server" Text="Anular o Terminar Grupo" Width="33%" Height="50px" OnClick="ButtonAnularGrupo_Click" CssClass="auto-style6" />
            
            <asp:Panel ID="PanelCrearGrupo" style="text-align:center" runat="server" Visible="false">
                <h2 class="auto-style4" >Crear Grupo</h2>
                <span class="auto-style7">
                <br />
                Seleccione el ID del Periodo:
                <asp:RadioButtonList ID="RadioButtonListPeriodos4" runat="server" style=" margin: 0 auto;" RepeatDirection="Horizontal" >
                </asp:RadioButtonList>
                <br />
                Seleccione el estado del Grupo:
                <asp:RadioButtonList ID="RadioButtonListEstadoGrupo" runat="server" style=" margin: 0 auto;" RepeatDirection="Horizontal">
                </asp:RadioButtonList>
                <br />
                Nombre Curso:&nbsp; </span>
                <asp:TextBox ID="TextBoxNombreGrupo" runat="server" CssClass="auto-style7"></asp:TextBox>
                <br class="auto-style7" />
                <span class="auto-style7">
                <br />
                Código Grupo :&nbsp;&nbsp; </span>
                <asp:TextBox ID="TextBoxCodigoGrupo" runat="server" CssClass="auto-style7"></asp:TextBox>
                <br />
                <br />
                <br />
                <asp:Button ID="ButtonCrearGrupoOK" runat="server" OnClick="ButtonCrearGrupoOK_Click"  Text="Crear Grupo" CssClass="auto-style5" Height="75px" Width="200px" />
            </asp:Panel>               
            <asp:Panel ID="PanelModificarGrupo" style="text-align:center" runat="server" Visible="false">
                <span class="auto-style7">
                <br />
                Seleccione el ID del Periodo:
                <asp:RadioButtonList ID="RadioButtonListPeriodos5" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SelectedIndexChangedPeriodo1" style=" margin: 0 auto;" RepeatDirection="Horizontal">
                </asp:RadioButtonList>
                <br />
                Seleccione el Grupo:
                <asp:RadioButtonList ID="RadioButtonListGrupos1" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="SelectedIndexChangedGrupo" style=" margin: 0 auto;">
                </asp:RadioButtonList>
                <br />
                 </span>
            <asp:Button ID="ButtonModificarNormal" Visible="false" runat="server" Text="Modificar Nombre y Codigo" Width="33%" Height="50px" OnClick="ButtonModificarGrupoNormal_Click" CssClass="auto-style6" />
            <asp:Button ID="ButtonAgregarRubro" Visible="false" runat="server" Text="Agregar Rubro" OnClick="ButtonAgregarRubro_Click" Width="33%" Height="50px" CssClass="auto-style6"/>
            <asp:Button ID="ButtonAgregarEvaluacion" Visible="false" runat="server" Text="Agregar Evaluacion" OnClick="ButtonAgregarEvaluacion_Click" Width="33%" Height="50px" CssClass="auto-style6"/>
            
            <asp:Panel ID="PanelModificarNormal" style="text-align:center" runat="server" Visible="false">
                <h2 class="auto-style4">Modificar Grupo</h2>
                Nombre Grupo:&nbsp;
                <asp:TextBox ID="TextBoxNombreGrupoNew" runat="server" CssClass="auto-style7"></asp:TextBox>
                <br class="auto-style7" />
                <span class="auto-style7">
                <br />
                Código Grupo :&nbsp; </span>
                <asp:TextBox ID="TextBoxCodigoGrupoNew" runat="server" CssClass="auto-style7"></asp:TextBox>
                <br />
                <br />
                <br class="auto-style7" />
                <asp:Button ID="ButtonModificarGrupoOK" runat="server" OnClick="ButtonModificarGrupoOK_Click" Text="Aceptar" CssClass="auto-style5" Height="75px" Width="200px" />
            </asp:Panel>
            <asp:Panel ID="PanelAgregarRubro" style="text-align:center" runat="server" Visible="false">
                <table style="width:100%;">
                <tr>
                <td>
                        <asp:Panel style="text-align:center" ID="PanelCrearRubros" runat="server" Visible="true">
                    <h2 class="auto-style4" >Crear Rubros</h2>
                            <span class="auto-style7">
                            <br />
                            Tipo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span> <asp:DropDownList ID="DropDownListTipoRubro" runat="server" Width="121px" CssClass="auto-style7">
                        
                    </asp:DropDownList>
                    <br class="auto-style7" />
                            <span class="auto-style7">
                            <br />
                            Porcentaje: </span> <asp:TextBox ID="TextBoxPorcentajeRubro"   runat="server" Width="110px" CssClass="auto-style7"></asp:TextBox>
                    <br class="auto-style7" />
                    <asp:RadioButtonList style=" margin: 0 auto;" ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Selected="True">Fijo</asp:ListItem>
                        <asp:ListItem>Variable</asp:ListItem>
                    </asp:RadioButtonList>
                            <br />
                    <br class="auto-style7" />
                            <asp:Label ID="LabelCantidad" runat="server" Text="Cantidad: " CssClass="auto-style7"></asp:Label>
                            <asp:TextBox ID="TextBoxCantidadRubro"  runat="server" Width="110px" CssClass="auto-style7"></asp:TextBox>
                            <br />
                    <br />
                    <asp:Button  ID="ButtonAgregarRubro1" runat="server" Text="Agregar Rubro" OnClick="ButtonAgregarRubroOK_Click" CssClass="auto-style5" Height="75px" Width="200px" />
                            <asp:Button ID="ButtonGrupoOK" runat="server" OnClick="ButtonGrupoOK_Click" Text="Terminar" CssClass="auto-style5" Height="75px" Width="200px" />
                </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel style="text-align:center" ID="PanelAgregarEvaluaciones1" runat="server" Visible="false">
                        <h2 class="auto-style4">Agregar Evaluaciones</h2>
                        <textarea id="TextAreaInstancias"  runat="server" name="S1" rows="2"></textarea>
                        <br /> 
                            <span class="auto-style7">Nombre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span> <asp:TextBox ID="TextBoxNombreRubro" runat="server" CssClass="auto-style7"></asp:TextBox>
                        <br class="auto-style7" />
                            <span class="auto-style7">
                            <br />
                            Descripción: </span> <asp:TextBox ID="TextBoxDescripcionRubro" runat="server" CssClass="auto-style7"></asp:TextBox>
                        <br class="auto-style7" />
                            <span class="auto-style7">
                            <br />
                            Valor:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span> <asp:TextBox ID="TextBoxValorRubro" runat="server" CssClass="auto-style7"></asp:TextBox>
                        <br />
                        <asp:Calendar style=" margin: 0 auto;" ID="CalendarEvaluacion" runat="server"></asp:Calendar>
                            <br />
                        <asp:Button ID="ButtonAgregarRubroOK" runat="server" Text="Agregar Evaluacion" OnClick="ButtonAgregarEvaluacionOK_Click" CssClass="auto-style5" Height="75px" Width="200px" />
                        <asp:Button ID="ButtonInstanciasOK" runat="server" OnClick="ButtonInstanciasOK_Click" Text="Terminar" CssClass="auto-style5" Height="75px" Width="200px" />
                    </asp:Panel>
                    </td>
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="PanelAgregarEvaluaciones2" style="text-align:center" runat="server" Visible="false">
                <h2 class="auto-style4">Agregar Evaluaciones Variables</h2>
                        &nbsp;<br /> 
                            <span class="auto-style7">Nombre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span> <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style7"></asp:TextBox>
                        <br class="auto-style7" />
                            <span class="auto-style7">
                            <br />
                            Descripción: </span> <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style7"></asp:TextBox>
                        <br class="auto-style7" />
                            <span class="auto-style7">
                            <br />
                            Valor:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span> <asp:TextBox ID="TextBox3" runat="server" CssClass="auto-style7"></asp:TextBox>
                        <br />
                        <asp:Calendar style=" margin: 0 auto;" ID="Calendar1" runat="server"></asp:Calendar>
                            <br />
                        <asp:Button ID="Button1" runat="server" Text="Agregar Evaluacion" OnClick="ButtonAgregarEvaluacionVariable_Click" CssClass="auto-style5" Height="75px" Width="200px" />
            </asp:Panel>

            </asp:Panel>
            <asp:Panel ID="PanelAnularGrupo" style="text-align:center" runat="server" Visible="false">
                <h2 class="auto-style4" >Anular o Terminar Grupo</h2>
                <span class="auto-style7">
                <br />
                Seleccione el ID del Periodo: </span>
                <asp:RadioButtonList style=" margin: 0 auto; font-size: large;" ID="RadioButtonListPeriodos6" runat="server" OnSelectedIndexChanged="SelectedIndexChangedPeriodo2" AutoPostBack="True" RepeatDirection="Horizontal">
                </asp:RadioButtonList>
                <br class="auto-style7" />
                <span class="auto-style7">Seleccione el Grupo: </span>
                <asp:RadioButtonList style=" margin: 0 auto; font-size: large;" ID="RadioButtonListGrupos2" runat="server" AutoPostBack="True">
                </asp:RadioButtonList>
                <br />
                <asp:Button ID="ButtonAnularGrupoOK" runat="server" OnClick="ButtonAnularGrupoOK_Click" Text="Anular" CssClass="auto-style5" Height="75px" Width="200px" />
                <asp:Button ID="ButtonTerminarGrupoOK" runat="server" CssClass="auto-style5" Height="75px" OnClick="ButtonTerminarGrupoOK_Click" Text="Terminar" Width="200px" />
            </asp:Panel>
        </asp:Panel>
        <asp:Panel style="text-align:center" ID="PanelRegistrarNotas" runat="server" Visible="false">
            <h1>Registrar Notas</h1>
            <br />
            <span class="auto-style7">Seleccione el ID del Periodo</span>:
                <asp:RadioButtonList style=" margin: 0 auto;" ID="RadioButtonListPeriodos8" runat="server" OnSelectedIndexChanged="SelectedIndexChangedPeriodo4" AutoPostBack="True" CssClass="auto-style7">
                </asp:RadioButtonList>
            <br />
            <span class="auto-style7">Seleccione el Grupo: </span>
                <asp:RadioButtonList style=" margin: 0 auto;" ID="RadioButtonListGrupos4" runat="server" OnSelectedIndexChanged="SelectedIndexChangedGrupo" AutoPostBack="True" CssClass="auto-style7">
                </asp:RadioButtonList>
            <br />
            <asp:Button ID="ButtonOKGrupo" runat="server" Visible="false" OnClick="ButtonOKGrupo_Click" Text="Aceptar" CssClass="auto-style5" Height="75px" Width="200px" />
        </asp:Panel>
    </form>    
</body>
</html>

