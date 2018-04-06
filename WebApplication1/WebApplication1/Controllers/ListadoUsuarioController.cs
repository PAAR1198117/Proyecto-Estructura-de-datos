using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult ListaFecha(int id)
        {

            return View();
        }

        // GET: ListadoUsuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListadoUsuario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ListadoUsuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ListadoUsuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ListadoUsuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ListadoUsuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
