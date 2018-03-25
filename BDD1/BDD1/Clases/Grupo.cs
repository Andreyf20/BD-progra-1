﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDD1
{
    public class Grupo
    {
        public int ID;
        public string horaInicio;
        public string horaFinal;
        public string aula;
        public string nombreCurso;
        public EstadoGrupo estado;
        public string codigoGrupo;
        public List<GrupoxEstudiante> grupoxEstudiantes = new List<GrupoxEstudiante>();
        public List<GrupoxRubro> grupoxRubros= new List<GrupoxRubro>();
        public static int cantidadGrupos = 0;

        public Grupo(string nombre , string horaInicio, string horaFinal,string aula, string codigoGrupo)
        {
            this.codigoGrupo = codigoGrupo;
            this.nombreCurso = nombre;
            this.aula = aula;
            this.horaFinal = horaFinal;
            this.horaInicio = horaInicio;
            this.ID = ++cantidadGrupos;

        }

    }
}