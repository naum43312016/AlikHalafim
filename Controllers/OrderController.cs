using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlikHalafim.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlikHalafim.Controllers
{
    public class OrderController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(double total)
        {
            ViewBag.total = total;
            ViewBag.subTotal = total-30;
            return View(new Order());
        }
    }
}