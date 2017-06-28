﻿using System.Web.Mvc;

namespace SyncSoft.Rom.Presentation.WebApp.Areas.PermissionManager
{
    public class PermissionManagerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PermissionManager";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PermissionManager_default",
                "PermissionManager/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}