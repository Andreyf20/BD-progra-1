using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BDD1
{
    public partial class Prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable myDataTable = Procedures.estudiantes_ver();
            grid1.DataSource = myDataTable;
            grid1.DataBind();
        }
    }
}