using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AlikHalafim.Models;
using Microsoft.AspNetCore.Identity;
using AlikHalafim.Data;
using Microsoft.EntityFrameworkCore;

namespace AlikHalafim.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger,RoleManager<IdentityRole> roleManager
            ,ApplicationDbContext db)
        {
            _logger = logger;
            this.roleManager = roleManager;
            _db = db;
        }

        public async Task<IActionResult> Index(int page=1)
        {
            if (TempData["message"] != null)
            {
                ViewBag.message = TempData["message"].ToString();
            }
            if (page < 1) page = 1;
            int productPerPage = 12;
            int count = await _db.Product.Where(r => r.Rank > 7).Include(c => c.Category)
                .CountAsync();
            if (count > 120)
            {
                productPerPage = 24;
            }
            int pagesCount = count / productPerPage;
            if (count % productPerPage != 0) pagesCount++;
            List<Product> products = await _db.Product.Where(r => r.Rank > 7).Include(c => c.Category)
                .Skip((page-1)* productPerPage).Take(productPerPage).ToListAsync();
            ViewBag.currentPage = page;
            ViewBag.pagesCount = pagesCount;
            return View(products);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




       
        public IActionResult Search(string search,int page)
        {
            if (TempData["message"] != null)
            {
                ViewBag.message = TempData["message"].ToString();
            }
            if (page < 1) page = 1;
            int productPerPage = 12;
            int count = _db.Product
                .Where(r => r.CatalogNumber.Contains(search)
                || r.OriginalNumbers.Contains(search)
                || r.BigDescription.Contains(search)
                || r.ProductName.Contains(search)
                || r.Manufacturer.Contains(search)
                || r.Vehicles.Contains(search)
                )
                .Include(c => c.Category)
                .Count();
            if (count > 120)
            {
                productPerPage = 24;
            }
            int pagesCount = count / productPerPage;
            if (count % productPerPage != 0) pagesCount++;
            List<Product> products = _db.Product
                .Where(r => r.CatalogNumber.Contains(search)
                || r.OriginalNumbers.Contains(search)
                || r.BigDescription.Contains(search)
                || r.ProductName.Contains(search)
                || r.Manufacturer.Contains(search)
                || r.Vehicles.Contains(search)
                )
                .Include(c => c.Category)
                .Skip((page - 1) * productPerPage).Take(productPerPage).ToList();
            ViewBag.currentPage = page;
            ViewBag.pagesCount = pagesCount;
            ViewBag.search = search;
            return View(products);
        }
    }
}
