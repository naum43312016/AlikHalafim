using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlikHalafim.Data;
using AlikHalafim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlikHalafim.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public  async Task<IActionResult> Index(int id)
        {
            if (TempData["message"] != null)
            {
                ViewBag.message = TempData["message"].ToString();
            }
            Product product = await _db.Product.FindAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        public IActionResult ProductsManufacturer(string man,int page=1)
        {
            if (TempData["message"] != null)
            {
                ViewBag.message = TempData["message"].ToString();
            }
            if (page < 1) page = 1;
            int productPerPage = 12;
            int count = _db.Product
                .Where(r => r.Manufacturer.Equals(man))
                .Include(c => c.Category)
                .Count();
            if (count > 120)
            {
                productPerPage = 24;
            }
            int pagesCount = count / productPerPage;
            if (count % productPerPage != 0) pagesCount++;
            List<Product> products = _db.Product
                .Where(r => r.Manufacturer.Contains(man))
                .Include(c => c.Category)
                .Skip((page - 1) * productPerPage).Take(productPerPage).ToList();
            ViewBag.currentPage = page;
            ViewBag.pagesCount = pagesCount;
            ViewBag.man = man;
            return View(products);
        }
    }
}