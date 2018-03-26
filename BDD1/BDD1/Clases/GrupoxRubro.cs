using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace BDD1
{
    public class GrupoxRubro
    {
        public int ID;
        public int valorPorcentual;
        public bool esFijo;
        public int cantidad;
        public Rubro rubro;
        public List<Evaluacion> evaluaciones = new List<Evaluacion>();
        

        public GrupoxRubro( Rubro rubro, int valorPorcentual, bool esFijo, int cantidad)
        {
            this.valorPorcentual = valorPorcentual;
            this.esFijo = esFijo;
            this.cantidad = cantidad;
            this.rubro = rubro;
        }
    }
}