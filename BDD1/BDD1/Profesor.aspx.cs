using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;


namespace BDD1
{
    public partial class Profesor : System.Web.UI.Page
    {
        public static int profesorID;
        public static Grupo grupoActivo;
        public static List<Periodo> periodos = new List<Periodo>(); 
        public static List<BDD1.Clases.Estudiante> estudiantes = new List<BDD1.Clases.Estudiante>();
        public static List<Rubro> rubros = new List<Rubro>();
        protected void Page_Load(object sender, EventArgs e){}

        //Cargar Datos
        protected void Button1_Click(object sender, EventArgs e)
        {
            llenarDatos();

        }
        public void llenarDatos()
        {
            Evaluacion e1 = new Evaluacion("Examen 1", DateTime.Now, 30);
            Evaluacion e2 = new Evaluacion("Quiz1", DateTime.Now, 30);
            Evaluacion e3 = new Evaluacion("Examen 2", DateTime.Now, 30);
            Evaluacion e4 = new Evaluacion("Proyecto", DateTime.Now, 30);


            estudiantes.Add(new Clases.Estudiante(10));
            estudiantes.Add(new Clases.Estudiante(20));
            estudiantes.Add(new Clases.Estudiante(30));
            estudiantes.Add(new Clases.Estudiante(40));

            rubros.Add(new Rubro("Examen"));
            rubros.Add(new Rubro("Proyecto"));
            rubros.Add(new Rubro("Tarea"));
            rubros.Add(new Rubro("Quiz"));

            List<GrupoxRubro> g = grupoActivo.grupoxRubros;
            List<GrupoxEstudiante> ge = grupoActivo.grupoxEstudiantes;

            GrupoxRubro g1 = new GrupoxRubro(rubros[0], 40, true, 3);
            g1.evaluaciones.Add(e1);
            g1.evaluaciones.Add(e3);
            GrupoxRubro g3 = new GrupoxRubro(rubros[1], 40, true, 3);
            g3.evaluaciones.Add(e2);
            GrupoxRubro g2 = new GrupoxRubro(rubros[3], 40, true, 3);
            g2.evaluaciones.Add(e4);
            

            GrupoxEstudiante ge1 = new GrupoxEstudiante(20, estudiantes[0]);
            GrupoxEstudiante ge2 = new GrupoxEstudiante(20, estudiantes[1]);
            GrupoxEstudiante ge3 = new GrupoxEstudiante(20, estudiantes[2]);
            GrupoxEstudiante ge4 = new GrupoxEstudiante(20, estudiantes[3]);

            g.Add(g1);
            g.Add(g3);
            g.Add(g2);

            ge.Add(ge1);
            ge.Add(ge2);
            ge.Add(ge3);
            ge.Add(ge4);
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
            Periodo periodoActual = new Periodo(CalendarInicio.SelectedDate, CalendarFinal.SelectedDate);
            periodos.Add(periodoActual);
            //Procedures.periodo_crear(CalendarInicio.SelectedDate, CalendarFinal.SelectedDate);
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
            if (periodos.Count != 0)
            {
                for (int i = 0; i < periodos.Count; i++)
                {
                    RadioButtonListPeriodos1.Items.Add(new ListItem(periodos[i].ID.ToString()));
                }
            }
        }

        protected void ButtonModificarPeriodoOK_Click(object sender, EventArgs e)
        {
            int periodoID = int.Parse(RadioButtonListPeriodos1.SelectedItem.Text);
            if (RadioButtonList2.SelectedItem.Text.Equals("Activo"))
            {
                //Procedures.periodo_CambiarActivo(periodoID, 1);
                periodos[periodoID-1].activo = 1;
            }
            else
            {
                //Procedures.periodo_CambiarActivo(periodoID, 0);
                periodos[periodoID-1].activo = 0;
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
            periodos[periodoID-1] = null;
            //Procedures.periodo_borrar(periodoID);
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
            if (periodos.Count != 0)
            {
                for (int i = 0; i < periodos.Count; i++)
                {
                    RadioButtonListPeriodos3.Items.Add(new ListItem(periodos[i].ID.ToString()));
                }
            }
        }

        protected void ButtonTerminarPeriodoOK_Click(object sender, EventArgs e)
        {
            int periodoID = int.Parse(RadioButtonListPeriodos3.SelectedItem.Text);
            periodos[periodoID-1].activo = 0;
            Procedures.periodo_CambiarActivo(periodoID, 0);
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
            if (periodos.Count != 0)
            {
                for (int i = 0; i < periodos.Count; i++)
                {
                    RadioButtonListPeriodos4.Items.Add(new ListItem(periodos[i].ID.ToString()));
                }
            }
        }

        protected void ButtonCrearGrupoOK_Click(object sender, EventArgs e)
        {
            int periodoID = int.Parse(RadioButtonListPeriodos4.SelectedItem.Text);
            string nombre = TextBoxNombreGrupo.Text;
            string codigoGrupo = TextBoxCodigoGrupo.Text;
            Grupo nuevo = new Grupo(nombre,  codigoGrupo);
            periodos[periodoID-1].agregarGrupo(nuevo);
            //Procedures.grupo_crear(, periodoID, nombre, codigoGrupo);
            PanelCrearRubros.Visible = true;
            DropDownListTipoRubro.Items.Clear();
            for(int i=0; i<rubros.Count;i++)
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

        protected void ButtonAgregarRubro_Click(object sender, EventArgs e)
        {
            int periodoID = int.Parse(RadioButtonListPeriodos4.SelectedItem.Text);
            int idGrupo = periodos[periodoID - 1].grupos.Count;
            int idRubro = DropDownListTipoRubro.SelectedIndex;
            int valorPorcentual = int.Parse(TextBoxPorcentajeRubro.Text);
            if (RadioButtonList1.SelectedItem.Text.Equals("Fijo"))
            {
                int cantidad = int.Parse(TextBoxCantidadRubro.Text);
                periodos[periodoID-1].grupos.Last().grupoxRubros.Add(new GrupoxRubro(rubros[idRubro - 1], valorPorcentual, true, cantidad));
                PanelAregarRubro.Visible = true;
                //Procedures.grupoxrubro_crear(idGrupo,idRubro, valorPorcentual, 1, cantidad);
            }
            else
            {
                periodos[periodoID - 1].grupos.Last().grupoxRubros.Add(new GrupoxRubro(rubros[idRubro - 1], valorPorcentual, false, 0));
                //Procedures.grupoxrubro_crear(idGrupo,idRubro, valorPorcentual, 0,0);
                TextBoxPorcentajeRubro.Text = "";
            }
        }

        protected void ButtonAgregarRubroOK_Click(object sender, EventArgs e)
        {
            int periodoID = int.Parse(RadioButtonListPeriodos4.SelectedItem.Text);
            GrupoxRubro grupoxRubro = periodos[periodoID - 1].grupos.Last().grupoxRubros.Last();
            int idGrupoxRubro = periodos[periodoID - 1].grupos.Last().grupoxRubros.Count;

            DateTime date = CalendarEvaluacion.SelectedDate;
            string nombre = TextBoxNombreRubro.Text;
            string descripción = TextBoxDescripcionRubro.Text;
            int valor = int.Parse(TextBoxValorRubro.Text);

            //Procedures.evaluacion_crear(idGrupoxRubro, nombre, date, valor);
            grupoxRubro.evaluaciones.Add(new Evaluacion(nombre, date, valor));
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
            Periodo periodo = periodos[indexPeriodo-1];
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
            Periodo periodo = periodos[indexPeriodo-1];
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
            periodos[periodo - 1].grupos[indexGrupo - 1] = null;
            //Procedures.grupo_borrar(periodos[periodo - 1].grupos[indexGrupo - 1].ID);
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
            if (periodos.Count != 0)
            {
                for (int i = 0; i < periodos.Count; i++)
                {
                    RadioButtonListPeriodos7.Items.Add(new ListItem(periodos[i].ID.ToString()));
                }
            }
        }

        protected void SelectedIndexChangedPeriodo3(object sender, EventArgs e)
        {
            int indexPeriodo = int.Parse(RadioButtonListPeriodos7.SelectedItem.Text);
            Periodo periodo = periodos[indexPeriodo-1];
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
            if (periodos.Count!=0)
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
            Periodo periodo = periodos[indexPeriodo-1];
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
            grupoActivo = periodos[periodoID - 1].grupos[indexGrupo];
            llenarDatos();
            Server.Transfer("RegistrarNotas.aspx");
        }
        
    }
}