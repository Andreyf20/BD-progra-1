using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace BDD1
{
    public class Procedures
    {
        public static int validar_login_estudiante(string correo, string contraseña)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("validar_login_estudiante", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = correo;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = contraseña;
            cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            con.Open();
            cmd.ExecuteNonQuery();
            int ret = int.Parse(cmd.Parameters["@result"].Value.ToString());
            con.Close();
            return ret;
        }

        public static void borrar_periodo(int ID)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("validar_login_estudiante", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
