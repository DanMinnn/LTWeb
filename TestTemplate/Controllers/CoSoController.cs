using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTemplate.Models;

namespace TestTemplate.Controllers
{
    public class CoSoController : Controller
    {
        // GET: CoSo
        QLDSEntities db = new QLDSEntities();
        [ChildActionOnly] // người dùng không thể get partial
        public ActionResult CoSoBongDaPartial()
        {

            return PartialView();
        }

        [ChildActionOnly] // người dùng không thể get partial
        public ActionResult CoSoBongRoPartial()
        {

            return PartialView();
        }

        [ChildActionOnly] // người dùng không thể get partial
        public ActionResult CoSoCauLongPartial()
        {

            return PartialView();
        }

        [ChildActionOnly] // người dùng không thể get partial
        public ActionResult CoSoTennisPartial()
        {

            return PartialView();
        }
    }
}