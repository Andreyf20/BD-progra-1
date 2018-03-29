using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace BDD1
{
    public class GrupoxEstudiante
    {
        public int ID;
        public decimal notaAcumulada;

        public int IdGrupo;
        public int IdEstadoGxE;
        public int IdEstudiante;

        public GrupoxEstudiante(int ID, decimal notaAcumulada, int IdGrupo, int idEstadoGxE, int IdEstudiante)
        {
            this.ID = ID;
            this.notaAcumulada = notaAcumulada;
            this.IdGrupo = IdGrupo;
            this.IdEstadoGxE = idEstadoGxE;
            this.IdEstudiante = IdEstudiante;
        }
    }
}