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
        //Estado Grupo

        public static int estadogrupo_borrar(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("estadogrupo_borrar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            con.Open();
            cmd.ExecuteNonQuery();
            int ret = int.Parse(cmd.Parameters["@result"].Value.ToString());
            con.Close();
            return ret;
        }

        public static void estadogrupo_crear(string nombre)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("estadogrupo_crear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = nombre;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Estado Grupo x Estudiante

        public static int estadogxe_borrar(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("estadogxe_borrar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            con.Open();
            cmd.ExecuteNonQuery();
            int ret = int.Parse(cmd.Parameters["@result"].Value.ToString());
            con.Close();
            return ret;
        }

        public static void estadogxe_crear(string nombre)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("estadogxe_crear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = nombre;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Estudiante

        public static decimal actualizar_nota_acumulada_estudiante(int @idGrupo, int @idEstudiante)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("actualizar_nota_acumulada_estudiante", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idGrupo", SqlDbType.Int).Value = @idGrupo;
            cmd.Parameters.Add("@idEstudiante", SqlDbType.Int).Value = @idEstudiante;
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dataset = new DataTable();
            adapt.Fill(dataset);
            List<decimal> evaluaciones = new List<decimal>();
            if (dataset.Rows[0].ToString()=="")
            {
                return -1;
            }
            else
            {
                Console.WriteLine(dataset.Rows[0].ToString());
                foreach (DataRow row in dataset.Rows)
                {
                    decimal Nota = decimal.Parse(row["Column1"].ToString());
                    evaluaciones.Add(Nota);
                }
                return evaluaciones[0];
            }
        }
        
        public static int estudiante_borrar(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("estudiante_borrar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            con.Open();
            cmd.ExecuteNonQuery();
            int ret = int.Parse(cmd.Parameters["@result"].Value.ToString());
            con.Close();
            return ret;
        }

        public static void estudiante_crear(string Nombre, string Apellido, string Correo, string Carnet, string Telefono, string Contraseña)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("estudiante_crear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
            cmd.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = Apellido;
            cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Correo;
            cmd.Parameters.Add("@Carnet", SqlDbType.VarChar).Value = Carnet;
            cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Telefono;
            cmd.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = Contraseña;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void estudiante_cambiar(int ID,string Nombre, string Apellido, string Correo, string Carnet, string Telefono, string Contraseña)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("estudiante_cambiar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
            cmd.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = Apellido;
            cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Correo;
            cmd.Parameters.Add("@Carnet", SqlDbType.VarChar).Value = Carnet;
            cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Telefono;
            cmd.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = Contraseña;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


        //Evaluación

        public static int evaluacion_borrar(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("evaluacion_borrar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            con.Open();
            cmd.ExecuteNonQuery();
            int ret = int.Parse(cmd.Parameters["@result"].Value.ToString());
            con.Close();
            return ret;
        }

        public static void evaluacion_crear(int idGrupoxRubro, string Nombre, DateTime Fecha, decimal ValorPorcentual, string Descripcion)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("evaluacion_crear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idGrupoxRubro", SqlDbType.Int).Value = idGrupoxRubro;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
            cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = Fecha;
            cmd.Parameters.Add("@ValorPorcentual", SqlDbType.Decimal).Value = ValorPorcentual;
            cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Evaluación x Estudiante

        public static int evaluacionxestudiante_borrar(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("evaluacionxestudiante_borrar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            con.Open();
            cmd.ExecuteNonQuery();
            int ret = int.Parse(cmd.Parameters["@result"].Value.ToString());
            con.Close();
            return ret;
        }

        public static void evaluacionxestudiante_cambiar_nota(int @idGrupoxEstudiante ,int @idEvaluacion,  decimal Nota)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("evaluacionesxestudiantes_cambiar_nota", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idGrupoxEstudiante", SqlDbType.Int).Value = @idGrupoxEstudiante;
            cmd.Parameters.Add("@idEvaluacion", SqlDbType.Int).Value = @idEvaluacion;
            cmd.Parameters.Add("@Nota", SqlDbType.Decimal).Value = Nota;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void evaluacionxestudiante_crear(int idGrupoxEstudiante, int idEvaluacion, decimal Nota)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("evaluacionxestudiante_crear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idGrupoxEstudiante", SqlDbType.Int).Value = idGrupoxEstudiante;
            cmd.Parameters.Add("@idEvaluacion", SqlDbType.Int).Value = idEvaluacion;
            cmd.Parameters.Add("@Nota", SqlDbType.Decimal).Value = Nota;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Grupo

        public static int grupo_borrar(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("grupo_borrar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            con.Open();
            cmd.ExecuteNonQuery();
            int ret = int.Parse(cmd.Parameters["@result"].Value.ToString());
            con.Close();
            return ret;
        }

        public static int grupo_crear(int idEstado, int idPeriodo, int idPforesor, string NombreCurso, string CodigoGrupo)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("grupo_crear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idEstado", SqlDbType.Int).Value = idEstado;
            cmd.Parameters.Add("@idPeriodo", SqlDbType.Int).Value = idPeriodo;
            cmd.Parameters.Add("@idProfesor", SqlDbType.Int).Value = idPforesor;
            cmd.Parameters.Add("@NombreCurso", SqlDbType.VarChar).Value = NombreCurso;
            cmd.Parameters.Add("@CodigoGrupo", SqlDbType.VarChar).Value = CodigoGrupo;
            cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            con.Open();
            cmd.ExecuteNonQuery();
            int ret = int.Parse(cmd.Parameters["@result"].Value.ToString());
            con.Close();
            return ret;
        }

        //Grupo x Estudiante

        //public static void grupoxestudiante_actualizar_nota_acumulada(int id, decimal nota)
        //{
        //    SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
        //    SqlCommand cmd = new SqlCommand("grupoxestudiante_actualizar_nota_acumulada", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
        //    cmd.Parameters.Add("@nota", SqlDbType.Decimal).Value = nota;
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}

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

        public static void grupoxestudiante_crear(int idgrupo, int idestadogxe, int idestudiante, decimal NotaAcumulada)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("grupoxestudiante_crear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idgrupo", SqlDbType.Int).Value = idgrupo;
            cmd.Parameters.Add("@idestadogxe", SqlDbType.Int).Value = idestadogxe;
            cmd.Parameters.Add("@idestudiante", SqlDbType.Int).Value = idestudiante;
            cmd.Parameters.Add("@NotaAcumulada", SqlDbType.Decimal).Value = NotaAcumulada;
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

        public static int grupoxrubro_borrar(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("grupoxrubro_borrar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            con.Open();
            cmd.ExecuteNonQuery();
            int ret = int.Parse(cmd.Parameters["@result"].Value.ToString());
            con.Close();
            return ret;
        }

        public static void grupoxrubro_cambiar_cantidad(int id, int cantidad)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("grupoxrubro_cambiar_cantidad", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static int grupoxrubro_crear(int idgrupo, int idRubro, decimal valorPorcentual, string esFijo, int cantidad)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("grupoxrubro_crear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idgrupo", SqlDbType.Int).Value = idgrupo;
            cmd.Parameters.Add("@idRubro", SqlDbType.Int).Value = idRubro;
            cmd.Parameters.Add("@valorPorcentual", SqlDbType.Int).Value = valorPorcentual;
            cmd.Parameters.Add("@esFijo", SqlDbType.VarChar).Value = esFijo;
            cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad;
            cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            con.Open();
            cmd.ExecuteNonQuery();
            int ret = int.Parse(cmd.Parameters["@result"].Value.ToString());
            con.Close();
            return ret;
        }

        //Periodo

        public static int periodo_borrar(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("periodo_borrar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            con.Open();
            cmd.ExecuteNonQuery();
            int ret = int.Parse(cmd.Parameters["@result"].Value.ToString());
            con.Close();
            return ret;
        }

        public static void periodo_CambiarActivo(int id, string activo)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("periodo_CambiarActivo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@activo", SqlDbType.VarChar).Value = activo;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static int periodo_crear(DateTime inicio, DateTime fin)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("periodo_crear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@inicio", SqlDbType.Date).Value = inicio;
            cmd.Parameters.Add("@final", SqlDbType.Date).Value = fin;
            cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            con.Open();
            cmd.ExecuteNonQuery();
            int ret = int.Parse(cmd.Parameters["@result"].Value.ToString());
            con.Close();
            return ret;
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
        public static int validar_login_estudiante(string @email, string @password)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("validar_login_estudiante", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = @email;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = @password;
            cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            con.Open();
            cmd.ExecuteNonQuery();
            int ret = int.Parse(cmd.Parameters["@result"].Value.ToString());
            con.Close();
            return ret;
        }

        public static int validar_login_profesor(string @email, string @password)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("validar_login_profesor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = @email;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = @password;
            cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            con.Open();
            cmd.ExecuteNonQuery();
            int ret = int.Parse(cmd.Parameters["@result"].Value.ToString());
            con.Close();
            return ret;
        }

        


        

        public static List<Periodo> xmlPeriodosActivos()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand com = new SqlCommand("ver_periodos_disponibles", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapt = new SqlDataAdapter(com);
            DataTable dataset = new DataTable();
            adapt.Fill(dataset);
            List<Periodo> periodos = new List<Periodo>();
            foreach (DataRow row in dataset.Rows)
            {
                int ID = int.Parse(row["ID"].ToString());
                DateTime FechaInicio = DateTime.Parse(row["FechaInicio"].ToString());
                DateTime FechaFinal = DateTime.Parse(row["FechaFinal"].ToString());
                string Activo = row["Activo"].ToString();
                Periodo periodo = new Periodo(ID, FechaInicio, FechaFinal, Activo);
                periodos.Add(periodo);
            }
            return periodos;
        }

        public static List<Periodo> xmlPeriodos()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand com = new SqlCommand("ver_periodos", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapt = new SqlDataAdapter(com);
            DataTable dataset = new DataTable();
            adapt.Fill(dataset);
            List<Periodo> periodos = new List<Periodo>();
            foreach (DataRow row in dataset.Rows)
            {
                int ID = int.Parse(row["ID"].ToString());
                DateTime FechaInicio = DateTime.Parse(row["FechaInicio"].ToString());
                DateTime FechaFinal = DateTime.Parse(row["FechaFinal"].ToString());
                string Activo = row["Activo"].ToString();
                Periodo periodo = new Periodo(ID, FechaInicio, FechaFinal, Activo);
                periodos.Add(periodo);
            }
            return periodos;
        }

        public static List<Rubro> xmlRubros()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand com = new SqlCommand("ver_rubros_disponibles", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapt = new SqlDataAdapter(com);
            DataTable dataset = new DataTable();
            adapt.Fill(dataset);
            List<Rubro> rubros = new List<Rubro>();
            foreach (DataRow row in dataset.Rows)
            {
                int ID = int.Parse(row["ID"].ToString());
                string Nombre = row["Nombre"].ToString();
                Rubro rubro = new Rubro(ID, Nombre);
                rubros.Add(rubro);
            }
            return rubros;
        }

        public static List<EstadoGrupo> xmlEstadoGrupo()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand com = new SqlCommand("ver_estadogrupo_disponibles", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapt = new SqlDataAdapter(com);
            DataTable dataset = new DataTable();
            adapt.Fill(dataset);
            List<EstadoGrupo> EGS = new List<EstadoGrupo>();
            foreach (DataRow row in dataset.Rows)
            {
                int ID = int.Parse(row["ID"].ToString());
                string Nombre = row["Nombre"].ToString();
                EstadoGrupo EG = new EstadoGrupo(ID, Nombre);
                EGS.Add(EG);
            }
            return EGS;
        }

        public static List<Grupo> ver_grupos_periodo_profesor(int @IDPeriodo, int @IDProfesor)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("ver_grupos_periodo_profesor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idPeriodo", SqlDbType.Int).Value = @IDPeriodo;
            cmd.Parameters.Add("@idProfesor", SqlDbType.Int).Value = @IDProfesor;
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dataset = new DataTable();
            adapt.Fill(dataset);
            List<Grupo> EGS = new List<Grupo>();
            foreach (DataRow row in dataset.Rows)
            {
                int ID = int.Parse(row["idGrupo"].ToString());
                int idEstado = int.Parse(row["idEstado"].ToString());
                int idPeriodo = int.Parse(row["idPeriodo"].ToString());
                int idProfesor = int.Parse(row["idProfesor"].ToString());
                string NombreCurso = row["NombreCurso"].ToString();
                string CodigoGrupo = row["CodigoGrupo"].ToString();
                Grupo EG = new Grupo(ID, NombreCurso, CodigoGrupo, idEstado, idPeriodo, idProfesor);
                EGS.Add(EG);
            }
            return EGS;
        }

        public static List<Grupo> ver_grupos_estudiante(int @idEstudiante)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("ver_grupos_estudiante", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idEstudiante", SqlDbType.Int).Value = @idEstudiante;
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dataset = new DataTable();
            adapt.Fill(dataset);
            List<Grupo> EGS = new List<Grupo>();
            foreach (DataRow row in dataset.Rows)
            {
                int ID = int.Parse(row["ID"].ToString());
                int idEstado = int.Parse(row["idEstado"].ToString());
                int idPeriodo = int.Parse(row["idPeriodo"].ToString());
                int idProfesor = int.Parse(row["idProfesor"].ToString());
                string NombreCurso = row["NombreCurso"].ToString();
                string CodigoGrupo = row["CodigoGrupo"].ToString();
                Grupo EG = new Grupo(ID, NombreCurso, CodigoGrupo, idEstado, idPeriodo, idProfesor);
                EGS.Add(EG);
            }
            return EGS;
        }

        public static List<decimal> ver_evaluacionesxestudiantes(int idGrupoxEstudiante, int idEvaluacion)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("ver_evaluacionesxestudiantes", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idGrupoxEstudiante", SqlDbType.Int).Value = idGrupoxEstudiante;
            cmd.Parameters.Add("@idEvaluacion", SqlDbType.Int).Value = idEvaluacion;
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dataset = new DataTable();
            adapt.Fill(dataset);
            List<decimal> evaluaciones = new List<decimal>();
            foreach (DataRow row in dataset.Rows)
            {
                decimal Nota = decimal.Parse(row["Nota"].ToString());
                evaluaciones.Add(Nota);
            }
            return evaluaciones;
        }
        
        public static List<string> ver_grupo(int idGrupo)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("ver_grupo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idGrupo", SqlDbType.Int).Value = idGrupo;
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dataset = new DataTable();
            adapt.Fill(dataset);
            List<string> evaluaciones = new List<string>();
            foreach (DataRow row in dataset.Rows)
            {
                string Nombre = row["NombreCurso"].ToString();
                string Codigo = row["CodigoGrupo"].ToString();
                evaluaciones.Add(Nombre);
                evaluaciones.Add(Codigo);
            }
            return evaluaciones;
        }

        public static List<Evaluacion> ver_evaluacion_grupoxrubro(int @idGrupoxRubro)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand com = new SqlCommand("ver_evaluacion_grupoxrubro", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@idGrupoxRubro", SqlDbType.Int).Value = @idGrupoxRubro;
            SqlDataAdapter adapt = new SqlDataAdapter(com);
            DataTable dataset = new DataTable();
            adapt.Fill(dataset);
            List<Evaluacion> evaluaciones = new List<Evaluacion>();
            foreach (DataRow row in dataset.Rows)
            {
                int ID = int.Parse(row["ID"].ToString());
                int IdGrupoxRubro = int.Parse(row["IdGrupoxRubro"].ToString());
                string Nombre = row["Nombre"].ToString();
                DateTime Fecha = DateTime.Parse(row["Fecha"].ToString());
                decimal valorPorcentual = decimal.Parse(row["ValorPorcentual"].ToString());
                string Descripcion = row["Descripcion"].ToString();
                Evaluacion evaluacion = new Evaluacion(ID, IdGrupoxRubro, Nombre, Fecha, valorPorcentual, Descripcion);
                evaluaciones.Add(evaluacion);
            }
            return evaluaciones;
        }

        public static List<GrupoxRubro> ver_grupoxrubro_grupo(int @idGrupo)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand com = new SqlCommand("ver_grupoxrubro_grupo", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@idGrupo", SqlDbType.Int).Value = @idGrupo;
            SqlDataAdapter adapt = new SqlDataAdapter(com);
            DataTable dataset = new DataTable();
            adapt.Fill(dataset);
            List<GrupoxRubro> grupos = new List<GrupoxRubro>();
            foreach (DataRow row in dataset.Rows)
            {
                int ID = int.Parse(row["ID"].ToString());
                int IdGrupo = int.Parse(row["IdGrupo"].ToString());
                int IdRubro = int.Parse(row["IdRubro"].ToString());
                int Cantidad = int.Parse(row["Cantidad"].ToString());
                decimal ValorPorcentual = decimal.Parse(row["ValorPorcentual"].ToString());
                string EsFijo = row["EsFijo"].ToString();
                GrupoxRubro grupo = new GrupoxRubro(ID, ValorPorcentual, EsFijo, Cantidad, IdGrupo, IdRubro);
                grupos.Add(grupo);
            }
            return grupos;
        }

        public static List<GrupoxRubro> ver_grupoxrubro_grupo_nofijos(int @idGrupo)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand com = new SqlCommand("ver_grupoxrubro_grupo_nofijos", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@idGrupo", SqlDbType.Int).Value = @idGrupo;
            SqlDataAdapter adapt = new SqlDataAdapter(com);
            DataTable dataset = new DataTable();
            adapt.Fill(dataset);
            List<GrupoxRubro> grupos = new List<GrupoxRubro>();
            foreach (DataRow row in dataset.Rows)
            {
                int ID = int.Parse(row["ID"].ToString());
                int IdGrupo = int.Parse(row["IdGrupo"].ToString());
                int IdRubro = int.Parse(row["IdRubro"].ToString());
                int Cantidad = int.Parse(row["Cantidad"].ToString());
                decimal ValorPorcentual = decimal.Parse(row["ValorPorcentual"].ToString());
                string EsFijo = row["EsFijo"].ToString();
                GrupoxRubro grupo = new GrupoxRubro(ID, ValorPorcentual, EsFijo, Cantidad, IdGrupo, IdRubro);
                grupos.Add(grupo);
            }
            return grupos;
        }
         
        public static List<GrupoxEstudiante> ver_grupoxestudiante_grupo(int @idGrupo)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand com = new SqlCommand("ver_grupoxestudiante_grupo", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@idGrupo", SqlDbType.Int).Value = @idGrupo;
            SqlDataAdapter adapt = new SqlDataAdapter(com);
            DataTable dataset = new DataTable();
            adapt.Fill(dataset);
            List<GrupoxEstudiante> grupos = new List<GrupoxEstudiante>();
            foreach (DataRow row in dataset.Rows)
            {
                int ID = int.Parse(row["ID"].ToString());
                int IdGrupo = int.Parse(row["IdGrupo"].ToString());
                int IdEstadoGxE = int.Parse(row["IdEstadoGxE"].ToString());
                int IdEstudiante = int.Parse(row["IdEstudiante"].ToString());
                decimal NotaAcumulada = decimal.Parse(row["Nota"].ToString());
                GrupoxEstudiante grupo = new GrupoxEstudiante(ID,  NotaAcumulada, IdGrupo, IdEstadoGxE, IdEstudiante);
                grupos.Add(grupo);
            }
            return grupos;
        }

        public static List<Estudiante> verEstudiantes()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand com = new SqlCommand("verEstudiantes", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapt = new SqlDataAdapter(com);
            DataTable dataset = new DataTable();
            adapt.Fill(dataset);
            List<Estudiante> estudiantes = new List<Estudiante>();
            foreach (DataRow row in dataset.Rows)
            {
                int ID = int.Parse(row["ID"].ToString());
                string Contraseña = row["Contraseña"].ToString();
                string Nombre = row["Nombre"].ToString();
                string Apellido = row["Apellido"].ToString();
                string Correo = row["Correo"].ToString();
                string Carnet = row["Carnet"].ToString();
                string Telefono = row["Telefono"].ToString();
                Estudiante grupo = new Estudiante(ID, Nombre, Apellido,Telefono, Correo, Contraseña, Carnet);
                estudiantes.Add(grupo);
            }
            return estudiantes;
        }

        //VerNotas

        public static DataTable verNotas(int idEstudiante)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand com = new SqlCommand("ver_notas_estudiante", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@idEstudiante", SqlDbType.Int).Value = idEstudiante;
            SqlDataAdapter adapt = new SqlDataAdapter(com);
            DataTable dataset = new DataTable();
            adapt.Fill(dataset);
            return dataset;
        }

        public static DataTable ver_notas_estudiante_grupo(int idEstudiante, int idGrupo)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand com = new SqlCommand("ver_notas_estudiante_grupo", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@idEstudiante", SqlDbType.Int).Value = idEstudiante;
            com.Parameters.Add("@idGrupo", SqlDbType.Int).Value = idGrupo;
            SqlDataAdapter adapt = new SqlDataAdapter(com);
            DataTable dataset = new DataTable();
            adapt.Fill(dataset);
            return dataset;
        }


        public static string nombreProfesor(int @id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("nombreProfesor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = @id;
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dataset = new DataTable();
            adapt.Fill(dataset);
            List<string> nombre = new List<string>();
            foreach (DataRow row in dataset.Rows)
            {
                string Nota = row["Nombre"].ToString();
                nombre.Add(Nota);
            }
            return nombre[0];
        }

        public static void actualizar_grupo_nombre_codigo(int @idGrupo, string @NombreCurso, string @CodigoGrupo)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("actualizar_grupo_nombre_codigo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idGrupo", SqlDbType.Int).Value = @idGrupo;
            cmd.Parameters.Add("@NombreCurso", SqlDbType.VarChar).Value = @NombreCurso;
            cmd.Parameters.Add("@CodigoGrupo", SqlDbType.VarChar).Value = @CodigoGrupo;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }



    }
}
