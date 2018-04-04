using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BDD1
{
    public partial class LogIn : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Panel1.Visible = true;
            Panel2.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
        }

        protected void buscar_Profesor_Click(object sender, EventArgs e)
        {
            string correo = correo_Profesor.Text;
            string contraseña = contraseña_Profesor.Text;

            int ID = Procedures.validar_login_profesor(correo, contraseña);
            if (ID == -1)
            {
                Label1.Text = "Error al ingresar";
                Label1.Visible = true;
            }
            else
            {
                Label1.Text = "Bienvenido";
                Label1.Visible = true;
                ProfesorWindow.ProfesorID = ID;
                Server.Transfer("ProfesorWindow.aspx");
            }
        }

        protected void buscar_estudiante_Click(object sender, EventArgs e)
        {
            string correo = correo_Estudiante.Text;
            string contraseña = contraseña_Estudiante.Text;

            int ID = Procedures.validar_login_estudiante(correo, contraseña);
            if (ID == -1)
            {
                Label2.Text = "Error al ingresar";
                Label2.Visible = true;
            }
            else
            {
                Label2.Text = "Bienvenido";
                Label2.Visible = true;
                ConsultaEstudiante.estudianteID = ID;
                ConsultaEstudiante.grupos = Procedures.ver_grupos_estudiante(ID);
                Server.Transfer("ConsultaEstudiante.aspx");
            }
        }
    }
}