﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BDD1
{
    public partial class Tablas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Procedures.actualizar_nota_acumulada_estudiante(1, 1).ToString();
            

        }
    }
}