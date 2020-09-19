using ConsultorioMedico.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Consultorio_Medico_Ana.Controllers
{
    
    public class HomeController : Controller
    {
        SessionData session = new SessionData();
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
           // ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
           // ViewBag.Message = "Pagina de Contacto.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Usuario()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Usuario(UserLogin datos)
        {

            if (ModelState.IsValid)
            {
                if (datos.login() == true)
                {
                    session.setSession("nombre", datos.Nombre);
                    ViewBag.User = session.getSession("nombre");
                    return View();
                }
                else
                {
                    ViewBag.Message = "Error";
                    return View("Home");
                }

            }
            else
            {
                return View("Home");
            }
        }
        [AllowAnonymous]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SignIn(SigIn datos)
        {
            if (ModelState.IsValid)
            {
                if (datos.sigIn() == false)
                {
                    ViewBag.Message = "El usuario o el Email ya estan registrados";
                    return View("SignIn", datos);
                }
                else
                {
                    return RedirectToAction("Home", "Home");
                }
            }
            else
            {
                return View("SingnIn");
            }
        }

    }
}