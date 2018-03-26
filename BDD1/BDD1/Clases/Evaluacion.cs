using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace BDD1
{
    public class Evaluacion
    {
        public int ID;
        public string nombre;
        public DateTime fecha;
        public int valorPorcentual;

        public Evaluacion( string Nombre, DateTime Fecha, int ValorPorcentual)
        {
            this.nombre = Nombre;
            this.fecha = Fecha;
            this.valorPorcentual = ValorPorcentual;
        }
    }
}