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

        public int idGrupo;
        public int idRubro;
        

        public GrupoxRubro( int ID,  decimal valorPorcentual, string esFijo, int cantidad, int idGrupo, int idRubro)
        {
            this.ID = ID;
            this.valorPorcentual = valorPorcentual;
            this.esFijo = esFijo;
            this.cantidad = cantidad;
            this.idGrupo = idGrupo;
            this.idRubro = idRubro;
        }

    }
}