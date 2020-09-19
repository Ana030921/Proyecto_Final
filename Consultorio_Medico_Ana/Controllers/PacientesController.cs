using Consultorio_Medico_Ana.Models.ViewModel;
using ConsultorioMedico.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Consultorio_Medico_Ana.Controllers
{
    public class PacientesController : Controller
    {
        // GET: Pacientes
        SessionData session = new SessionData();
        PacienteDatos obj = new PacienteDatos();
        public ActionResult Paciente()
        {
            ViewBag.User = session.getSession("nombre");
            if (ViewBag.User == "")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                caches();
                return View(obj.PacientesDatos());

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
        public async Task<ActionResult> Edit(PacienteDatosModel model)
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
        public async Task<ActionResult> Delete(PacienteDatosModel model)
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
                    ViewBag.Message = "El Paciente ya estan registrados";
                    return View("create", datos);
                }
                else
                {
                    return RedirectToAction("Paciente");
                }
            }
            else
            {
                return View("create");
            }
        }


        public void caches()
        {
            Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Response.Cache.SetNoStore();
        }
    }
}