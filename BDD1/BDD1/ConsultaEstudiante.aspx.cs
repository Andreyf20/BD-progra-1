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
        public static List<Grupo> grupos;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (grupos.Count != 0)
            {
                for (int i = 0; i < grupos.Count; i++)
                {
                    RadioButtonListGrupos.Items.Add(new ListItem(grupos[i].nombreCurso.ToString()));
                }
            }
        }
        public void ponerGrupos()
        {
            if (grupos.Count != 0)
            {
                for (int i = 0; i < grupos.Count; i++)
                {
                    RadioButtonListGrupos.Items.Add(new ListItem(grupos[i].nombreCurso.ToString()));
                }
            }
        }
        protected void SelectedIndexChangedGrupo(object sender, EventArgs e)
        {
            int indexGrupo = RadioButtonListGrupos.SelectedIndex;
            
            Grupo grupo = grupos[indexGrupo];
            Label1.Text = "Nota Acumulada: " + Procedures.actualizar_nota_acumulada_estudiante(grupo.ID, estudianteID);
            Label1.Visible = true;
            System.Data.DataTable dt = Procedures.ver_notas_estudiante_grupo(estudianteID, grupo.ID);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            RadioButtonListGrupos.Items.Clear();
            ponerGrupos();

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Server.Transfer("LogIn.aspx");
        }
    }
}