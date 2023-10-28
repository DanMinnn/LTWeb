using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTemplate.Models;

namespace TestTemplate.Controllers
{
    public class TennisController : Controller
    {
        // GET: Tennis
        QLDSEntities db = new QLDSEntities();
        public ActionResult Index()
        {
            var lstCsTennis = db.CoSoes.Where(n => n.MaLoaiCS == "quanVot");
            return View(lstCsTennis);
        }
    }
}