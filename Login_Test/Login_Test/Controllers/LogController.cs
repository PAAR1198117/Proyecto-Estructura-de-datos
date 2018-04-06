using Login_Test.Clases;
using Login_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace Login_Test.Controllers
{
    public class LogController : Controller
    {
        public registros historial_user = new registros();
        // GET: Log
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Sign_In (FormCollection collection)
        {
            try
            {
                var model = new Usuarios
                {
                    Nombre = collection["Nombre"],
                    Apellido = collection["Apellido"],
                    Edad = Convert.ToInt16(collection["Edad"]),
                    Username = collection["Username"],
                    Password = collection["Password"]

                };
                Data.Instance.usuarios.Add(model);
                var JSON_USER = "";

                foreach (var item in Data.Instance.usuarios)
                {
                    JSON_USER += item;
                }

                var JSON_USER2 = "";
                JSON_USER2 = JsonConvert.SerializeObject(Data.Instance.usuarios);

                historial_user.escribirArchivo(JSON_USER2);




                return View();
            }
                
            
            catch
            {

                return View();
            }
            
        }

  
        public ActionResult Log_In(FormCollection collection)
        {
            if (collection["Username"] == "admin" && collection["Password"] =="admin")
            {
                // Retornar la vista de controlador admin
                return View();
            }

            else
            {
                foreach (var item in Data.Instance.usuarios)
                {
                    if (item.Username == collection["Username"] && item.Password == collection["Password"])
                    {
                        return View();//menu guaflix para usuarios
                    }
                }
            }

            return View() /*usuario y contrasena incorrecta*/;
        }

    }
}