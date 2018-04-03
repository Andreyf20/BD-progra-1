using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BDD1
{
    public partial class ConsultaEstudiante : System.Web.UI.Page
    {
        public static int estudianteID;

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Periodo> periodos = Procedures.xmlPeriodos();
            RadioButtonListPeriodos.Items.Clear();
            if (periodos.Count != 0)
            {
                for (int i = 0; i < periodos.Count; i++)
                {
                    RadioButtonListPeriodos.Items.Add(new ListItem(periodos[i].ID.ToString()));
                }
            }


            System.Data.DataTable dt = Procedures.verNotas(estudianteID);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void RadioButtonListPeriodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int indexPeriodo = int.Parse(RadioButtonListPeriodos.SelectedItem.Text);
            //RadioButtonListGrupos.Items.Clear();
            //List<Grupo> grupos = Procedures.grupo
            //if (grupos.Count != 0)
            //{
            //    for (int i = 0; i < grupos.Count; i++)
            //    {
            //        RadioButtonListGrupos.Items.Add(new ListItem(grupos[i].nombreCurso));
            //    }
            //}
        }
    }
}