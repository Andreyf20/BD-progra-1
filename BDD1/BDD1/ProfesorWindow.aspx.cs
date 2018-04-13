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
        public static int PeriodoID;
        public static int GrupoID;
        public static int GrupoxRubroID;
        public static int EvaluacionID;
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

            PanelGrupo.Visible = false;
            PanelGrupoxRubro.Visible = false;
            ButtonCrearGrupoxRubro.Visible = false;
            ButtonModificarGrupoxRubro.Visible = false;
            ButtonAnularGrupoxRubro.Visible = false;

            PanelEvaluacion.Visible = false;
            PanelAgregarEvaluaciones2.Visible = false;
            PanelModificarEvaluacion.Visible = false;
            PanelAnularEvaluacion.Visible = false;

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
            PeriodoID = int.Parse(RadioButtonListPeriodos2.SelectedItem.Text);
            Procedures.periodo_borrar(PeriodoID);
            Inicio();
            Label1.Text = "Periodo Anulado Correctamente";
        }

        protected void ButtonTerminarPeriodoOK_Click(object sender, EventArgs e)
        {
            PeriodoID = int.Parse(RadioButtonListPeriodos2.SelectedItem.Text);
            Procedures.periodo_CambiarActivo(PeriodoID, "False");
            Inicio();
            Label1.Text = "Periodo Terminado Correctamente";
        }


        //Grupo
        protected void ButtonGrupos_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelGrupos.Visible = true;
        }
        protected void ButtonGrupo_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelGrupos.Visible = true;
            PanelGrupo.Visible = true;
            PanelGrupoxRubro.Visible = false;
            PanelEvaluacion.Visible = false;
        }

        protected void ButtonGrupoxRubro_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelGrupos.Visible = true;
            PanelGrupo.Visible = false;
            PanelGrupoxRubro.Visible = true;
            PanelEvaluacion.Visible = false;

            List<Periodo> periodos = Procedures.xmlPeriodos();
            RadioButtonList3.Items.Clear();
            if (periodos.Count != 0)
            {
                for (int i = 0; i < periodos.Count; i++)
                {
                    RadioButtonList3.Items.Add(new ListItem(periodos[i].ID.ToString()));
                }
            }
        }
        protected void ButtonCrearGrupoxRubro_Click(object sender, EventArgs e)
        {
            PanelAgregarRubro.Visible = true;
            PanelCrearRubros.Visible = true;
            PanelAnularRubro.Visible = false;
            List<Rubro> rubros = Procedures.xmlRubros();

            DropDownListTipoRubro.Items.Clear();
            for (int i = 0; i < rubros.Count; i++)
            {
                DropDownListTipoRubro.Items.Add(rubros[i].nombre);
            }
        }

        protected void SelectedIndexChangedPeriodo3(object sender, EventArgs e)
        {
            PeriodoID = int.Parse(RadioButtonList3.SelectedItem.Text);
            RadioButtonList4.Items.Clear();
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(PeriodoID, ProfesorID);
            if (grupos.Count != 0)
            {
                for (int i = 0; i < grupos.Count; i++)
                {
                    RadioButtonList4.Items.Add(new ListItem(grupos[i].nombreCurso));
                }
            }
        }
        protected void SelectedIndexChangedGrupo2(object sender, EventArgs e)
        {
            ButtonModificarNormal.Visible = true;
            ButtonAgregarEstudiantes.Visible = true;
        }
        protected void ButtonAgregarRubroOK_Click(object sender, EventArgs e)
        {

            PeriodoID = int.Parse(RadioButtonList3.SelectedItem.Text);
            int indexGrupo = RadioButtonList4.SelectedIndex;
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(PeriodoID, ProfesorID);
            GrupoID = grupos[indexGrupo].ID;
            int idRubro = DropDownListTipoRubro.SelectedIndex;
            decimal valorPorcentual = decimal.Parse(TextBoxPorcentajeRubro.Text);
            if (RadioButtonList1.SelectedItem.Text.Equals("Fijo"))
            {
                int cantidad = int.Parse(TextBoxCantidadRubro.Text);

                PanelAgregarEvaluaciones1.Visible = true;
                GrupoxRubroID = Procedures.grupoxrubro_crear(GrupoID, idRubro, valorPorcentual, "True", cantidad);
            }
            else
            {
                GrupoxRubroID = Procedures.grupoxrubro_crear(GrupoID, idRubro, valorPorcentual, "False", 0);
                TextBoxPorcentajeRubro.Text = "";
            }
        }
        protected void ButtonEvaluacion_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelGrupos.Visible = true;
            PanelGrupo.Visible = false;
            PanelGrupoxRubro.Visible = false;
            PanelEvaluacion.Visible = true;

            List<Periodo> periodos = Procedures.xmlPeriodos();
            RadioButtonList5.Items.Clear();
            if (periodos.Count != 0)
            {
                for (int i = 0; i < periodos.Count; i++)
                {
                    RadioButtonList5.Items.Add(new ListItem(periodos[i].ID.ToString()));
                }
            }
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
            PeriodoID = int.Parse(RadioButtonListPeriodos4.SelectedItem.Text);
            int estadoID = RadioButtonListEstadoGrupo.SelectedIndex;
            string nombre = TextBoxNombreGrupo.Text;
            string codigoGrupo = TextBoxCodigoGrupo.Text;
            
            GrupoID = Procedures.grupo_crear(estadoID, PeriodoID, ProfesorID, nombre, codigoGrupo);

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
            PeriodoID = int.Parse(RadioButtonListPeriodos5.SelectedItem.Text);
            RadioButtonListGrupos1.Items.Clear();
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(PeriodoID, ProfesorID);
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
            ButtonCrearGrupoxRubro.Visible = true;
            ButtonModificarGrupoxRubro.Visible = true;
            ButtonAnularGrupoxRubro.Visible = true;
            PeriodoID = int.Parse(RadioButtonList3.SelectedItem.Text);
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(PeriodoID, ProfesorID);
            GrupoID = grupos[RadioButtonList4.SelectedIndex].ID;
        }

        protected void ButtonModificarGrupoNormal_Click(object sender, EventArgs e)
        {
            PanelModificarNormal.Visible = true;
            PanelAgregarRubro.Visible = false;
            PanelAgregarEvaluaciones2.Visible = false;
            PanelAgregarEstudiantes.Visible = false;
            PeriodoID = int.Parse(RadioButtonListPeriodos5.SelectedItem.Text);
            int indexGrupo = RadioButtonListGrupos1.SelectedIndex;
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(PeriodoID, ProfesorID);
            GrupoID = grupos[indexGrupo].ID;
            TextBoxNombreGrupoNew.Text = Procedures.ver_grupo(GrupoID)[0];
            TextBoxCodigoGrupoNew.Text = Procedures.ver_grupo(GrupoID)[1];
        }

        protected void ButtonModificarGrupoOK_Click(object sender, EventArgs e)
        {
            PeriodoID = int.Parse(RadioButtonListPeriodos5.SelectedItem.Text);
            int indexGrupo = RadioButtonListGrupos1.SelectedIndex;
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(PeriodoID, ProfesorID);
            GrupoID= grupos[indexGrupo].ID;
            Procedures.actualizar_grupo_nombre_codigo(GrupoID, TextBoxNombreGrupoNew.Text, TextBoxCodigoGrupoNew.Text);
            TextBoxNombreGrupoNew.Text = "";
            TextBoxCodigoGrupoNew.Text = "";
            Inicio();
            Label1.Text = "Grupo Modificado Correctamente";
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

        

        protected void ButtonGrupoOK_Click(object sender, EventArgs e)
        {
            Inicio();
        }

        protected void ButtonAgregarEvaluacionOK_Click(object sender, EventArgs e)
        {
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

      

        protected void ButtonAgregarEvaluacionVariable_Click(object sender, EventArgs e)
        {
            List<GrupoxRubro> grupoxRubros = Procedures.ver_grupoxrubro_grupo_nofijos(GrupoID);
            int grupoxRubroIndex = RadioButtonList2.SelectedIndex;
            GrupoxRubroID = grupoxRubros[grupoxRubroIndex].ID;
            DateTime date = CalendarEvaluacion.SelectedDate;
            string nombre = TextBox1.Text;
            string descripción = TextBox2.Text;
            Procedures.evaluacion_crear(GrupoxRubroID, nombre, date, 0, descripción);
            TextBox1.Text = "";
            TextBox2.Text = "";
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

        protected void ButtonAgregarEstudiantes_Click(object sender, EventArgs e)
        {
            PanelModificarNormal.Visible = false;
            PanelAgregarRubro.Visible = false;
            PanelAgregarEvaluaciones2.Visible = false;
            PanelAgregarEstudiantes.Visible = true;
            CheckBoxList1.Items.Clear();
            List<Estudiante> estudiantes = Procedures.verEstudiantes();
            if (estudiantes.Count != 0)
            {
                for (int i = 0; i < estudiantes.Count; i++)
                {
                    CheckBoxList1.Items.Add(new ListItem(estudiantes[i].nombre+"("+estudiantes[i].carnet+")",estudiantes[i].ID.ToString()));
                }
            }

        }

        protected void ButtonAgregarEstudiantesOK_Click(object sender, EventArgs e)
        {
            PeriodoID = int.Parse(RadioButtonListPeriodos6.SelectedItem.Text);
            int indexGrupo = RadioButtonListGrupos2.SelectedIndex;
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(PeriodoID, ProfesorID);
            GrupoID = grupos[indexGrupo].ID;
            foreach (ListItem item in CheckBoxList1.Items)
                if (item.Selected)
                {
                    Procedures.grupoxestudiante_crear(GrupoID, 1, int.Parse(item.Value), 0);
                }
                        
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
            PeriodoID = int.Parse(RadioButtonListPeriodos6.SelectedItem.Text);
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(PeriodoID, ProfesorID);
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
            PeriodoID = int.Parse(RadioButtonListPeriodos6.SelectedItem.Text);
            int indexGrupo = RadioButtonListGrupos2.SelectedIndex;
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(PeriodoID, ProfesorID);
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
            PeriodoID = int.Parse(RadioButtonListPeriodos8.SelectedItem.Text);
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(PeriodoID, ProfesorID);
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
            PeriodoID = int.Parse(RadioButtonListPeriodos8.SelectedItem.Text);
            int indexGrupo = RadioButtonListGrupos4.SelectedIndex;
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(PeriodoID, ProfesorID);
            
            notas = grupos[indexGrupo];
            Server.Transfer("RegistrarNotas.aspx");
        }

        protected void ButtonModificarGrupoxRubro_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonAnularGrupoxRubro_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelAgregarRubro.Visible = false;
            PanelCrearRubros.Visible = false;
            PanelAnularRubro.Visible = true;
            List<GrupoxRubro> grupoxRubros = Procedures.ver_grupoxrubro_grupo(GrupoID);
            List<Rubro> rubros = Procedures.xmlRubros();
            RadioButtonListGrupoxRubro.Items.Clear();
            if (grupoxRubros.Count != 0)
            {
                for (int i = 0; i < grupoxRubros.Count; i++)
                {
                    RadioButtonListGrupoxRubro.Items.Add(new ListItem(rubros[grupoxRubros[i].idRubro].nombre));
                }
            }
            
            
        }

        protected void ButtonAnularGrpoxRubroOK_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonCrearEvaluaciones_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelEvaluacion.Visible = true;
            PanelAgregarEvaluaciones2.Visible = true;
            PanelModificarEvaluacion.Visible = false;
            PanelAnularEvaluacion.Visible = false;

            PeriodoID = int.Parse(RadioButtonList5.SelectedItem.Text);
            int indexGrupo = RadioButtonList6.SelectedIndex;
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(PeriodoID, ProfesorID);
            GrupoID = grupos[indexGrupo].ID;
            List<GrupoxRubro> periodos = Procedures.ver_grupoxrubro_grupo_nofijos(GrupoID);
            List<Rubro> rubros = Procedures.xmlRubros();
            if (periodos.Count != 0)
            {
                for (int i = 0; i < periodos.Count; i++)
                {
                    RadioButtonList2.Items.Add(new ListItem(rubros[periodos[i].idRubro].nombre));
                }
            }
        }

        protected void ButtonModificarEvaluaciones_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelEvaluacion.Visible = true;
            PanelAgregarEvaluaciones2.Visible = false;
            PanelModificarEvaluacion.Visible = true;
            PanelAnularEvaluacion.Visible = false;

        }

        protected void ButtonAnularEvaluaciones_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelEvaluacion.Visible = true;
            PanelAgregarEvaluaciones2.Visible = false;
            PanelModificarEvaluacion.Visible = false;
            PanelAnularEvaluacion.Visible = true;

        }

        protected void SelectedIndexChangedPeriodo5(object sender, EventArgs e)
        {
            PeriodoID = int.Parse(RadioButtonList5.SelectedItem.Text);
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(PeriodoID, ProfesorID);
            RadioButtonList6.Items.Clear();
            if (grupos.Count != 0)
            {
                for (int i = 0; i < grupos.Count; i++)
                {
                    RadioButtonList6.Items.Add(new ListItem(grupos[i].nombreCurso));
                }
            }
        }

        protected void SelectedIndexChangedGrupo1(object sender, EventArgs e)
        {
            ButtonCrearEvaluaciones.Visible = true;
            ButtonModificarEvaluaciones.Visible = true;
            ButtonAnularEvaluaciones.Visible = true;
            PeriodoID = int.Parse(RadioButtonList5.SelectedItem.Text);
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(PeriodoID, ProfesorID);
            GrupoID = grupos[RadioButtonList6.SelectedIndex].ID;
        }

        protected void ButtonCrearEstudianteOK_Click(object sender, EventArgs e)
        {
            PanelCrearEstudiante.Visible = true;
            PanelModificarEstudiante.Visible = false;
            
            string Nombre = TextBoxNombre.Text;
            string Apellido = TextBoxApellido.Text;
            string Telefono = TextBoxTelefono.Text;
            string Carnet = TextBoxCarnet.Text;
            string Correo = TextBoxCorreo.Text;
            string Contraseña = TextBoxContraseña.Text;

            Procedures.estudiante_crear(Nombre, Apellido, Carnet, Correo, Contraseña);

            TextBoxNombre.Text = "";
            TextBoxApellido.Text = "";
            TextBoxTelefono.Text = "";
            TextBoxCorreo.Text = "";
            TextBoxContraseña.Text = "";
            TextBoxCarnet.Text = "";

            Inicio();
        }

        protected void ButtonModificarEstudiante_Click(object sender, EventArgs e)
        {
            PanelCrearEstudiante.Visible = false;
            PanelModificarEstudiante.Visible = true;

            RadioButtonListEstudiantes1.Items.Clear();
            List<Estudiante> estudiantes = Procedures.verEstudiantes();
            if (estudiantes.Count != 0)
            {
                for (int i = 0; i < estudiantes.Count; i++)
                {
                    RadioButtonListEstudiantes1.Items.Add(new ListItem(estudiantes[i].nombre + "(" + estudiantes[i].carnet + ")", estudiantes[i].ID.ToString()));
                }
            }
        }

        protected void RadioButtonListEstudiantes1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Estudiante> estudiantes = Procedures.verEstudiantes();
            int index = RadioButtonListEstudiantes1.SelectedIndex;
            Estudiante estudiante = estudiantes[index];
            TextBoxNombreNew.Text = estudiante.nombre;
            TextBoxApellidoNew.Text = estudiante.apellido;
            TextBoxTelefonoNew.Text = estudiante.telefono;
            TextBoxCarnetNew.Text = estudiante.carnet;
            TextBoxCorreoNew.Text = estudiante.correo;
            TextBoxContraseñaNew.Text = estudiante.contraseña;
        }

        protected void ButtonEstudiantes_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelEstudiante.Visible = true;
        }

        protected void ButtonCrearEstudiante_Click(object sender, EventArgs e)
        {
            PanelCrearEstudiante.Visible = true;
        }

        protected void ButtonAnularEstudiante_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonModificarEstudianteOK_Click(object sender, EventArgs e)
        {

        }
    }
}