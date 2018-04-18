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
        public static int EstudianteID;
        public static Grupo notas;

        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Bienvenido Profesor " + Procedures.nombreProfesor(ProfesorID);
        }
        
        //Inicio
        protected void ButtonInicio_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelInicio.Visible = true;
        }

        private void Inicio()
        {
            PanelInicio.Visible = false;
            
            PanelPeriodo.Visible = false;
                PanelCrearPeriodo.Visible = false;
                PanelAnularPeriodo.Visible = false;

            PanelGrupos.Visible = false;
                PanelGrupo.Visible = false;
                    PanelCrearGrupo.Visible = false;
                    PanelModificarGrupo.Visible = false;
                        PanelModificarNormal.Visible = false;
                        PanelAgregarEstudiantes.Visible = false;
                    PanelAnularGrupo.Visible = false;
                PanelGrupoxRubro.Visible = false;
                    PanelAgregarRubro.Visible = false;
                        PanelCrearRubros.Visible = false;
                        PanelAgregarEvaluaciones1.Visible = false;
                    PanelAnularRubro.Visible = false;
                PanelEvaluacion.Visible = false;
                    PanelAgregarEvaluaciones2.Visible = false;
                    PanelAnularEvaluacion.Visible = false;

            PanelEstudiante.Visible = false;
                PanelCrearEstudiante.Visible = false;
                PanelModificarEstudiante.Visible = false;
                PanelAnularEstudiante.Visible = false;

            PanelRegistrarNotas.Visible = false;

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
            Inicio();
            PanelPeriodo.Visible = true;
            PanelCrearPeriodo.Visible = true;
        }

        protected void ButtonCrearPeriodoOK_Click(object sender, EventArgs e)
        {
            int activo = Procedures.periodo_crear(CalendarInicio.SelectedDate, CalendarFinal.SelectedDate);
            Inicio();
        }
        
        protected void ButtonAnularPeriodo_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelPeriodo.Visible = true;
            PanelAnularPeriodo.Visible = true;
            List<Periodo> periodos = Procedures.xmlPeriodos();
            RadioButtonListPeriodos1.Items.Clear();
            if (periodos.Count != 0)
            {
                for (int i = 0; i < periodos.Count; i++)
                {
                    RadioButtonListPeriodos1.Items.Add(new ListItem(periodos[i].ID.ToString()));
                }
            }
        }

        protected void ButtonAnularPeriodoOK_Click(object sender, EventArgs e)
        {
            PeriodoID = int.Parse(RadioButtonListPeriodos1.SelectedItem.Text);
            int result = Procedures.periodo_borrar(PeriodoID);
            if (result == -1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"No se puede anular\");", true);
            }
            Inicio();
        }

        protected void ButtonTerminarPeriodoOK_Click(object sender, EventArgs e)
        {
            PeriodoID = int.Parse(RadioButtonListPeriodos1.SelectedItem.Text);
            Procedures.periodo_CambiarActivo(PeriodoID, "False");
            Inicio();
        }


        //Grupos
        protected void ButtonGrupos_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelGrupos.Visible = true;
        }


        //Grupo
        protected void ButtonGrupo_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelGrupos.Visible = true;
            PanelGrupo.Visible = true;
        }

        protected void ButtonCrearGrupo_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelGrupos.Visible = true;
            PanelGrupo.Visible = true;
            PanelCrearGrupo.Visible = true;

            RadioButtonListPeriodos2.Items.Clear();
            RadioButtonListEstadoGrupo.Items.Clear();
            List<Periodo> periodosActivos = Procedures.xmlPeriodos();
            List<EstadoGrupo> estados = Procedures.xmlEstadoGrupo();
            if (periodosActivos.Count != 0)
            {
                for (int i = 0; i < periodosActivos.Count; i++)
                {
                    RadioButtonListPeriodos2.Items.Add(new ListItem(periodosActivos[i].ID.ToString()));
                }
            }
            if (estados.Count != 0)
            {
                for (int i = 0; i < periodosActivos.Count; i++)
                {
                    RadioButtonListEstadoGrupo.Items.Add(new ListItem(estados[i].nombre));
                }
            }
        }

        protected void ButtonCrearGrupoOK_Click(object sender, EventArgs e)
        {
            PeriodoID = int.Parse(RadioButtonListPeriodos2.SelectedItem.Text);
            int estadoID = RadioButtonListEstadoGrupo.SelectedIndex;
            string nombre = TextBoxNombreGrupo.Text;
            string codigoGrupo = TextBoxCodigoGrupo.Text;

            GrupoID = Procedures.grupo_crear(estadoID, PeriodoID, ProfesorID, nombre, codigoGrupo);

            TextBoxNombreGrupo.Text = "";
            TextBoxCodigoGrupo.Text = "";
            Inicio();
        }

        protected void ButtonModificarGrupo_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelGrupos.Visible = true;
            PanelGrupo.Visible = true;
            PanelModificarGrupo.Visible = true;
            List<Periodo> periodos = Procedures.xmlPeriodos();
            RadioButtonListPeriodos3.Items.Clear();
            if (periodos.Count != 0)
            {
                for (int i = 0; i < periodos.Count; i++)
                {
                    RadioButtonListPeriodos3.Items.Add(new ListItem(periodos[i].ID.ToString()));
                }
            }
        }

        protected void SelectedIndexChangedPeriodo3(object sender, EventArgs e)
        {
            PeriodoID = int.Parse(RadioButtonListPeriodos3.SelectedItem.Text);
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

        protected void SelectedIndexChangedGrupo1(object sender, EventArgs e)
        {
            ButtonModificarNormal.Visible = true;
            ButtonAgregarEstudiantes.Visible = true;
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(PeriodoID, ProfesorID);
            GrupoID = grupos[RadioButtonListGrupos1.SelectedIndex].ID;
        }

        protected void ButtonModificarGrupoNormal_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelGrupos.Visible = true;
            PanelGrupo.Visible = true;
            PanelModificarGrupo.Visible = true;
            PanelModificarNormal.Visible = true;

            TextBoxNombreGrupoNew.Text = Procedures.ver_grupo(GrupoID)[0];
            TextBoxCodigoGrupoNew.Text = Procedures.ver_grupo(GrupoID)[1];
        }

        protected void ButtonModificarGrupoOK_Click(object sender, EventArgs e)
        {
            Procedures.actualizar_grupo_nombre_codigo(GrupoID, TextBoxNombreGrupoNew.Text, TextBoxCodigoGrupoNew.Text);
            TextBoxNombreGrupoNew.Text = "";
            TextBoxCodigoGrupoNew.Text = "";
            Inicio();
        }

        protected void ButtonAgregarEstudiantes_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelGrupos.Visible = true;
            PanelGrupo.Visible = true;
            PanelModificarGrupo.Visible = true;
            PanelAgregarEstudiantes.Visible = true;

            CheckBoxList1.Items.Clear();
            List<Estudiante> estudiantes = Procedures.verEstudiantes();
            if (estudiantes.Count != 0)
            {
                for (int i = 0; i < estudiantes.Count; i++)
                {
                    CheckBoxList1.Items.Add(new ListItem(estudiantes[i].nombre + "(" + estudiantes[i].carnet + ")", estudiantes[i].ID.ToString()));
                }
            }

        }

        protected void ButtonAgregarEstudiantesOK_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in CheckBoxList1.Items)
                if (item.Selected)
                {
                    Procedures.grupoxestudiante_crear(GrupoID, 1, int.Parse(item.Value), 0);
                }
            Inicio();
        }

        protected void ButtonAnularGrupo_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelGrupos.Visible = true;
            PanelGrupo.Visible = true;
            PanelAnularGrupo.Visible = true;

            RadioButtonListPeriodos4.Items.Clear();
            List<Periodo> periodos = Procedures.xmlPeriodos();
            if (periodos.Count != 0)
            {
                for (int i = 0; i < periodos.Count; i++)
                {
                    RadioButtonListPeriodos4.Items.Add(new ListItem(periodos[i].ID.ToString()));
                }
            }
        }

        protected void SelectedIndexChangedPeriodo4(object sender, EventArgs e)
        {
            PeriodoID = int.Parse(RadioButtonListPeriodos4.SelectedItem.Text);
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
            int indexGrupo = RadioButtonListGrupos2.SelectedIndex;
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(PeriodoID, ProfesorID);
            int result = Procedures.grupo_borrar(grupos[indexGrupo].ID);
            if (result == -1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"No se puede anular\");", true);
            }
            Inicio();
        }


        //Grupo x Rubro
        protected void ButtonGrupoxRubro_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelGrupos.Visible = true;
            PanelGrupoxRubro.Visible = true;

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

        protected void SelectedIndexChangedPeriodo5(object sender, EventArgs e)
        {
            PeriodoID = int.Parse(RadioButtonListPeriodos5.SelectedItem.Text);
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(PeriodoID, ProfesorID);
            RadioButtonListGrupos3.Items.Clear();
            if (grupos.Count != 0)
            {
                for (int i = 0; i < grupos.Count; i++)
                {
                    RadioButtonListGrupos3.Items.Add(new ListItem(grupos[i].nombreCurso));
                }
            }
        }

        protected void SelectedIndexChangedGrupo3(object sender, EventArgs e)
        {
            ButtonCrearGrupoxRubro.Visible = true;
            ButtonAnularGrupoxRubro.Visible = true;
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(PeriodoID, ProfesorID);
            GrupoID = grupos[RadioButtonListGrupos3.SelectedIndex].ID;
        }

        protected void ButtonCrearGrupoxRubro_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelGrupos.Visible = true;
            PanelGrupoxRubro.Visible = true;
            PanelAgregarRubro.Visible = true;
            PanelCrearRubros.Visible = true;
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

        protected void ButtonInstanciasOK_Click(object sender, EventArgs e)
        {
            TextBoxNombreRubro.Text = "";
            TextBoxDescripcionRubro.Text = "";
            TextBoxValorRubro.Text = "";
            PanelAgregarEvaluaciones1.Visible = false;
            TextBoxPorcentajeRubro.Text = "";
            TextBoxCantidadRubro.Text = "";
        }

        protected void ButtonGrupoOK_Click(object sender, EventArgs e)
        {
            Inicio();
        }

        protected void ButtonAnularGrupoxRubro_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelGrupos.Visible = true;
            PanelGrupoxRubro.Visible = true;
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
            List<GrupoxRubro> grupoxRubros = Procedures.ver_grupoxrubro_grupo(GrupoID);
            int index = RadioButtonListGrupoxRubro.SelectedIndex;
            int result = Procedures.grupoxrubro_borrar(grupoxRubros[index].ID);
            if (result == -1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"No se puede anular\");", true);
            }
            Inicio();
        }


        //Evaluacion
        protected void ButtonEvaluacion_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelGrupos.Visible = true;
            PanelEvaluacion.Visible = true;

            List<Periodo> periodos = Procedures.xmlPeriodos();
            RadioButtonListPeriodos6.Items.Clear();
            if (periodos.Count != 0)
            {
                for (int i = 0; i < periodos.Count; i++)
                {
                    RadioButtonListPeriodos6.Items.Add(new ListItem(periodos[i].ID.ToString()));
                }
            }
        }

        protected void SelectedIndexChangedPeriodo6(object sender, EventArgs e)
        {
            PeriodoID = int.Parse(RadioButtonListPeriodos6.SelectedItem.Text);
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

        protected void SelectedIndexChangedGrupo4(object sender, EventArgs e)
        {
            ButtonCrearEvaluaciones.Visible = true;
            ButtonAnularEvaluaciones.Visible = true;
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(PeriodoID, ProfesorID);
            GrupoID = grupos[RadioButtonListGrupos4.SelectedIndex].ID;
        }

        protected void ButtonCrearEvaluaciones_Click(object sender, EventArgs e)
        {
            PanelGrupos.Visible = true;
            PanelEvaluacion.Visible = true;
            PanelAgregarEvaluaciones2.Visible = true;
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

        protected void ButtonAgregarEvaluacionVariable_Click(object sender, EventArgs e)
        {
            List<GrupoxRubro> grupoxRubros = Procedures.ver_grupoxrubro_grupo_nofijos(GrupoID);
            int grupoxRubroIndex = RadioButtonList2.SelectedIndex;
            GrupoxRubroID = grupoxRubros[grupoxRubroIndex].ID;
            DateTime date = Calendar1.SelectedDate;
            string nombre = TextBox1.Text;
            string descripción = TextBox2.Text;
            Procedures.evaluacion_crear(GrupoxRubroID, nombre, date, 0, descripción);
            TextBox1.Text = "";
            TextBox2.Text = "";
            Inicio();
        }

        protected void ButtonAnularEvaluaciones_Click(object sender, EventArgs e)
        {
            PanelGrupos.Visible = true;
            PanelEvaluacion.Visible = true;
            PanelAnularEvaluacion.Visible = true;

            List<GrupoxRubro> grupoxRubros = Procedures.ver_grupoxrubro_grupo(GrupoID);
            RadioButtonListEvaluaciones2.Items.Clear();
            for (int i = 0; i < grupoxRubros.Count; i++)
            {
                GrupoxRubro gr = grupoxRubros[i];
                List<Evaluacion> ev = Procedures.ver_evaluacion_grupoxrubro(gr.ID);
                for (int j = 0; j < ev.Count; j++)
                {
                    RadioButtonListEvaluaciones2.Items.Add(new ListItem(ev[j].nombre,ev[j].ID.ToString()));
                }
            }
        }

        protected void ButtonAnularEvaluacionOK_Click(object sender, EventArgs e)
        {

            EvaluacionID = int.Parse(RadioButtonListEvaluaciones2.SelectedValue);
            int result = Procedures.evaluacion_borrar(EvaluacionID);
            if (result == -1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"No se puede anular\");", true);
            }
            Inicio();
        }

        
        //Estudiantes      

        protected void ButtonEstudiantes_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelEstudiante.Visible = true;
        }

        protected void ButtonCrearEstudiante_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelEstudiante.Visible = true;
            PanelCrearEstudiante.Visible = true;
        }

        protected void ButtonCrearEstudianteOK_Click(object sender, EventArgs e)
        {
            string Nombre = TextBoxNombre.Text;
            string Apellido = TextBoxApellido.Text;
            string Telefono = TextBoxTelefono.Text;
            string Carnet = TextBoxCarnet.Text;
            string Correo = TextBoxCorreo.Text;
            string Contraseña = TextBoxContraseña.Text;

            Procedures.estudiante_crear(Nombre, Apellido,Correo, Carnet, Telefono, Contraseña);

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
            Inicio();
            PanelEstudiante.Visible = true;
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
            EstudianteID = estudiante.ID;
        }

        protected void ButtonModificarEstudianteOK_Click(object sender, EventArgs e)
        {
            string Nombre = TextBoxNombreNew.Text;
            string Apellido = TextBoxApellidoNew.Text;
            string Telefono = TextBoxTelefonoNew.Text;
            string Carnet = TextBoxCarnetNew.Text;
            string Correo = TextBoxCorreoNew.Text;
            string Contraseña = TextBoxContraseñaNew.Text;

            Procedures.estudiante_cambiar(EstudianteID,Nombre, Apellido, Correo, Carnet, Telefono, Contraseña);

            TextBoxNombreNew.Text = "";
            TextBoxApellidoNew.Text = "";
            TextBoxTelefonoNew.Text = "";
            TextBoxCorreoNew.Text = "";
            TextBoxContraseñaNew.Text = "";
            TextBoxCarnetNew.Text = "";

            Inicio();

        }

        protected void ButtonAnularEstudiante_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelEstudiante.Visible = true;
            PanelAnularEstudiante.Visible = true;

            RadioButtonListEstudiantes2.Items.Clear();
            List<Estudiante> estudiantes = Procedures.verEstudiantes();
            if (estudiantes.Count != 0)
            {
                for (int i = 0; i < estudiantes.Count; i++)
                {
                    RadioButtonListEstudiantes2.Items.Add(new ListItem(estudiantes[i].nombre + "(" + estudiantes[i].carnet + ")", estudiantes[i].ID.ToString()));
                }
            }

        }

        protected void ButtonAnularEstudianteOK_Click(object sender, EventArgs e)
        {
            List<Estudiante> estudiantes = Procedures.verEstudiantes();
            int index = RadioButtonListEstudiantes2.SelectedIndex;
            Estudiante estudiante = estudiantes[index];
            int result = Procedures.estudiante_borrar(estudiante.ID);
            if (result == -1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"No se puede anular\");", true);
            }
            Inicio();
        }


        //Registrar Notas
        protected void ButtonRegistrarNotas_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelRegistrarNotas.Visible = true;
            RadioButtonListPeriodos7.Items.Clear();
            List<Periodo> periodos = Procedures.xmlPeriodos();
            if (periodos.Count != 0)
            {
                for (int i = 0; i < periodos.Count; i++)
                {
                    RadioButtonListPeriodos7.Items.Add(new ListItem(periodos[i].ID.ToString()));
                }
            }

        }

        protected void SelectedIndexChangedPeriodo7(object sender, EventArgs e)
        {
            PeriodoID = int.Parse(RadioButtonListPeriodos7.SelectedItem.Text);
            RadioButtonListGrupos5.Items.Clear();
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(PeriodoID, ProfesorID);
            if (grupos.Count != 0)
            {
                for (int i = 0; i < grupos.Count; i++)
                {
                    RadioButtonListGrupos5.Items.Add(new ListItem(grupos[i].nombreCurso));
                }
            }
        }

        protected void SelectedIndexChangedGrupo5(object sender, EventArgs e)
        {
            ButtonOKGrupo.Visible = true;
        }

        protected void ButtonOKGrupo_Click(object sender, EventArgs e)
        {
            int indexGrupo = RadioButtonListGrupos5.SelectedIndex;
            List<Grupo> grupos = Procedures.ver_grupos_periodo_profesor(PeriodoID, ProfesorID);

            notas = grupos[indexGrupo];
            Server.Transfer("RegistrarNotas.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Server.Transfer("LogIn.aspx");

        }
    }
}