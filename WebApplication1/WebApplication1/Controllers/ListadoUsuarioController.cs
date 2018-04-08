using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Clases;
using WebApplication1.Models;

namespace WebApplication1.Controllers
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
            foreach (var item in Data.Instance.Pelicula)
            {
                pelicula.Add(item);
            }
            pelicula.OrderBy(x => x.Año);

            return View(pelicula);
        }
        public ActionResult ListaNombre()
        {

            List<Pelicula> pelicula = new List<Pelicula>();
            foreach (var item in Data.Instance.Pelicula)
            {
                pelicula.Add(item);
            }
            pelicula.OrderBy(x => x.Año);

            return View(pelicula);
        }
        public ActionResult ListaTipo(string tipo)
        {

            List<Pelicula> pelicula = new List<Pelicula>();
            foreach (var item in Data.Instance.Pelicula)
            {
                if (tipo == item.Tipo)
                {
                    pelicula.Add(item);
                }
            }
            pelicula.OrderBy(x => x.Año);

            return View(pelicula);
        }

        public ActionResult Menu(int ID)
        {
            if (ID == 1)
            {
                //vista decha
                return View();
            }
            if (ID == 2)
            {
                //vista nombre
                return View();
            }
            if (ID == 3)
            {
                //vista tipo
                return View();
            }
            return View();
        }
    }
}
