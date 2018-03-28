using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDD1
{
    public class Grupo
    {
        public int ID;
        public string nombreCurso;
        public EstadoGrupo estado;
        public string codigoGrupo;
        public List<GrupoxEstudiante> grupoxEstudiantes = new List<GrupoxEstudiante>();
        public List<GrupoxRubro> grupoxRubros= new List<GrupoxRubro>();
        public static int cant = 0;

        public int idEstado;
        public int idPeriodo;
        public int idProfesor;

        public Grupo(int ID,string nombre , string codigoGrupo, EstadoGrupo estado, int idEstado, int idPeriodo, int idProfesor)
        {
            this.codigoGrupo = codigoGrupo;
            this.nombreCurso = nombre;
            this.ID = ID;
            this.estado = estado;
            this.idEstado = idEstado;
            this.idPeriodo = idPeriodo;
            this.idProfesor = idProfesor;
            cant++;
        }
        public Grupo(int idEstado, int idPeriodo, int idPforesor, string NombreCurso, string CodigoGrupo)
        {
            this.ID = cant++;
            this.idEstado = idEstado;
            this.idPeriodo = idPeriodo;
            this.idProfesor = idPforesor;
            this.nombreCurso = NombreCurso;
            this.codigoGrupo = CodigoGrupo;
            this.estado = BD.getEstadoGrupo(idEstado);
        }

    }
}