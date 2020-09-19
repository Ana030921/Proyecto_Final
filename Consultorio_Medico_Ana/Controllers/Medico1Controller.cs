using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsultorioMedico.Models.ViewModel;
using ConsultorioMedico.Models;
using Consultorio_Medico_Ana.Models;

namespace ConsultorioMedico.Controllers
{
    public class MedicoController : Controller
    {
        // GET: Medico
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(MantenimientoMedico model)
        {
            try
            {

                using (DB_Consultorio_MedicoEntities db = new DB_Consultorio_MedicoEntities()) 
                {
                    Medico me = new Medico();
                    me.Nombre = model.Nombre;
                    me.Apellidos = model.Apellidos;
                    me.Direccion = model.Direccion;
                    me.Jornada = model.Jornada;
                    me.Telefono = model.Telefono;
                    me.Celular = model.Celular;
                    me.Telefono_Oficina = me.Telefono_Oficina;
                    db.Medicos.Add(me);
                    db.SaveChanges();
                }
                ViewBag.Message="Registro Insertado Correctamente";
                return View();
            }
            catch (Exception ex )
            {

                return View(model);
            }
            
        }
    }
}