using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace BDD1
{
    public class GrupoxRubro
    {
        public int ID;
        public decimal valorPorcentual;
        public string esFijo;
        public int cantidad;
        public Rubro rubro;
        public List<Evaluacion> evaluaciones = new List<Evaluacion>();

        public static int cant = 0;

        public int idGrupo;
        public int idRubro;
        

        public GrupoxRubro( int ID, Rubro rubro, decimal valorPorcentual, string esFijo, int cantidad, int idGrupo, int idRubro)
        {
            this.ID = ID;
            this.valorPorcentual = valorPorcentual;
            this.esFijo = esFijo;
            this.cantidad = cantidad;
            this.rubro = rubro;
            this.idGrupo = idGrupo;
            this.idRubro = idRubro;
            cant++;
        }
        public GrupoxRubro( decimal valorPorcentual, string esFijo, int cantidad, int idGrupo, int idRubro)
        {
            this.ID = cant++;
            this.valorPorcentual = valorPorcentual;
            this.esFijo = esFijo;
            this.cantidad = cantidad;
            this.rubro = BD.getRubro(idRubro);
            this.idGrupo = idGrupo;
            this.idRubro = idRubro;
        }

    }
}