using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultorioMedico.Models.ViewModel
{
    public class SessionData
    {
        private string session;
        public String getSession(String nombre)
        {
            this.session = Convert.ToString(HttpContext.Current.Session[nombre]);
            return session;
        }
        public void setSession(String nombre,string data)
        {
            HttpContext.Current.Session[nombre] = data;

        }
        public void destroySession()
        {
            HttpContext.Current.Session.Abandon();
        }
    }
}