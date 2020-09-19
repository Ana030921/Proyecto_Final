using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultorioMedico.Models.ViewModel
{
    public class MantenimientoPacientes
    {
       // public int Id_Paciente { get; set; }
        public string Carnet { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
      //  public DateTime Fecha_Nacimiento { get; set; }
    }
}