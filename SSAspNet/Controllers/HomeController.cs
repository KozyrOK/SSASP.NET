using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSAspNet.Controllers
{
    public class MainController : Controller
    {
        public ActionResult MainControllerMethod()
        {
            return View("~/Views/Main/MainControllerMethod.cshtml");
        }

        public ActionResult MainInfoMethod()
        {
            return View("~/Views/Main/MainInfoMethod.cshtml");
        }
    }
}
