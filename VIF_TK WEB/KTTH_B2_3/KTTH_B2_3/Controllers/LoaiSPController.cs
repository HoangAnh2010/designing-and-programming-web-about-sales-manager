using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KTTH_B2_3.Models;

namespace KTTH_B2_3.Controllers
{
    public class LoaiSPController : Controller
    {
        // GET: LoaiSP
        LoaiSPModel dblsp = new LoaiSPModel();
        public ActionResult Index()
        {
            return View();
        }
    }
}