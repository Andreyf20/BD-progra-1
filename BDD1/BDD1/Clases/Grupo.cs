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
        public int codigoGrupo;
        public List<GrupoxEstudiante> grupoxEstudiantes;
        public List<GrupoxRubro> grupoxRubros;

        public Grupo(string nombre)
        {
            nombreCurso = nombre; 
        }

    }
}