using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Consultorio_Medico_Ana.Models;

namespace ConsultorioMedico.Models.ViewModel
{
    public class SigIn
    {

        [Required(ErrorMessage = "<font color='red' >El Nombre es requerido</font>")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [StringLength(100, ErrorMessage = "El numero de caracteres de{0} debe ser al menos{2}.</font>", MinimumLength = 3)]
        [Required(ErrorMessage = "<font color='red' >La Contraseña es requerida</font>")]
        [Display(Name = "Contraseña")]
        public string Clave { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "<font color='red' >El Email es requerido</font>")]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }


        public string Estado { get; set; }


        public int Id_Medico { get; set; }

        DB_Consultorio_MedicoEntities usuario = new DB_Consultorio_MedicoEntities();
        
        Usuario us = new Usuario();

        public bool sigIn()
        {
            var query = from u in usuario.Usuarios
                        where u.Email == Email || u.Nombre == Nombre
                        select u;
            if (query.Count() > 0)
            {
                return false;

            }
            else
            {
                us.Nombre = Nombre;
                us.Clave = Clave;
                us.Email = Email;
                usuario.Usuarios.Add(us);
                usuario.SaveChanges();
                return true;
            }

        }
    }
}