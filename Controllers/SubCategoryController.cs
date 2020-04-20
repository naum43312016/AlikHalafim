using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlikHalafim.Data;
using AlikHalafim.Models;
using AlikHalafim.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlikHalafim.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SubCategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        //parts category
        public async Task<IActionResult> Index()
        {
            string car = "";
            if (HttpContext.Request.Cookies.ContainsKey("car")) {
                car = HttpContext.Request.Cookies["car"];
            }
            List<PartsCategoryViewModel> CategoriesViewModel = new List<PartsCategoryViewModel>();
            List<Category> categories = _db.Category
                .Where(i => i.ParentCategory.CategoryName.Equals("PartsCategory")).ToList();
            for (int i = 0; i < categories.Count; i++)
            {
                List<Category> cat = _db.Category.Where(c => c.ParentCategoryId == categories[i].Id).ToList();
                PartsCategoryViewModel catVM = new PartsCategoryViewModel
                {
                    Main = categories[i],
                    SubCategories = cat
                };
                CategoriesViewModel.Add(catVM);
            }
            ViewBag.car = car;
            return View(CategoriesViewModel);
        }
    }
}