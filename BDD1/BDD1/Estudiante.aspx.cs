﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BDD1
{
    public partial class Estudiante : System.Web.UI.Page
    {
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        

        protected void buscar_estudiante_Click(object sender, EventArgs e)
        {
            string correo = correo_Estudiante.Text;
            string contraseña = contraseña_Estudiante.Text;
            int respuesta = Procedures.validar_login_estudiante(correo, contraseña);

        }
    }
}