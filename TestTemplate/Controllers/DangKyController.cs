using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTemplate.Models;

namespace TestTemplate.Controllers
{
    public class DangKyController : Controller
    {
        // GET: DangKy
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(DangKy model)
        {
            return View();
        }
    }
}