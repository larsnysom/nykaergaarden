﻿using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Nykaergaarden.Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();

            new AppHost().Init();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}