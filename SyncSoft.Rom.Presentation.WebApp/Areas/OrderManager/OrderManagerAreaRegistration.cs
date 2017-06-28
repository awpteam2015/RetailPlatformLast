﻿using System.Web.Mvc;

namespace SyncSoft.Rom.Presentation.WebApp.Areas.OrderManager
{
    public class OrderManagerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "OrderManager";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "OrderManager_default",
                "OrderManager/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}