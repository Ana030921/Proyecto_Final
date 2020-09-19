using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consultorio_Medico_Ana.Models.ViewModel
{
    public class MedicoDatos
    {
        DB_Consultorio_MedicoEntities medico = new DB_Consultorio_MedicoEntities();
        public List<MedicoDatosModel> MedicosDatos()
        {
            List<MedicoDatosModel> List = new List<MedicoDatosModel>();
            var query = from u in medico.Medicos select u;
            var listData = query.ToList();
            foreach (var Data in listData)
            {
                List.Add(new MedicoDatosModel()
                {
                    Id_Medico = Data.Id_Medico,
                    Nombre = Data.Nombre,
                    Apellidos = Data.Apellidos,
                    Direccion = Data.Direccion,
                    Jornada = Data.Jornada,
                    Telefono=Data.Telefono,
                    Celular=Data.Celular,
                    Telefono_Oficina=Data.Telefono_Oficina
                    
                });
            }
            return List;

        }
        public MedicoDatosModel editDatos(int id)
        {
            MedicoDatosModel datos = medico.Medicos.Where(x => x.Id_Medico == id).Select(x => new MedicoDatosModel()
            {
                Id_Medico = x.Id_Medico,
                Nombre = x.Nombre,
                Apellidos = x.Apellidos,
                Direccion = x.Direccion,
                Jornada=x.Jornada,
                Telefono=x.Telefono,
                Celular=x.Celular,
                Telefono_Oficina=x.Telefono_Oficina
            }).SingleOrDefault();
            return datos;

        }
        public bool actualizar(MedicoDatosModel model)
        {
            Medico u = medico.Medicos.Where(x => x.Id_Medico == model.Id_Medico).Single<Medico>();
            u.Nombre = model.Nombre;
            u.Apellidos = model.Apellidos;
            u.Direccion = model.Direccion;
            u.Jornada = model.Jornada;
            u.Telefono = model.Telefono;
            u.Celular = model.Celular;
            u.Telefono_Oficina = model.Telefono;
            medico.SaveChanges();
            return true;
        }
        public bool eliminar(MedicoDatosModel model)
        {
            Medico u = medico.Medicos.Where(x => x.Id_Medico == model.Id_Medico).Single<Medico>();
            medico.Medicos.Remove(u);
            medico.SaveChanges();
            return true;
        }

    }

    public class MedicoDatosModel
    {
        public int Id_Medico { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Jornada { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Telefono_Oficina { get; set; }

    }
}
