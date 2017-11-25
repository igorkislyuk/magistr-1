﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCreditApp.Models;

namespace MVCCreditApp.Controllers
{
    public class HomeController : Controller
    {
        private CreditContext db = new CreditContext();

        // GET: Home
        public ActionResult Index()
        {
            var allCredits = db.Credits.ToList();
            ViewBag.Credits = allCredits;

            return View();
        }

        [HttpGet]
        public ActionResult CreateBid()
        {
            var allBids = db.Bids.ToList<Bid>();
            ViewBag.Bids = allBids;
            return View();
        }

        [HttpPost]
        public string CreateBid(Bid newBid)
        {
            newBid.bidDate = DateTime.Now;

            // Добавляем новую заявку в БД 
            db.Bids.Add(newBid);
            // Сохраняем в БД все изменения 
            db.SaveChanges();

            return "Спасибо, <b>" + newBid.Name +
                   "</b>, за выбор нашего банка.Ваша заявка будет рассмотрена в течении 10 дней.";
        }
    }
}