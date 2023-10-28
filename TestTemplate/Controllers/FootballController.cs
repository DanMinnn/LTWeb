using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTemplate.Models;

namespace TestTemplate.Controllers
{
    public class FootballController : Controller
    {
        // GET: About
        QLDSEntities db = new QLDSEntities();
        public ActionResult Index()
        {
            
            var lstCSBongDa = db.CoSoes.Where(n => n.MaLoaiCS == "bongDa");  
            //ViewBag.CsBongDa = lstCSBongDa;
            return View(lstCSBongDa);
        }


    }
}