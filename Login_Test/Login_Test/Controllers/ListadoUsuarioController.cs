using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login_Test.Clases;
using Login_Test.Models;

namespace Login_Test.Controllers
{
    public class ListadoUsuarioController : Controller
    {
        // GET: ListadoUsuario
        public ActionResult Index2()
        {
            return View();
        }

        // GET: ListadoUsuario/Details/5
        public ActionResult ListaFecha()
        {

            List<Pelicula> pelicula = new List<Pelicula>();
            foreach (var item in Data1.Instance.Pelicula)
            {
                pelicula.Add(item);
            };
            pelicula.Sort();
            return View(pelicula.OrderBy(x => x.Año));
        }
        public ActionResult ListaNombre()
        {

            List<Pelicula> pelicula = new List<Pelicula>();
            foreach (var item in Data1.Instance.Pelicula)
            {
                pelicula.Add(item);
            }
            ;

            return View(pelicula.OrderBy(x => x.Nombre));
        }
        public ActionResult ListaDocumental()
        {

            List<Pelicula> pelicula = new List<Pelicula>();
            foreach (var item in Data1.Instance.Pelicula)
            {
                if ("Documental" == item.Tipo)
                {
                    pelicula.Add(item);
                }
            };

            return View(pelicula.OrderBy(x => x.Nombre));
        }

        public ActionResult ListaPelicula()
        {

            List<Pelicula> pelicula = new List<Pelicula>();
            foreach (var item in Data1.Instance.Pelicula)
            {
                if ("Pelicula" == item.Tipo)
                {
                    pelicula.Add(item);
                }
            };

            return View(pelicula.OrderBy(x => x.Nombre));
        }
        public ActionResult ListaShow()
        {

            List<Pelicula> pelicula = new List<Pelicula>();
            foreach (var item in Data1.Instance.Pelicula)
            {
                if ("Show" == item.Tipo)
                {
                    pelicula.Add(item);
                }
            };

            return View(pelicula.OrderBy(x => x.Nombre));
        }
        static List<Pelicula> Fav = new List<Pelicula>();

        public ActionResult ListaWachlist(string id)
        {
            var model = Data1.Instance.Pelicula.FirstOrDefault(x => x.Nombre == id);
            Fav.Add(model);
            return View(Fav.OrderBy(x => x.Nombre));
        }
        public ActionResult Menu()
        {
            return View();
        }
    }
}
