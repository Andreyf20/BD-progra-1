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
        public float notaAcumulada;
        public Estudiante estudiante;
        public List<EvaluacionxEstudiante> evaluacionxEstudiantes;

        public GrupoxEstudiante(float notaAcumulada, Estudiante estudiante)
        {
            this.notaAcumulada = notaAcumulada;
            this.estudiante = estudiante;

        }
    }
}