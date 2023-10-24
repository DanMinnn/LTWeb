﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTemplate.Models;

namespace TestTemplate.Controllers
{
    public class BasketballController : Controller
    {
        // GET: Basketball
        QuanLyDatSanEntities db = new QuanLyDatSanEntities();
        public ActionResult Index()
        {
            var lstCsBongRo = db.CoSoes.Where(n => n.MaLoaiCS == "bongRo");
            return View(lstCsBongRo);
        }
    }
}