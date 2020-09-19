using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consultorio_Medico_Ana.Models.ViewModel
{
    public class PacienteDatos
    {
        DB_Consultorio_MedicoEntities paciente = new DB_Consultorio_MedicoEntities();

        public List<PacienteDatosModel> PacientesDatos()
        {
            List<PacienteDatosModel> List = new List<PacienteDatosModel>();
            var query = from u in paciente.Pacientes select u;
            var listData = query.ToList();
            foreach (var Data in listData)
            {
                List.Add(new PacienteDatosModel()
                {
                    Id_Paciente = Data.Id_Paciente,
                    Carnet = Data.Carnet,
                    Nombre = Data.Nombre,
                    Apellidos = Data.Apellidos,
                    Direccion = Data.Direccion,
                    Telefono = Data.Telefono,
                    Sexo=Data.Sexo,
                    Fecha_Nacimiento=Data.Fecha_Nacimiento

                });
            }
            return List;

        }
        public PacienteDatosModel editDatos(int id)
        {
            PacienteDatosModel datos = paciente.Pacientes.Where(x => x.Id_Paciente == id).Select(x => new PacienteDatosModel()
            {
                Id_Paciente = x.Id_Paciente,
                Carnet=x.Carnet,
                Nombre = x.Nombre,
                Apellidos=x.Apellidos,
                Direccion = x.Direccion,
                Telefono = x.Telefono,
                Sexo=x.Sexo,
                Fecha_Nacimiento=x.Fecha_Nacimiento
            }).SingleOrDefault();
            return datos;

        }
        public bool actualizar(PacienteDatosModel model)
        {
            Paciente u = paciente.Pacientes.Where(x => x.Id_Paciente == model.Id_Paciente).Single<Paciente>();
            u.Carnet = model.Carnet;
            u.Nombre = model.Nombre;
            u.Apellidos = model.Apellidos;
            u.Direccion = model.Direccion;
            u.Telefono = model.Telefono;
            u.Sexo = model.Sexo;
            u.Fecha_Nacimiento = model.Fecha_Nacimiento;
            paciente.SaveChanges();
            return true;
        }
        public bool eliminar(PacienteDatosModel model)
        {
            Paciente u = paciente.Pacientes.Where(x => x.Id_Paciente == model.Id_Paciente).Single<Paciente>();
            paciente.Pacientes.Remove(u);
            paciente.SaveChanges();
            return true;
        }

    }

    public class PacienteDatosModel
    {
        public int Id_Paciente { get; set; }
        public string Carnet { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
        public Nullable<System.DateTime> Fecha_Nacimiento { get; set; }

    }
}
