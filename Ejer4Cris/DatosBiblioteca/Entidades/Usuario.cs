using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Cristhian Eduardo Cáceres Velásquez – 20201600006

namespace DatosBiblioteca.Entidades
{
    public class Usuario
    {
        public string Correo { get; set; }
        public string Clave { get; set; }


        public Usuario() { }

        public Usuario(string correo, string clave)
        {
            Correo = correo;
            Clave = clave;
        }



    }
}
