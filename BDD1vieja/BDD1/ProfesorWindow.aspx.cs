using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;


namespace BDD1
{
    public partial class ProfesorWindow : System.Web.UI.Page
    {
        public static int ProfesorID;
        public static Grupo grupoActivo;
        protected void Page_Load(object sender, EventArgs e)
        {
            BD bd = new BD();

        }

        //Cargar Datos
        protected void Button1_Click(object sender, EventArgs e)
        {
            

        }
        
        //Inicio
        protected void ButtonInicio_Click(object sender, EventArgs e)
        {
            Inicio();
        }

        private void Inicio()
        {
            PanelAregarRubro.Visible = false;
            PanelCrearGrupo.Visible = false;
            PanelCrearPeriodo.Visible = false;
            PanelCrearRubros.Visible = false;
            PanelModificarGrupo.Visible = false;
            PanelModificarPeriodo.Visible = false;
            PanelPeriodo.Visible = false;
            PanelGrupos.Visible = false;
            PanelInicio.Visible = true;
            PanelRegistrarNotas.Visible = false;
            PanelAnularPeriodo.Visible = false;
            PanelTerminarPeriodo.Visible = false;
            PanelAnularGrupo.Visible = false;
            PanelTerminarGrupo.Visible = false;
            Label1.Text = "";
        }


        //Periodo
        protected void ButtonPeriodos_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelPeriodo.Visible = true;
        }

        protected void ButtonCrearPeriodo_Click(object sender, EventArgs e)
        {
            PanelCrearPeriodo.Visible = true;
            PanelModificarPeriodo.Visible = false;
            PanelAnularPeriodo.Visible = false;
            PanelTerminarPeriodo.Visible = false;
        }

        protected void ButtonCrearPeriodoOK_Click(object sender, EventArgs e)
        {
            int activo = Procedures.periodo_crear(CalendarInicio.SelectedDate, CalendarFinal.SelectedDate);
            if (activo==1)
            {
                Periodo periodoActual = new Periodo(CalendarInicio.SelectedDate, CalendarFinal.SelectedDate,"True");
                BD.periodosActivos.Add(periodoActual);
            }
            else
            {
                Periodo periodoActual = new Periodo(CalendarInicio.SelectedDate, CalendarFinal.SelectedDate, "False");
                BD.periodosActivos.Add(periodoActual);
            }
            Inicio();
            Label1.Text = "Periodo Creado Correctamente";
        }

        protected void ButtonModificarPeriodo_Click(object sender, EventArgs e)
        {
            PanelCrearPeriodo.Visible = false;
            PanelModificarPeriodo.Visible = true;
            PanelAnularPeriodo.Visible = false;
            PanelTerminarPeriodo.Visible = false;
            RadioButtonListPeriodos1.Items.Clear();
            if (BD.periodosActivos.Count != 0)
            {
                for (int i = 0; i < BD.periodosActivos.Count; i++)
                {
                    RadioButtonListPeriodos1.Items.Add(new ListItem(BD.periodosActivos[i].ID.ToString()));
                }
            }
        }

        protected void ButtonModificarPeriodoOK_Click(object sender, EventArgs e)
        {
            int periodoID = int.Parse(RadioButtonListPeriodos1.SelectedItem.Text);
            if (RadioButtonList2.SelectedItem.Text.Equals("Activo"))
            {
                Procedures.periodo_CambiarActivo(periodoID, "True");
                BD.periodosActivos[periodoID].activo = "True";
            }
            else
            {
                Procedures.periodo_CambiarActivo(periodoID, "False");
                BD.periodosActivos[periodoID].activo = "False";
            }
            Inicio();
            Label1.Text = "Periodo Modificado Correctamente";
        }

        protected void ButtonAnularPeriodo_Click(object sender, EventArgs e)
        {
            PanelCrearPeriodo.Visible = false;
            PanelModificarPeriodo.Visible = false;
            PanelAnularPeriodo.Visible = true;
            PanelTerminarPeriodo.Visible = false;
            RadioButtonListPeriodos2.Items.Clear();
            if (BD.periodosActivos.Count != 0)
            {
                for (int i = 0; i < BD.periodosActivos.Count; i++)
                {
                    RadioButtonListPeriodos2.Items.Add(new ListItem(BD.periodosActivos[i].ID.ToString()));
                }
            }
        }

        protected void ButtonAnularPeriodoOK_Click(object sender, EventArgs e)
        {
            int periodoID = int.Parse(RadioButtonListPeriodos2.SelectedItem.Text);
            BD.periodosActivos[periodoID] = null;
            Procedures.periodo_borrar(periodoID);
            Inicio();
            Label1.Text = "Periodo Anulado Correctamente";
        }

        protected void ButtonTerminarPeriodo_Click(object sender, EventArgs e)
        {
            PanelCrearPeriodo.Visible = false;
            PanelModificarPeriodo.Visible = false;
            PanelAnularPeriodo.Visible = false;
            PanelTerminarPeriodo.Visible = true;
            RadioButtonListPeriodos3.Items.Clear();
            if (BD.periodosActivos.Count != 0)
            {
                for (int i = 0; i < BD.periodosActivos.Count; i++)
                {
                    RadioButtonListPeriodos3.Items.Add(new ListItem(BD.periodosActivos[i].ID.ToString()));
                }
            }
        }

        protected void ButtonTerminarPeriodoOK_Click(object sender, EventArgs e)
        {
            int periodoID = int.Parse(RadioButtonListPeriodos3.SelectedItem.Text);
            BD.periodosActivos[periodoID].activo = "False";
            Procedures.periodo_CambiarActivo(periodoID, "False");
            Inicio();
            Label1.Text = "Periodo Terminado Correctamente";
        }


        //Grupo
        protected void ButtonGrupos_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelGrupos.Visible = true;
        }

        protected void ButtonCrearGrupo_Click(object sender, EventArgs e)
        {
            PanelCrearGrupo.Visible = true;
            PanelModificarGrupo.Visible = false;
            PanelAnularGrupo.Visible = false;
            PanelTerminarGrupo.Visible = false;
            RadioButtonListPeriodos4.Items.Clear();
            if (BD.periodosActivos.Count != 0)
            {
                for (int i = 0; i < BD.periodosActivos.Count; i++)
                {
                    RadioButtonListPeriodos4.Items.Add(new ListItem(BD.periodosActivos[i].ID.ToString()));
                }
            }
            if (BD.estadosGrupo.Count != 0 )
            {
                for (int i = 0; i < BD.periodosActivos.Count; i++)
                {
                    RadioButtonListEstadoGrupo.Items.Add(new ListItem(BD.estadosGrupo[i].nombre));
                }
            }
        }

        protected void ButtonCrearGrupoOK_Click(object sender, EventArgs e)
        {
            int periodoID = int.Parse(RadioButtonListPeriodos4.SelectedItem.Text);
            int estadoID = RadioButtonListEstadoGrupo.SelectedIndex;
            string nombre = TextBoxNombreGrupo.Text;
            string codigoGrupo = TextBoxCodigoGrupo.Text;

            Grupo nuevo = new Grupo(estadoID, periodoID, ProfesorID, nombre, codigoGrupo);
            BD.periodosActivos[periodoID].grupos.Add(nuevo);
            Procedures.grupo_crear(estadoID, ProfesorID, periodoID, nombre, codigoGrupo);

            PanelCrearRubros.Visible = true;
            DropDownListTipoRubro.Items.Clear();
            for(int i=0; i<BD.rubros.Count;i++)
            {
                DropDownListTipoRubro.Items.Add(BD.rubros[i].nombre);
            }
        }

        protected void SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedItem.Text.Equals("Fijo"))
            {
                TextBoxCantidadRubro.Visible = true;
                LabelCantidad.Visible = true;
            }
            else
            {
                TextBoxCantidadRubro.Visible = false;
                LabelCantidad.Visible = false;
            }
        }

        protected void ButtonAgregarRubro_Click(object sender, EventArgs e)
        {

            int periodoID = int.Parse(RadioButtonListPeriodos4.SelectedItem.Text);
            int idGrupo = BD.periodosActivos[periodoID].grupos.Count;
            int idRubro = DropDownListTipoRubro.SelectedIndex;
            decimal valorPorcentual = decimal.Parse(TextBoxPorcentajeRubro.Text);
            if (RadioButtonList1.SelectedItem.Text.Equals("Fijo"))
            {
                int cantidad = int.Parse(TextBoxCantidadRubro.Text);
                BD.periodosActivos[periodoID].grupos.Last().grupoxRubros.Add(new GrupoxRubro(valorPorcentual, "True", cantidad, idGrupo, idRubro));
                PanelAregarRubro.Visible = true;
                Procedures.grupoxrubro_crear(idGrupo,idRubro, valorPorcentual, "True", cantidad);
            }
            else
            {
                BD.periodosActivos[periodoID].grupos.Last().grupoxRubros.Add(new GrupoxRubro( valorPorcentual, "False", 0,idGrupo,idRubro));
                Procedures.grupoxrubro_crear(idGrupo,idRubro, valorPorcentual, "False",0);
                TextBoxPorcentajeRubro.Text = "";
            }
        }

        protected void ButtonAgregarRubroOK_Click(object sender, EventArgs e)
        {
            int periodoID = int.Parse(RadioButtonListPeriodos4.SelectedItem.Text);
            GrupoxRubro grupoxRubro = BD.periodosActivos[periodoID].grupos.Last().grupoxRubros.Last();
            int idGrupoxRubro = grupoxRubro.ID;

            DateTime date = CalendarEvaluacion.SelectedDate;
            string nombre = TextBoxNombreRubro.Text;
            string descripción = TextBoxDescripcionRubro.Text;
            decimal valor = decimal.Parse(TextBoxValorRubro.Text);

            Procedures.evaluacion_crear(idGrupoxRubro, nombre, date, valor, descripción);
            grupoxRubro.evaluaciones.Add(new Evaluacion(idGrupoxRubro, nombre, date, valor, descripción));

            string instancia = "Nombre: " + TextBoxNombreRubro.Text + "Descripción: " + TextBoxDescripcionRubro.Text + "Valor: " + TextBoxValorRubro.Text + "\n";
            TextAreaInstancias.Value += instancia;
            TextBoxNombreRubro.Text = "";
            TextBoxDescripcionRubro.Text = "";
            TextBoxValorRubro.Text = "";
        }

        protected void ButtonInstanciasOK_Click(object sender, EventArgs e)
        {
            TextBoxNombreRubro.Text = "";
            TextBoxDescripcionRubro.Text = "";
            TextBoxValorRubro.Text = "";
            PanelAregarRubro.Visible = false;
            TextBoxPorcentajeRubro.Text = "";
            TextBoxCantidadRubro.Text = "";
        }

        protected void ButtonGrupoOK_Click(object sender, EventArgs e)
        {
            TextBoxNombreGrupo.Text = "";
            TextBoxCodigoGrupo.Text = "";
            Inicio();
            Label1.Text = "Grupo Creado Correctamente";
        }

        protected void ButtonModificarGrupo_Click(object sender, EventArgs e)
        {
            PanelModificarGrupo.Visible = true;
            PanelCrearGrupo.Visible = false;
            PanelAnularGrupo.Visible = false;
            PanelTerminarGrupo.Visible = false;
            RadioButtonListPeriodos5.Items.Clear();
            if (BD.periodosActivos.Count != 0)
            {
                for (int i = 0; i < BD.periodosActivos.Count; i++)
                {
                    RadioButtonListPeriodos5.Items.Add(new ListItem(BD.periodosActivos[i].ID.ToString()));
                }
            }
        }

        protected void SelectedIndexChangedPeriodo1(object sender, EventArgs e)
        {
            int indexPeriodo = int.Parse(RadioButtonListPeriodos5.SelectedItem.Text);
            Periodo periodo = BD.periodosActivos[indexPeriodo];
            RadioButtonListGrupos1.Items.Clear();
            if (periodo.grupos.Count != 0)
            {
                for (int i = 0; i < periodo.grupos.Count; i++)
                {
                    RadioButtonListGrupos1.Items.Add(new ListItem(periodo.grupos[i].nombreCurso));
                }
            }
        }

        protected void SelectedIndexChangedGrupo(object sender, EventArgs e)
        {
            //Poner los datos del grupo para ser cambiados
        }

        protected void ButtonModificarGrupoOK_Click(object sender, EventArgs e)
        {
            TextBoxNombreGrupoNew.Text = "";
            TextBoxCodigoGrupoNew.Text = "";
            Inicio();
            Label1.Text = "Grupo Modificado Correctamente";
        }

        protected void ButtonAnularGrupo_Click(object sender, EventArgs e)
        {
            PanelModificarGrupo.Visible = false;
            PanelCrearGrupo.Visible = false;
            PanelAnularGrupo.Visible = true;
            PanelTerminarGrupo.Visible = false;
            RadioButtonListPeriodos6.Items.Clear();
            if (BD.periodosActivos.Count != 0)
            {
                for (int i = 0; i < BD.periodosActivos.Count; i++)
                {
                    RadioButtonListPeriodos6.Items.Add(new ListItem(BD.periodosActivos[i].ID.ToString()));
                }
            }
        }

        protected void SelectedIndexChangedPeriodo2(object sender, EventArgs e)
        {
            int indexPeriodo = int.Parse(RadioButtonListPeriodos6.SelectedItem.Text);
            Periodo periodo = BD.periodosActivos[indexPeriodo];
            RadioButtonListGrupos2.Items.Clear();
            if (periodo.grupos.Count != 0)
            {
                for (int i = 0; i < periodo.grupos.Count; i++)
                {
                    RadioButtonListGrupos2.Items.Add(new ListItem(periodo.grupos[i].nombreCurso));
                }
            }
        }

        protected void ButtonAnularGrupoOK_Click(object sender, EventArgs e)
        {
            int periodo = int.Parse(RadioButtonListPeriodos6.SelectedItem.Text);
            int indexGrupo = RadioButtonListGrupos2.SelectedIndex;
            BD.periodosActivos[periodo - 1].grupos[indexGrupo - 1] = null;
            Procedures.grupo_borrar(BD.periodosActivos[periodo].grupos[indexGrupo].ID);
            Inicio();
            Label1.Text = "Grupo Anulado Correctamente";
        }

        protected void ButtonTerminarGrupo_Click(object sender, EventArgs e)
        {
            PanelModificarGrupo.Visible = false;
            PanelCrearGrupo.Visible = false;
            PanelAnularGrupo.Visible = false;
            PanelTerminarGrupo.Visible = true;
            RadioButtonListPeriodos7.Items.Clear();
            if (BD.periodosActivos.Count != 0)
            {
                for (int i = 0; i < BD.periodosActivos.Count; i++)
                {
                    RadioButtonListPeriodos7.Items.Add(new ListItem(BD.periodosActivos[i].ID.ToString()));
                }
            }
        }

        protected void SelectedIndexChangedPeriodo3(object sender, EventArgs e)
        {
            int indexPeriodo = int.Parse(RadioButtonListPeriodos7.SelectedItem.Text);
            Periodo periodo = BD.periodosActivos[indexPeriodo-1];
            RadioButtonListGrupos3.Items.Clear();
            if (periodo.grupos.Count != 0)
            {
                for (int i = 0; i < periodo.grupos.Count; i++)
                {
                    RadioButtonListGrupos3.Items.Add(new ListItem(periodo.grupos[i].nombreCurso));
                }
            }
        }

        protected void ButtonTerminarGrupoOK_Click(object sender, EventArgs e)
        {
            Inicio();
            Label1.Text = "Grupo Terminado Correctamente";
        }
        

        //Registrar Notas
        protected void ButtonRegistrarNotas_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelRegistrarNotas.Visible = true;
            RadioButtonListPeriodos8.Items.Clear();
            if (BD.periodosActivos.Count!=0)
            {
                for (int i = 0; i < BD.periodosActivos.Count; i++)
                {
                    RadioButtonListPeriodos8.Items.Add(new ListItem(BD.periodosActivos[i].ID.ToString()));
                }
                ButtonOKGrupo.Visible = true;
            }
            PanelRegistrarNotas.Visible = true;
        }

        protected void SelectedIndexChangedPeriodo4(object sender, EventArgs e)
        {
            int indexPeriodo = int.Parse(RadioButtonListPeriodos8.SelectedItem.Text);
            Periodo periodo = BD.periodosActivos[indexPeriodo];
            RadioButtonListGrupos4.Items.Clear();
            if (periodo.grupos.Count != 0)
            {
                for (int i = 0; i < periodo.grupos.Count; i++)
                {
                    RadioButtonListGrupos4.Items.Add(new ListItem(periodo.grupos[i].nombreCurso));
                }
            }
        }

        protected void ButtonOKGrupo_Click(object sender, EventArgs e)
        {
            int periodoID = int.Parse(RadioButtonListPeriodos8.SelectedItem.Text);
            int indexGrupo = RadioButtonListGrupos4.SelectedIndex;
            grupoActivo = BD.periodosActivos[periodoID].grupos[indexGrupo];
            Server.Transfer("RegistrarNotas.aspx");
        }
        
    }
}