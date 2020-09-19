using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Consultorio_Medico_Ana.Models;

namespace ConsultorioMedico.Models.ViewModel
{
    public class UsersDatos
    {
        DB_Consultorio_MedicoEntities usuario = new DB_Consultorio_MedicoEntities();

        public List<UsersDatosModel> userDatos()
        {
            List<UsersDatosModel> List = new List<UsersDatosModel>();
            var query = from u in usuario.Usuarios select u;
            var listData = query.ToList();
            foreach (var Data in listData)
            {
                List.Add(new UsersDatosModel()
                {
                    Id_Usuario = Data.Id_Usuario,
                    Nombre = Data.Nombre,
                    Email = Data.Email,
                    Clave = Data.Clave,
                    Estado=Data.Estado,
                    Id_Medico=Convert.ToInt32(Data.Id_Medico)   
                    
                });
            }
            return List;
                        
        }
        public UsersDatosModel editDatos(int id)
        {
            UsersDatosModel datos = usuario.Usuarios.Where(x => x.Id_Usuario == id).Select(x => new UsersDatosModel()
            {
                Id_Usuario = x.Id_Usuario,
                Nombre = x.Nombre,
                Clave = x.Clave,
                Email = x.Email
               // Estado=x.Estado
               // Id_Medico=x.Id_Medico
            }).SingleOrDefault();
            return datos;
            
         }
        public bool actualizar(UsersDatosModel model)
        {
            Usuario u = usuario.Usuarios.Where(x => x.Id_Usuario == model.Id_Usuario).Single<Usuario>();
            u.Nombre = model.Nombre;
            u.Clave = model.Clave;
            u.Email = model.Email;
            usuario.SaveChanges();
            return true;
        }
        public bool eliminar(UsersDatosModel model)
        {
            Usuario u = usuario.Usuarios.Where(x => x.Id_Usuario == model.Id_Usuario).Single<Usuario>();
            usuario.Usuarios.Remove(u);
            usuario.SaveChanges();
            return true;
        }

    }

         public class UsersDatosModel
            {
             public int Id_Usuario { get; set; }
             public string Nombre { get; set; }
             public string Clave { get; set; }
             public string Email { get; set; }
             public string Estado { get; set; }
             public int Id_Medico { get; set; }

              }


}