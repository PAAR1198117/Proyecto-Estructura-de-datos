﻿using System;
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
            }
            pelicula.OrderBy(x => x.Año);

            return View(pelicula);
        }
        public ActionResult ListaNombre()
        {

            List<Pelicula> pelicula = new List<Pelicula>();
            foreach (var item in Data1.Instance.Pelicula)
            {
                pelicula.Add(item);
            }
            pelicula.OrderBy(x => x.Nombre);

            return View(pelicula);
        }
        public ActionResult ListaTipo(string tipo)
        {

            List<Pelicula> pelicula = new List<Pelicula>();
            foreach (var item in Data1.Instance.Pelicula)
            {
                if (tipo == item.Tipo)
                {
                    pelicula.Add(item);
                }
            }
            pelicula.OrderBy(x => x.Nombre);

            return View(pelicula);
        }

        public ActionResult Menu()
        {
            return View();
        }
    }
}
