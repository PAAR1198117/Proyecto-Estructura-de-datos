using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Login_Test.Models;

namespace Login_Test.Clases
{
    public class Data
    {
        private static Data instance;
        public static Data Instance
        {
            get
            {
                if (instance == null) instance = new Data();
                return instance;
            }
        }

        public List<Usuarios> usuarios;

        public Data()
        {
            usuarios = new List<Usuarios>();

            //if (usuarios == null)
            //{
            //    var administrador = new Log_In
            //    {
            //        Apellido = "admin",
            //        Nombre = "admin",
            //        Username = "admin",
            //        Password = "admin",
            //        Edad = 21
            //    };
            //    usuarios.Add(administrador);
            //}
        }
    }
}