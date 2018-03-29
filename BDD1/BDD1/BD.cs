using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDD1
{
    public  class BD
    {
        public static List<Estudiante> estudiantes = new List<Estudiante>();
        public static List<Profesor> profesores = new List<Profesor>();
        public static List<Periodo> periodos = new List<Periodo>();
        public static List<Rubro> rubros = new List<Rubro>();
        public static List<EstadoGrupo> estadosGrupo = new List<EstadoGrupo>();
        public static List<EstadoGrupoxEstudiante> estadoGruposxEstudiante = new List<EstadoGrupoxEstudiante>();
        public static List<GrupoxRubro> gruposxRubro = new List<GrupoxRubro>();
        public static List<GrupoxEstudiante> gruposxEstudiante = new List<GrupoxEstudiante>();
        public static List<Evaluacion> evaluaciones = new List<Evaluacion>();
        public static List<EvaluacionxEstudiante> evaluacionesxEstudiante = new List<EvaluacionxEstudiante>();

        public BD()
        {
            //estudiantes = Procedures.xmlEstudiantes();
            //profesores = Procedures.xmlProfesores();
            periodos = Procedures.xmlPeriodosActivos();
            //rubros = Procedures.xmlRubros();
            //estadosGrupo = Procedures.xmlEstadoGrupo();
            //estadoGruposxEstudiante = Procedures.xmlEstadoGXE();
            //gruposxRubro = Procedures.xmlGrupoxRubro();
            //gruposxEstudiante = Procedures.xmlGrupoxEstudiante();
            //evaluaciones = Procedures.xmlEvaluacion();
            //evaluacionesxEstudiante = Procedures.xmlEvaluacionxEstudiante();
        }

        internal static EstadoGrupo getEstadoGrupo(int id)
        {
            return estadosGrupo[id];
        }

        internal static Rubro getRubro(int id)
        {
            return rubros[id];
        }

        internal static EstadoGrupoxEstudiante getEstadoGrupoxEstudiante(int id)
        {
            return estadoGruposxEstudiante[id];
        }

        internal static Estudiante getEstudiante(int id)
        {
            return estudiantes[id];
        }

        internal static Evaluacion getEvaluacion(int id)
        {
            return evaluaciones[id];
        }
    }
}