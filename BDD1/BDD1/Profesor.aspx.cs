using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BDD1
{
    public partial class Profesor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

   

        protected void ButtonPeriodos_Click(object sender, EventArgs e)
        {
            PanelGrupos.Visible = false;
            PanelInicio.Visible = false;
            PanelPeriodo.Visible = true;
        }

        protected void ButtonGrupos_Click(object sender, EventArgs e)
        {
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
            PanelGrupos.Visible = false;
            PanelPeriodo.Visible = false;
            PanelInicio.Visible = true;
        }

        protected void ButtonAgregarRubros_Click(object sender, EventArgs e)
        {
            PanelCrearRubros.Visible = true;
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
            PanelGrupos.Visible = false;
            PanelPeriodo.Visible = false;
            PanelInicio.Visible = true;
        }

        protected void ButtonInicio_Click(object sender, EventArgs e)
        {
            PanelPeriodo.Visible = false;
            PanelGrupos.Visible = false;
            PanelInicio.Visible = true;
        }

        protected void ButtonAgregarRubro_Click(object sender, EventArgs e)
        {
            if(RadioButtonList1.SelectedItem.Text.Equals("Fijo"))
            {
                Console.WriteLine(RadioButtonList1.SelectedItem);
                PanelAregarRubro.Visible = true;
            }
            else
            {
                PanelPeriodo.Visible = false;
                PanelGrupos.Visible = false;
                PanelInicio.Visible = true;
            }
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
    }
}