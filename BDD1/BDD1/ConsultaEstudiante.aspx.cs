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
            System.Data.DataTable dt = Procedures.verNotas(estudianteID);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}