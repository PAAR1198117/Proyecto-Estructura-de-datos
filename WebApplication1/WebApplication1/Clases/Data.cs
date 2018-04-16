using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Clases
{
    public class Data1
    {
        private static Data1 instance;
        public static Data1 Instance
        {
            get
            {
                if (instance == null) instance = new Data1();
                return instance;
            }
        }

        public List<Pelicula> Pelicula;

        public Data1()
        {
            Pelicula = new List<Pelicula>();
        }
    }
}