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
        public string codigoGrupo;

        public int idEstado;
        public int idPeriodo;
        public int idProfesor;

        public Grupo(int ID,string nombre , string codigoGrupo,  int idEstado, int idPeriodo, int idProfesor)
        {
            this.codigoGrupo = codigoGrupo;
            this.nombreCurso = nombre;
            this.ID = ID;
            this.idEstado = idEstado;
            this.idPeriodo = idPeriodo;
            this.idProfesor = idProfesor;
        }

    }
}