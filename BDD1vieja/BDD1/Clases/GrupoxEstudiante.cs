using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace BDD1
{
    public class GrupoxEstudiante
    {
        public int ID;
        public EstadoGrupoxEstudiante estado;
        public decimal notaAcumulada;
        public Estudiante estudiante;
        public List<EvaluacionxEstudiante> evaluacionxEstudiantes;

        int IdGrupo;
        int IdEstadoGxE;
        int IdEstudiante;

        public GrupoxEstudiante(int ID, EstadoGrupoxEstudiante estado, decimal notaAcumulada, Estudiante estudiante, int IdGrupo, int idEstadoGxE, int IdEstudiante)
        {
            this.ID = ID;
            this.estado = estado;
            this.notaAcumulada = notaAcumulada;
            this.estudiante = estudiante;
            this.IdGrupo = IdGrupo;
            this.IdEstadoGxE = idEstadoGxE;
            this.IdEstudiante = IdEstudiante;
        }
    }
}