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
        public List<Periodo> periodos = new List<Periodo>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonPeriodos_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelGrupos.Visible = false;
            PanelInicio.Visible = false;
            PanelPeriodo.Visible = true;
        }

        protected void ButtonGrupos_Click(object sender, EventArgs e)
        {
            Inicio();
            PanelPeriodo.Visible = false;
            PanelInicio.Visible = false;
            PanelGrupos.Visible = true;
        }

        protected void ButtonCrearPeriodo_Click(object sender, EventArgs e)
        {
            PanelModificarPeriodo.Visible = false;
            PanelCrearPeriodo.Visible = true;
        }

        protected void ButtonCrearPeriodoOK_Click(object sender, EventArgs e)
        {
            Periodo periodoActual = new Periodo(CalendarInicio.SelectedDate, CalendarFinal.SelectedDate);
            this.periodos.Add(periodoActual);
            Inicio();
            Label1.Text = "Periodo Creado Correctamente";
        }

        protected void ButtonModificarPeriodo_Click(object sender, EventArgs e)
        {
            PanelCrearPeriodo.Visible = false;
            PanelModificarPeriodo.Visible = true;
        }

        protected void ButtonCrearGrupo_Click(object sender, EventArgs e)
        {
            PanelModificarGrupo.Visible = false;
            PanelCrearGrupo.Visible = true;
        }

        protected void ButtonModificarGrupo_Click(object sender, EventArgs e)
        {
            PanelCrearGrupo.Visible = false;
            PanelModificarGrupo.Visible = true;
        }

        protected void ButtonModificarGrupoOK_Click(object sender, EventArgs e)
        {
            Inicio();
        }

        protected void ButtonInicio_Click(object sender, EventArgs e)
        {
            Inicio();
        }

        protected void ButtonAgregarRubro_Click(object sender, EventArgs e)
        {
            if(RadioButtonList1.SelectedItem.Text.Equals("Fijo"))
            {
                PanelAregarRubro.Visible = true;
            }
            else
            {
                Inicio();
            }
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
            Label1.Text = "";

        }

        protected void ButtonAgregarRubroOK_Click(object sender, EventArgs e)
        {
            string instancia = "Nombre: "+TextBoxNombreRubro.Text + "Descripción: "+ TextBoxDescripcionRubro.Text+"Valor: "+ TextBoxValorRubro.Text+"\n" ;
            TextAreaInstancias.Value += instancia; 
        }

        protected void ButtonInstanciasOK_Click(object sender, EventArgs e)
        {
            TextBoxNombreRubro.Text = "";
            TextBoxDescripcionRubro.Text = "";
            TextBoxValorRubro.Text = "";
            PanelAregarRubro.Visible = false;
        }

        protected void ButtonTerminarGrupo_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonRegistrarNotas_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonModificarPeriodoOK_Click(object sender, EventArgs e)
        {
            if (RadioButtonList2.SelectedItem.Text.Equals("Activo"))
            {
                periodos[0].activo = true;
            }
            else
            {
                periodos[0].activo = false;
            }
            Inicio();
            Label1.Text = "Periodo Modificado Correctamente";
        }

        protected void ButtonAnularPeriodo_Click(object sender, EventArgs e)
        {
            periodos[0] = null;
            Inicio();
            Label1.Text = "Periodo Anulado Correctamente";

        }

        protected void ButtonTerminarPeriodo_Click(object sender, EventArgs e)
        {
            periodos[0].activo = false;
            Inicio();
            Label1.Text = "Periodo Terminado Correctamente";
        }

        protected void ButtonCrearGrupoOK_Click(object sender, EventArgs e)
        {

            string nombre = TextBoxNombreGrupo.Text;
            string aula = TextBoxAula.Text;
            string horaInicio = TextBoxHoraInicio.Text;
            string horaFinal = TextBoxHoraFin.Text;
            string codigoGrupo = TextBoxCodigoGrupo.Text;
            TextBoxNombreGrupo.Text = "";
            TextBoxAula.Text = "";
            TextBoxHoraInicio.Text = "";
            TextBoxHoraFin.Text = "";
            TextBoxCodigoGrupo.Text = "";
            Grupo nuevo = new Grupo(nombre,horaInicio,horaFinal,aula,codigoGrupo);
            this.periodos[0].agregarGrupo(nuevo);

            PanelCrearRubros.Visible = true;
        }
    }
}