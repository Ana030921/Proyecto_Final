﻿using System.Web;
using System.Web.Mvc;

namespace Consultorio_Medico_Ana
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}