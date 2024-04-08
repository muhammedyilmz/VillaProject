using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Villa.WebUI.ViewComponents.AdminLayout
{
    public class _AdminLogo : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}