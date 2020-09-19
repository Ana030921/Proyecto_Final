using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultorioMedico.Models.ViewModel
{
    public class MantenimientoMedico
    {
       // public int Id_Medico { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Jornada { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Telefono_Oficina { get; set; }
    }
}