﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDD1
{
    public class Estudiante
    {
        public int ID;
        public string nombre;
        public string correo;
        public string contraseña;
        public string apellido;
        public string carnet;

        public Estudiante(int ID,string nombre, string apellido, string correo, string contraseña, string carnet)
        {
            this.ID = ID;
            this.nombre = nombre;
            this.apellido = apellido;
            this.contraseña = contraseña;
            this.correo = correo;
            this.carnet = carnet;
        }
    }
}