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
    public class ListadoController : Controller
    {
        // GET: Listado
        public ActionResult Index()
        {
            //tratar hacer log in aqui
            return View(Data1.Instance.Pelicula);
        }

        // GET: Listado/Details/5
        public ActionResult Details(string nombre)
        {
            var model = Data1.Instance.Pelicula.FirstOrDefault(x => x.Nombre == nombre);
            return View(model);
        }

        // GET: Listado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Listado/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                var model = new Pelicula
                {
                    Nombre = collection["Nombre"],
                    Tipo = collection["Tipo"],
                    Genero = collection["genero"],
                    Año = Convert.ToInt16(collection["lanzamiento"])
                };
                Data1.Instance.Pelicula.Add(model);
                return RedirectToAction("Importar");
            }
            catch
            {
                return View();
            }
        }

        // GET: Listado/Edit/5
        public ActionResult Edit(string nombre)
        {
            var model = Data1.Instance.Pelicula.FirstOrDefault(x => x.Nombre == nombre);
            return View(model);
        }

        // POST: Listado/Edit/5
        [HttpPost]
        public ActionResult Edit(string nombre, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var model = new Pelicula
                {
                    Nombre = collection["Nombre"],
                    Tipo = collection["Tipo"],
                    Genero = collection["genero"],
                    Año = Convert.ToInt16(collection["lanzamiento"])
                };
                Data1.Instance.Pelicula.Remove(Data1.Instance.Pelicula.First(x => x.Nombre == nombre));
                Data1.Instance.Pelicula.Add(model);
                return RedirectToAction("Importar");
            }
            catch
            {
                return View();
            }
        }

        // GET: Listado/Delete/5
        public ActionResult Delete(string nombre)
        {
            var model = Data1.Instance.Pelicula.FirstOrDefault(x => x.Nombre == nombre);
            return View();
        }

        // POST: Listado/Delete/5
        [HttpPost]
        public ActionResult Delete(string nombre, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                Data1.Instance.Pelicula.Remove(Data1.Instance.Pelicula.First(x => x.Nombre == nombre));
                //datos del delete
                var model = new Pelicula
                {
                    Nombre = collection["Nombre"],
                    Tipo = collection["Tipo"],
                    Genero = collection["genero"],
                    Año = Convert.ToInt16(collection["lanzamiento"])
                };
                return RedirectToAction("Importar");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Importar()
        {
            return View(Data1.Instance.Pelicula);
        }

        [HttpPost]
        public ActionResult Importar(HttpPostedFileBase postedFile, int id)
        {
            string filePath = string.Empty;
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);

                string JSON_DATA = System.IO.File.ReadAllText(filePath);
                var pelicula = Pelicula.FromJson(JSON_DATA);

                foreach (var item in pelicula)
                {
                    Data1.Instance.Pelicula.Add(new Pelicula
                    {
                        Nombre = item.Value.Nombre,
                        Año = item.Value.Año,
                        Genero = item.Value.Genero,
                        Tipo = item.Value.Tipo
                    });
                }
 
            }
            if (id == 1)
            {
                return RedirectToAction("Log_In", "Log");
            }
            return RedirectToAction("Importar");
        }
    }
}