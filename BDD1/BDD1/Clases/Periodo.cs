using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDD1
{
    public class Periodo
    {
        int ID;
        DateTime fechaInicio;
        DateTime fechaFinal;
        bool activo;
        List<Grupo> grupos;
    }
}