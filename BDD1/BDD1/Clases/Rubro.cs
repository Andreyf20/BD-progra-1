namespace BDD1
{
    public class Rubro
    {
        int ID;
        public string nombre;
        static int cantidadRubros=0;

        public Rubro(string nombre)
        {
            this.ID = cantidadRubros++;
            this.nombre = nombre;
        }
    }
}