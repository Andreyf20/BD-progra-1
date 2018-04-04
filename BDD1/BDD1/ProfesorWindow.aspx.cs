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
        //public static int GrupoID;
        public static int GrupoxRubroID;
        public static Grupo notas;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = "Bienvenido Profesor " + Procedures.nombreProfesor(ProfesorID);
        }
        
        //Inicio
        protected void ButtonInicio_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelInicio.Visible = true;
        }

        private void Inicio()
        {
            
            PanelCrearGrupo.Visible = false;
            PanelCrearPeriodo.Visible = false;
            PanelCrearRubros.Visible = false;
            PanelModificarGrupo.Visible = false;
            PanelPeriodo.Visible = false;
            PanelGrupos.Visible = false;
            PanelInicio.Visible = false;
            PanelRegistrarNotas.Visible = false;
            PanelAnularPeriodo.Visible = false;
            PanelAnularGrupo.Visible = false;
            PanelCrearGrupo.Visible = false;
            PanelAnularGrupo.Visible = false;
            PanelModificarGrupo.Visible = false;
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
            PanelAnularPeriodo.Visible = false;
        }

        protected void ButtonCrearPeriodoOK_Click(object sender, EventArgs e)
        {
            int activo = Procedures.periodo_crear(CalendarInicio.SelectedDate, CalendarFinal.SelectedDate);
            Inicio();
            Label1.Text = "Periodo Creado Correctamente";
        }
        
        protected void ButtonAnularPeriodo_Click(object sender, EventArgs e)
        {
            PanelCrearPeriodo.Visible = false;
            PanelAnularPeriodo.Visible = true;
            List<Periodo> periodos = Procedures.xmlPeriodos();
            RadioButtonListPeriodos2.Items.Clear();
            if (periodos.Count != 0)
            {
                for (int i = 0; i < periodos.Count; i++)
                {
                    RadioButtonListPeriodos2.Items.Add(new ListItem(periodos[i].ID.ToString()));
                }
            }
        }

        protected void ButtonAnularPeriodoOK_Click(object sender, EventArgs e)
        {
            int periodoID = int.Parse(RadioButtonListPeriodos2.SelectedItem.Text);
            Procedures.periodo_borrar(periodoID);
            Inicio();
            Label1.Text = "Periodo Anulado Correctamente";
        }

        protected void ButtonTerminarPeriodoOK_Click(object sender, EventArgs e)
        {
            int periodoID = int.Parse(RadioButtonListPeriodos2.SelectedItem.Text);
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
            RadioButtonListPeriodos4.Items.Clear();
            RadioButtonListEstadoGrupo.Items.Clear();
            List<Periodo> periodosActivos = Procedures.xmlPeriodos();
            List<EstadoGrupo> estados = Procedures.xmlEstadoGrupo();
            if (periodosActivos.Count != 0)
            {
                for (int i = 0; i < periodosActivos.Count; i++)
                {
                    RadioButtonListPeriodos4.Items.Add(new ListItem(periodosActivos[i].ID.ToString()));
                }
            }
            if (estados.Count != 0 )
            {
                for (int i = 0; i < periodosActivos.Count; i++)
                {
                    RadioButtonListEstadoGrupo.Items.Add(new ListItem(estados[i].nombre));
                }
            }
        }

        protected void ButtonCrearGrupoOK_Click(object sender, EventArgs e)
        {
            int periodoID = int.Parse(RadioButtonListPeriodos4.SelectedItem.Text);
            Console.WriteLine(periodoID);
            int estadoID = RadioButtonListEstadoGrupo.SelectedIndex;
            string nombre = TextBoxNombreGrupo.Text;
            string codigoGrupo = TextBoxCodigoGrupo.Text;
            
            int GrupoID = Procedures.grupo_crear(estadoID, periodoID, ProfesorID, nombre, codigoGrupo);

            TextBoxNombreGrupo.Text = "";
            TextBoxCodigoGrupo.Text = "";
            Inicio();
            Label1.Text = "Grupo Creado Correctamente";
        }

        protected void ButtonModificarGrupo_Click(object sender, EventArgs e)
        {
            PanelCrearGrupo.Visible = false;
            PanelAnularGrupo.Visible = false;
            PanelModificarGrupo.Visible = true;
            List<Periodo> periodos = Procedures.xmlPeriodos();
            RadioButtonListPeriodos5.Items.Clear();
            if (periodos.Count != 0)
            {
                for (int i = 0; i < periodos.Count; i++)
                {
                    RadioButtonListPeriodos5.Items.Add(new ListItem(periodos[i].ID.ToString()));
                }
            }
        }

        protected void SelectedIndexChangedPeriodo1(object sender, EventArgs e)
        {
            int indexPeriodo = int.Parse(RadioButtonListPeriodos5.SelectedItem.Text);
            RadioButtonListGrupos1.Items.Clear();
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(indexPeriodo, ProfesorID);
            if (grupos.Count != 0)
            {
                for (int i = 0; i < grupos.Count; i++)
                {
                    RadioButtonListGrupos1.Items.Add(new ListItem(grupos[i].nombreCurso));
                }
            }
        }

        protected void SelectedIndexChangedGrupo(object sender, EventArgs e)
        {
            ButtonModificarNormal.Visible = true;
            ButtonAgregarRubro.Visible = true;
            ButtonAgregarEvaluacion.Visible = true;
        }

        protected void ButtonModificarGrupoNormal_Click(object sender, EventArgs e)
        {
            PanelModificarNormal.Visible = true;
            PanelAgregarRubro.Visible = false;
            PanelAgregarEvaluaciones2.Visible = false;
            int periodoID = int.Parse(RadioButtonListPeriodos5.SelectedItem.Text);
            int indexGrupo = RadioButtonListGrupos1.SelectedIndex;
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(periodoID, ProfesorID);
            Grupo grupo = grupos[indexGrupo];
            TextBoxNombreGrupoNew.Text = Procedures.ver_grupo(grupo.ID)[0];
            TextBoxCodigoGrupoNew.Text = Procedures.ver_grupo(grupo.ID)[1];
        }

        protected void ButtonModificarGrupoOK_Click(object sender, EventArgs e)
        {
            int periodoID = int.Parse(RadioButtonListPeriodos5.SelectedItem.Text);
            int indexGrupo = RadioButtonListGrupos1.SelectedIndex;
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(periodoID, ProfesorID);
            Grupo grupo = grupos[indexGrupo];
            Procedures.actualizar_grupo_nombre_codigo(grupo.ID, TextBoxNombreGrupoNew.Text, TextBoxCodigoGrupoNew.Text);
            TextBoxNombreGrupoNew.Text = "";
            TextBoxCodigoGrupoNew.Text = "";
            Inicio();
            Label1.Text = "Grupo Modificado Correctamente";
        }

        protected void ButtonAgregarRubro_Click(object sender, EventArgs e)
        {
            PanelModificarNormal.Visible = false;
            PanelAgregarRubro.Visible = true;
            PanelCrearRubros.Visible = true;
            PanelAgregarEvaluaciones2.Visible = false;

            List<Rubro> rubros = Procedures.xmlRubros();

            DropDownListTipoRubro.Items.Clear();
            for (int i = 0; i < rubros.Count; i++)
            {
                DropDownListTipoRubro.Items.Add(rubros[i].nombre);
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

        protected void ButtonAgregarRubroOK_Click(object sender, EventArgs e)
        {
            int periodoID = int.Parse(RadioButtonListPeriodos5.SelectedItem.Text);
            int indexGrupo = RadioButtonListGrupos1.SelectedIndex;
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(periodoID, ProfesorID);
            Grupo grupo = grupos[indexGrupo];
            int idRubro = DropDownListTipoRubro.SelectedIndex;
            decimal valorPorcentual = decimal.Parse(TextBoxPorcentajeRubro.Text);
            if (RadioButtonList1.SelectedItem.Text.Equals("Fijo"))
            {
                int cantidad = int.Parse(TextBoxCantidadRubro.Text);

                PanelAgregarEvaluaciones1.Visible = true;
                GrupoxRubroID = Procedures.grupoxrubro_crear(grupo.ID, idRubro, valorPorcentual, "True", cantidad);
            }
            else
            {
                GrupoxRubroID = Procedures.grupoxrubro_crear(grupo.ID, idRubro, valorPorcentual, "False", 0);
                TextBoxPorcentajeRubro.Text = "";
            }
        }

        protected void ButtonGrupoOK_Click(object sender, EventArgs e)
        {
            Inicio();
        }

        protected void ButtonAgregarEvaluacionOK_Click(object sender, EventArgs e)
        {
            int periodoID = int.Parse(RadioButtonListPeriodos5.SelectedItem.Text);
            DateTime date = CalendarEvaluacion.SelectedDate;
            string nombre = TextBoxNombreRubro.Text;
            string descripción = TextBoxDescripcionRubro.Text;
            decimal valor = decimal.Parse(TextBoxValorRubro.Text);
            Procedures.evaluacion_crear(GrupoxRubroID, nombre, date, valor, descripción);
            string instancia = "Nombre: " + TextBoxNombreRubro.Text + "Descripción: " + TextBoxDescripcionRubro.Text + "Valor: " + TextBoxValorRubro.Text + "\n";
            TextAreaInstancias.Value += instancia;
            TextBoxNombreRubro.Text = "";
            TextBoxDescripcionRubro.Text = "";
            TextBoxValorRubro.Text = "";
        }

        protected void ButtonAgregarEvaluacion_Click(object sender, EventArgs e)
        {
            PanelModificarNormal.Visible = false;
            PanelAgregarRubro.Visible = false;
            PanelAgregarEvaluaciones2.Visible = true;
            int periodoID = int.Parse(RadioButtonListPeriodos5.SelectedItem.Text);
            int indexGrupo = RadioButtonListGrupos1.SelectedIndex;
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(periodoID, ProfesorID);
            Grupo grupo = grupos[indexGrupo];
            List<GrupoxRubro> periodos = Procedures.ver_grupoxrubro_grupo_nofijos(grupo.ID);
            List<Rubro> rubros = Procedures.xmlRubros();
            if (periodos.Count != 0)
            {
                for (int i = 0; i < periodos.Count; i++)
                {
                    RadioButtonList2.Items.Add(new ListItem(rubros[periodos[i].idRubro].nombre));
                }
            }

        }

        protected void ButtonAgregarEvaluacionVariable_Click(object sender, EventArgs e)
        {
            List<Rubro> rubros = Procedures.xmlRubros();
            int idRubro = RadioButtonList2.SelectedIndex;
            int periodoID = int.Parse(RadioButtonListPeriodos5.SelectedItem.Text);
            DateTime date = CalendarEvaluacion.SelectedDate;
            string nombre = TextBox1.Text;
            string descripción = TextBox2.Text;
            decimal valor = decimal.Parse(TextBox3.Text);
            Procedures.evaluacion_crear(idRubro, nombre, date, valor, descripción);
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }

        protected void ButtonInstanciasOK_Click(object sender, EventArgs e)
        {
            TextBoxNombreRubro.Text = "";
            TextBoxDescripcionRubro.Text = "";
            TextBoxValorRubro.Text = "";
            PanelAgregarEvaluaciones1.Visible = false;
            TextBoxPorcentajeRubro.Text = "";
            TextBoxCantidadRubro.Text = "";
        }

        protected void ButtonAnularGrupo_Click(object sender, EventArgs e)
        {
            PanelModificarGrupo.Visible = false;
            PanelCrearGrupo.Visible = false;
            PanelAnularGrupo.Visible = true;
            RadioButtonListPeriodos6.Items.Clear();
            List<Periodo> periodos = Procedures.xmlPeriodos();
            if (periodos.Count != 0)
            {
                for (int i = 0; i < periodos.Count; i++)
                {
                    RadioButtonListPeriodos6.Items.Add(new ListItem(periodos[i].ID.ToString()));
                }
            }
        }

        protected void SelectedIndexChangedPeriodo2(object sender, EventArgs e)
        {
            int indexPeriodo = int.Parse(RadioButtonListPeriodos6.SelectedItem.Text);
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(indexPeriodo, ProfesorID);
            RadioButtonListGrupos2.Items.Clear();
            if (grupos.Count != 0)
            {
                for (int i = 0; i < grupos.Count; i++)
                {
                    RadioButtonListGrupos2.Items.Add(new ListItem(grupos[i].nombreCurso));
                }
            }
        }

        protected void ButtonAnularGrupoOK_Click(object sender, EventArgs e)
        {
            int periodo = int.Parse(RadioButtonListPeriodos6.SelectedItem.Text);
            int indexGrupo = RadioButtonListGrupos2.SelectedIndex;
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(periodo, ProfesorID);
            Procedures.grupo_borrar(grupos[indexGrupo].ID);
            Inicio();
            Label1.Text = "Grupo Anulado Correctamente";
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
            List<Periodo> periodos = Procedures.xmlPeriodos();
            if (periodos.Count != 0)
            {
                for (int i = 0; i < periodos.Count; i++)
                {
                    RadioButtonListPeriodos8.Items.Add(new ListItem(periodos[i].ID.ToString()));
                }
                ButtonOKGrupo.Visible = true;
            }
            PanelRegistrarNotas.Visible = true;
        }

        protected void SelectedIndexChangedPeriodo4(object sender, EventArgs e)
        {
            int indexPeriodo = int.Parse(RadioButtonListPeriodos8.SelectedItem.Text);
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(indexPeriodo, ProfesorID);
            RadioButtonListGrupos4.Items.Clear();
            if (grupos.Count != 0)
            {
                for (int i = 0; i < grupos.Count; i++)
                {
                    RadioButtonListGrupos4.Items.Add(new ListItem(grupos[i].nombreCurso));
                }
            }
        }

        protected void ButtonOKGrupo_Click(object sender, EventArgs e)
        {
            int periodoID = int.Parse(RadioButtonListPeriodos8.SelectedItem.Text);
            int indexGrupo = RadioButtonListGrupos4.SelectedIndex;
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(periodoID, ProfesorID);
            
            notas = grupos[indexGrupo];
            Server.Transfer("RegistrarNotas.aspx");
        }
        
    }
}