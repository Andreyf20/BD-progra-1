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
        public string activo;
        public List<Grupo> grupos;
        public static int cant = 0;

        public Periodo(int ID, DateTime fechaInicio, DateTime fechaFinal, string activo)
        {
            this.ID = ID;
            this.fechaFinal = fechaFinal;
            this.fechaInicio = fechaInicio;
            this.activo = activo;
            this.grupos = new List<Grupo>();
            cant++;
        }

        public Periodo( DateTime fechaInicio, DateTime fechaFinal, string activo)
        {
            this.ID = cant++;
            this.fechaFinal = fechaFinal;
            this.fechaInicio = fechaInicio;
            this.activo = activo;
            this.grupos = new List<Grupo>();
        }
    }
}