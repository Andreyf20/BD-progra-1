using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDD1
{
    public class Periodo
    {
        public int ID;
        public DateTime fechaInicio;
        public DateTime fechaFinal;
        public int activo;
        public List<Grupo> grupos;
        public static int cantPeriodos=0;

        public Periodo(DateTime fechaInicio, DateTime fechaFinal)
        {
            this.ID = ++cantPeriodos;
            this.fechaFinal = fechaFinal;
            this.fechaInicio = fechaInicio;
            this.activo = 1;
            this.grupos = new List<Grupo>();
        }
        public void agregarGrupo(Grupo grupo)
        {
            grupos.Add(grupo);
        }
        public string toString()
        {
            string msg = "";
            msg += fechaInicio + ", " + fechaFinal;
            return msg;

        }
    }
}