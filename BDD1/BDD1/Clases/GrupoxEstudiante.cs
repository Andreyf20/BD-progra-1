using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace BDD1
{
    public class GrupoxEstudiante
    {
        int ID;
        EstadoGrupoxEstudiante estado;
        int notaAcumulada;
        Estudiante estudiante;
        List<EvaluacionxEstudiante> evaluacionxEstudiantes;
    }
}