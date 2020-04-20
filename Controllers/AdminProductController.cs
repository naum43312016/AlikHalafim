using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AlikHalafim.Data;
using AlikHalafim.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlikHalafim.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AdminProductController(ApplicationDbContext db,IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<IActionResult> Index(int page=1)
        {
            if (page < 1) page = 1;

            int productsPerPage = 10;
            var products = await _db.Product.Skip((page-1)* productsPerPage).Take(productsPerPage)
                .Include(c => c.Category)
                .ToListAsync();
            return View(products);
        }
        public async Task<IActionResult> ProductCreate()
        {
            List<Category> categories = await _db.Category.ToListAsync();
            List<Category> catList = new List<Category>();
            for (int i = 0; i < categories.Count(); i++)
            {
                bool contains = false;
                for (int j = i + 1; j < categories.Count(); j++)
                {
                    if (categories[i].Id == categories[j].ParentCategoryId)
                    {
                        contains = true;
                        break;
                    }
                }
                if (!contains)
                {
                    catList.Add(categories[i]);
                }
            }
            ViewBag.Categories = catList;

            return View(new Product());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreateForm(Product model, IFormFile imageFile)
        {
            model.ProductImage = "";
            if (model.CategoryId != 0)
            {
                model.Category = await _db.Category.FindAsync(model.CategoryId);
            }
            await _db.Product.AddAsync(model);
            await _db.SaveChangesAsync();
            if (imageFile != null)
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                string imgName = model.Id.ToString() + imageFile.FileName;
                var path = Path.Combine(webRootPath, "ProductImages", imgName);
                var stream = new FileStream(path, FileMode.Create);
                await imageFile.CopyToAsync(stream);
                model.ProductImage = "ProductImages/" + imgName;
                stream.Close();
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "AdminProduct");
        }

        public IActionResult ProductRemove(int id)
        {
            Product product = _db.Product.Find(id);
            _db.Product.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("Index", "AdminProduct");
        }
    }
}