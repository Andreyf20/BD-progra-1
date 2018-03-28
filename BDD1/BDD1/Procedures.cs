﻿using System;
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

        public static void estadogrupo_borrar(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("estadogrupo_borrar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
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

        public static void estadogxe_borrar(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("estadogxe_borrar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
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

        public static void estudiante_borrar(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("estudiante_borrar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void estudiante_crear(string Nombre, string Apellido, string Telefono, string Correo, string Contraseña)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("estudiante_crear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
            cmd.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = Apellido;
            cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Telefono;
            cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Correo;
            cmd.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = Contraseña;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Evaluación

        public static void evaluacion_borrar(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("evaluacion_borrar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
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

        public static void evaluacionxestudiante_borrar(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("evaluacionxestudiante_borrar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void evaluacionxestudiante_cambiar_nota(int id, decimal Nota)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("evaluacionxestudiante_cambiar_nota", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@activo", SqlDbType.Decimal).Value = Nota;
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

        public static void grupo_borrar(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("grupo_borrar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void grupo_crear(int idEstado, int idPeriodo, int idPforesor, string NombreCurso, string CodigoGrupo)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("grupo_crear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idEstado", SqlDbType.Int).Value = idEstado;
            cmd.Parameters.Add("@idPeriodo", SqlDbType.Int).Value = idPeriodo;
            cmd.Parameters.Add("@idPforesor", SqlDbType.Int).Value = idPforesor;
            cmd.Parameters.Add("@NombreCurso", SqlDbType.VarChar).Value = NombreCurso;
            cmd.Parameters.Add("@CodigoGrupo", SqlDbType.VarChar).Value = CodigoGrupo;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Grupo x Estudiante

        public static void grupoxestudiante_actualizar_nota_acumulada(int id, decimal nota)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("grupoxestudiante_actualizar_nota_acumulada", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@nota", SqlDbType.Decimal).Value = nota;
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

        public static void grupoxrubro_crear(int idgrupo, int idRubro, decimal valorPorcentual, string esFijo, int cantidad)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("grupoxrubro_crear", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idgrupo", SqlDbType.Int).Value = idgrupo;
            cmd.Parameters.Add("@idRubro", SqlDbType.Int).Value = idRubro;
            cmd.Parameters.Add("@valorPorcentual", SqlDbType.Int).Value = valorPorcentual;
            cmd.Parameters.Add("@esFijo", SqlDbType.VarChar).Value = esFijo;
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

        //XML

        public static List<Estudiante> xmlEstudiantes()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand com = new SqlCommand("prueba_tabla", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapt = new SqlDataAdapter(com);
            DataTable dataset = new DataTable();
            adapt.Fill(dataset);
            List<Estudiante> estudiantes = new List<Estudiante>();
            foreach (DataRow row in dataset.Rows)
            {
                int ID = int.Parse(row["ID"].ToString());
                string Nombre = row["Nombre"].ToString();
                string Apellido = row["Apellido"].ToString();
                string Correo = row["Correo"].ToString();
                string Carnet = row["Carnet"].ToString();
                string Telefono = row["Telefono"].ToString();
                string Contraseña = row["Contraseña"].ToString();
                Estudiante estudiante = new Estudiante(ID, Nombre, Apellido, Correo, Contraseña, Carnet);
                estudiantes.Add(estudiante);
            }
            return estudiantes;
        }

        public static List<Profesor> xmlProfesores()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand com = new SqlCommand("prueba_tabla", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapt = new SqlDataAdapter(com);
            DataTable dataset = new DataTable();
            adapt.Fill(dataset);
            List<Profesor> profesores = new List<Profesor>();
            foreach (DataRow row in dataset.Rows)
            {
                int ID = int.Parse(row["id"].ToString());
                string Nombre = row["Nombre"].ToString();
                string Correo = row["Correo"].ToString();
                string Contraseña = row["Contraseña"].ToString();
                Profesor profesor = new Profesor(ID, Nombre, Correo, Contraseña);
                profesores.Add(profesor);
            }
            return profesores;
        }

        public static List<Periodo> xmlPeriodo()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand com = new SqlCommand("prueba_tabla", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapt = new SqlDataAdapter(com);
            DataTable dataset = new DataTable();
            adapt.Fill(dataset);
            List<Periodo> periodos = new List<Periodo>();
            foreach (DataRow row in dataset.Rows)
            {
                int ID = int.Parse(row["ID"].ToString());
                DateTime FechaInicio = DateTime.Parse( row["FechaInicio"].ToString());
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
            SqlCommand com = new SqlCommand("prueba_tabla", con);
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
            SqlCommand com = new SqlCommand("prueba_tabla", con);
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

        public static List<EstadoGrupoxEstudiante> xmlEstadoGXE()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand com = new SqlCommand("prueba_tabla", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapt = new SqlDataAdapter(com);
            DataTable dataset = new DataTable();
            adapt.Fill(dataset);
            List<EstadoGrupoxEstudiante> EGES = new List<EstadoGrupoxEstudiante>();
            foreach (DataRow row in dataset.Rows)
            {
                int ID = int.Parse(row["ID"].ToString());
                string Nombre = row["Nombre"].ToString();
                EstadoGrupoxEstudiante EGE = new EstadoGrupoxEstudiante(ID, Nombre);
                EGES.Add(EGE);
            }
            return EGES;
        }

        public static List<GrupoxRubro> xmlGrupoxRubro()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand com = new SqlCommand("prueba_tabla", con);
            com.CommandType = CommandType.StoredProcedure;
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
                Rubro rubro = BD.getRubro(IdRubro);
                GrupoxRubro grupo = new GrupoxRubro(ID, rubro, ValorPorcentual, EsFijo, Cantidad, IdGrupo, IdRubro);
                grupos.Add(grupo);
            }
            return grupos;
        }

        public static List<GrupoxEstudiante> xmlGrupoxEstudiante()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand com = new SqlCommand("prueba_tabla", con);
            com.CommandType = CommandType.StoredProcedure;
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
                decimal NotaAcumulada = decimal.Parse(row["NotaAcumulada"].ToString());
                EstadoGrupoxEstudiante estado = BD.getEstadoGrupoxEstudiante(IdEstadoGxE);
                Estudiante estudiante = BD.getEstudiante(IdEstudiante);
                GrupoxEstudiante grupo = new GrupoxEstudiante(ID, estado, NotaAcumulada, estudiante, IdGrupo, IdEstadoGxE, IdEstudiante);
                grupos.Add(grupo);
            }
            return grupos;
        }

        public static List<Evaluacion> xmlEvaluacion()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand com = new SqlCommand("prueba_tabla", con);
            com.CommandType = CommandType.StoredProcedure;
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

        public static List<EvaluacionxEstudiante> xmlEvaluacionxEstudiante()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5TPABM1;Initial Catalog=BBD1;Integrated Security=True");
            SqlCommand com = new SqlCommand("prueba_tabla", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapt = new SqlDataAdapter(com);
            DataTable dataset = new DataTable();
            adapt.Fill(dataset);
            List<EvaluacionxEstudiante> evaluaciones = new List<EvaluacionxEstudiante>();
            foreach (DataRow row in dataset.Rows)
            {
                int ID = int.Parse(row["ID"].ToString());
                int IdGrupoxEstudiante = int.Parse(row["IdGrupoxEstudiante"].ToString());
                int IdEvaluacion = int.Parse(row["IdEvaluacion"].ToString());
                decimal Nota = decimal.Parse(row["ValorPorcentual"].ToString());
                Evaluacion evaluacion = BD.getEvaluacion(IdEvaluacion);
                EvaluacionxEstudiante evaluacionxEstudiante = new EvaluacionxEstudiante(ID, Nota, evaluacion, IdEvaluacion, IdGrupoxEstudiante);
                evaluaciones.Add(evaluacionxEstudiante);
            }
            return evaluaciones;
        }

    }
}
