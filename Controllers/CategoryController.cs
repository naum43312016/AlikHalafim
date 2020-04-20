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
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> RegCategory(int id,int page=1)
        {
            if (page < 1) page = 1;
            int productPerPage = 12;
            int count = _db.Product.Where(r => r.CategoryId==id).Include(c => c.Category)
                .Count();
            if (count > 120)
            {
                productPerPage = 24;
            }
            int pagesCount = count / productPerPage;
            if (count % productPerPage != 0) pagesCount++;
            List<Product> products = await _db.Product.Where(r => r.CategoryId == id)
                .Include(c => c.Category)
                .OrderByDescending(r=>r.Rank)
                .Skip((page - 1) * productPerPage).Take(productPerPage).ToListAsync();
            ViewBag.currentPage = page;
            ViewBag.pagesCount = pagesCount;
            return View(products);
        }
    }
}