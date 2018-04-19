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
        //declaracion de arboles
        static BPTree<peliculas> nshow = new BPTree<peliculas>(4,4,3);
        static BPTree<peliculas> yshow = new BPTree<peliculas>(4, 4, 3);
        static BPTree<peliculas> gshow = new BPTree<peliculas>(4, 4, 3);
        static BPTree<peliculas> nmovie = new BPTree<peliculas>(4, 4, 3);
        static BPTree<peliculas> ymovie= new BPTree<peliculas>(4, 4, 3);
        static BPTree<peliculas> gmovie = new BPTree<peliculas>(4, 4, 3);
        static BPTree<peliculas> ndoc = new BPTree<peliculas>(4, 4, 3);
        static BPTree<peliculas> ydoc = new BPTree<peliculas>(4, 4, 3);
        static BPTree<peliculas> gdoc = new BPTree<peliculas>(4, 4, 3);
        //fin declaracion de arboles
        public ActionResult Importar()
        {
            return View(Data1.Instance.Pelicula);
        }        
        [HttpPost]
        public ActionResult Importar(HttpPostedFileBase postedFile)
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
                    //aqui tengo que ingresar datos al arbol pero no se como 
                    peliculas toadd = new peliculas(item.Value.Nombre, item.Value.Tipo, item.Value.Año, item.Value.Genero,0);
                    if (item.Value.Tipo == "Show")
                    {
                        nshow.insetNode(toadd, 0);
                        yshow.insetNode(toadd, 1);
                        gshow.insetNode(toadd, 2);
                    }
                    if (item.Value.Tipo == "Pelicula")
                    {
                        nmovie.insetNode(toadd, 0);
                        ymovie.insetNode(toadd, 1);
                        gmovie.insetNode(toadd, 2);
                    }
                    if (item.Value.Tipo == "Documental")
                    {
                        ndoc.insetNode(toadd, 0);
                        ydoc.insetNode(toadd, 1);
                        gdoc.insetNode(toadd, 2);
                    }
                }
            }
            return RedirectToAction("Importar");
        }
    }
}