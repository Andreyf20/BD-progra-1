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
        public decimal valorPorcentual;
        public string descripcion;

        public int idGrupoxRubro;

        public Evaluacion(int id, int idGrupoxRubro, string Nombre, DateTime Fecha, decimal ValorPorcentual, string descripcion)
        {
            this.ID = id;
            this.idGrupoxRubro = idGrupoxRubro;
            this.nombre = Nombre;
            this.fecha = Fecha;
            this.valorPorcentual = ValorPorcentual;
            this.descripcion = descripcion;
        }
        
    }
}