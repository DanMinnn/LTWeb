using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTemplate.Models;

namespace TestTemplate.Controllers
{
    public class TimKiemController : Controller
    {
       QLDSEntities db = new QLDSEntities();
        // GET: TimKiem
        public ActionResult KQTimKiem(string sTuKhoa)
        {
            // Tìm kiếm theo tên cơ sở
            var lstCoSo = db.CoSoes.Where(n => n.TenCS.Contains(sTuKhoa));
            return View(lstCoSo.OrderBy(n => n.TenCS));
        }
    }
}