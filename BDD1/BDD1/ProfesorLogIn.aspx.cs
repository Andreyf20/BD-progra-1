using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BDD1
{
    public partial class ProfesorLogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buscar_Profesor_Click(object sender, EventArgs e)
        {
            string correo = correo_Profesor.Text;
            string contraseña = contraseña_Profesor.Text;
            
            int ID = Procedures.validar_login_profesor(correo, contraseña);
            if (ID == -1)
            {

            }
            else
            {
                ProfesorWindow.ProfesorID = ID;
                Server.Transfer("ProfesorWindow.aspx");
            }
        }
    }
}