using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDD1
{
    public class Profesor
    {
        public int ID;
        public string nombre;
        public string correo;
        public string contraseña;

        public  Profesor(int ID, string nombre, string correo, string contraseña)
        {
            this.ID = ID;
            this.nombre = nombre;
            this.contraseña = contraseña;
            this.correo = correo;
        }
    }
}