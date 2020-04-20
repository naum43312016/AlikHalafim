using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlikHalafim.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlikHalafim.Controllers
{
    public class VehicleController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddVehicle(string makeValue,string modelValue,string yearValue,string engineValue)
        {
            string vehicle = makeValue + " " + modelValue + " " + yearValue + " " + engineValue;
            HttpContext.Response.Cookies.Append("car", vehicle);
            return RedirectToAction("Index", "SubCategory");
        }
        public IActionResult RemoveVehicle()
        {
            HttpContext.Response.Cookies.Delete("car");
            return RedirectToAction("Index", "Home");
        }
        
    }
}