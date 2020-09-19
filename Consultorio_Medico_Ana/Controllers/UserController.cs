using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ConsultorioMedico.Models.ViewModel;

namespace ConsultorioMedico.Controllers
{
    public class UserController : Controller
    {
        SessionData session = new SessionData();
        UsersDatos obj = new UsersDatos();
        // GET: User
        public ActionResult User()

        {
            ViewBag.User = session.getSession("nombre");
            if (ViewBag.User == "")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                caches();
                return View(obj.userDatos());

            }
        }
        public ActionResult Close()
        {
            session.destroySession();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.User = session.getSession("nombre");
            if (ViewBag.User == "")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                caches();
                return View(obj.editDatos(id));
            }
           
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult>Edit(UsersDatosModel model)
        {
            if (obj.actualizar(model) == true)
            {
                return RedirectToAction("User");
            }
            else
            {
                return View(model);
            }
        }
        public void caches()
        {
            Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Response.Cache.SetNoStore();
        }
        public ActionResult Details(int id)
        {
            ViewBag.User = session.getSession("nombre");
            if (ViewBag.User == "")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                caches();
                return View(obj.editDatos(id));
            }
        }
        public ActionResult Delete(int id)
        {
            ViewBag.User = session.getSession("nombre");
            if (ViewBag.User == "")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                caches();
                return View(obj.editDatos(id));
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Delete(UsersDatosModel model)
        {
            if (obj.eliminar(model) == true)
            {
                return RedirectToAction("User");
            }
            else
            {
                return View("User");
            }
        }
        public ActionResult create()
        {
            ViewBag.User = session.getSession("nombre");
            if (ViewBag.User == "")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                caches();
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> create(SigIn datos)
        {
            if (ModelState.IsValid)
            {
                if (datos.sigIn() == false)
                {
                    ViewBag.Message = "El usuario o el Email ya estan registrados";
                    return View("create", datos);
                }
                else
                {
                    return RedirectToAction("User");
                }
            }
            else
            {
                return View("create");
            }
        }
    }
    
}