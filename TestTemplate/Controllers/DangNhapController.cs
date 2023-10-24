using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestTemplate.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: DangNhap
        public ActionResult Index()
        {
            return RedirectToAction("DangNhap", "HomeAdmin", new { area = "Admin" });
            //return View();
        }
    }
}