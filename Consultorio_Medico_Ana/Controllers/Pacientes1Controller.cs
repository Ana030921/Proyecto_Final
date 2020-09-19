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
    public class PacientesController : Controller
    {
        // GET: Pacientes
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(MantenimientoPacientes model)
        {
            try
            {
                using (DB_Consultorio_MedicoEntities db = new DB_Consultorio_MedicoEntities())
                {
                    Paciente pa = new Paciente();
                    pa.Carnet = model.Carnet;
                    pa.Nombre = model.Nombre;
                    pa.Apellidos = model.Apellidos;
                    pa.Direccion = model.Direccion;
                    pa.Telefono = model.Telefono;
                    pa.Sexo = model.Sexo;
                    pa.Fecha_Nacimiento = DateTime.Now;
                    db.Pacientes.Add(pa);
                    db.SaveChanges();
                }
                ViewBag.Message="Registro Insertado Correctamente";
                return View();
            }
            catch (Exception ex)
            {

                return View(model);
            }
        }
    }
}