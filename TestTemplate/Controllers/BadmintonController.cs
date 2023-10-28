using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTemplate.Models;

namespace TestTemplate.Controllers
{
    public class BadmintonController : Controller
    {
        // GET: Badminton
        QLDSEntities db = new QLDSEntities();
        public ActionResult Index()
        {
            var lstCsCauLong = db.CoSoes.Where(n => n.MaLoaiCS == "cauLong");
            return View(lstCsCauLong);
        }
    }
}