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
        //Grupo x Estudiante

        public static void grupoxestudiante_actualizar_nota_acumulada(int id, int nota )
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("grupoxestudiante_actualizar_nota_acumulada", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@nota", SqlDbType.Int).Value = nota;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void grupoxestudiante_borrar(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("grupoxestudiante_borrar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void grupoxestudiante_crear(int idgrupo, int idestadogxe, int idestudiante)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("grupoxestudiante_crear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idgrupo", SqlDbType.Int).Value = idgrupo;
            cmd.Parameters.Add("@idestadogxe", SqlDbType.Int).Value = idestadogxe;
            cmd.Parameters.Add("@idestudiante", SqlDbType.Int).Value = idestudiante;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Grupo x Rubro

        public static void grupoxrubro_actualizar_cantidad(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("grupoxrubro_actualizar_cantidad", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void grupoxrubro_borrar(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("grupoxrubro_borrar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void grupoxrubro_crear(int idgrupo, int idRubro, int valorPorcentual, int esFijo, int cantidad)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("grupoxrubro_crear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idgrupo", SqlDbType.Int).Value = idgrupo;
            cmd.Parameters.Add("@idRubro", SqlDbType.Int).Value = idRubro;
            cmd.Parameters.Add("@valorPorcentual", SqlDbType.Int).Value = valorPorcentual;
            cmd.Parameters.Add("@esFijo", SqlDbType.Int).Value = esFijo;
            cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Periodo

        public static void periodo_borrar(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("periodo_borrar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void periodo_CambiarActivo(int id, int activo)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("periodo_CambiarActivo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@activo", SqlDbType.Int).Value = activo;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void periodo_crear(DateTime inicio, DateTime fin)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("periodo_crear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@inicio", SqlDbType.Date).Value = inicio;
            cmd.Parameters.Add("@final", SqlDbType.Date).Value = fin;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Rubro

        public static void rubro_borrar(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("rubro_borrar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void rubro_crear(string nombre)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("rubro_crear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Validar Log In

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

    }
}
