using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TKWeb.Controllers
{
    public class ContactusController : Controller
    {
        // GET: Contactus
        public ActionResult Contact()
        {
            return View();
        }
    }
}