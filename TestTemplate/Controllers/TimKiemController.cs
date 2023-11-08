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
        public ActionResult KQTimKiem(string sTenCS, string sDiaChi)
        {
            // Tìm kiếm theo tên cơ sở
            var lstCoSo = db.CoSoes.Where(n => n.TenCS.Contains(sTenCS)
            && n.DiaChi.Contains(sDiaChi));
            return View(lstCoSo.OrderBy(n => n.DiaChi));
        }
    }
}