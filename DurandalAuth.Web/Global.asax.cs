﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Web.Optimization;

namespace DurandalAuth.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(RouteConfig.RegisterWebApiRoutes);
            RouteConfig.RegisterMVCRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterMVCAuth(GlobalFilters.Filters);
            AuthConfig.RegisterWebApiAuth(GlobalConfiguration.Configuration);

        }
    }
}