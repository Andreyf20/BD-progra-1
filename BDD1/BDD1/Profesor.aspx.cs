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

        protected void ButtonSemestre_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonPeriodos_Click(object sender, EventArgs e)
        {
            PanelGrupos.Visible = false;
            PanelPeriodo.Visible = true;
        }

        protected void ButtonGrupos_Click(object sender, EventArgs e)
        {
            PanelPeriodo.Visible = false;
            PanelGrupos.Visible = true;
        }
    }
}