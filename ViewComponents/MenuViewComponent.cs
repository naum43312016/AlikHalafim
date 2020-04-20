using AlikHalafim.Data;
using AlikHalafim.Models;
using AlikHalafim.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlikHalafim.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public MenuViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            List<Category> categories =  _db.Category.Where(i => i.ParentCategory.CategoryName.Equals("RegularCategory")).ToList();
            List<List<Category>> regCat = new List<List<Category>>();
            for(int i = 0; i < categories.Count; i++)
            {
                List<Category> cat = _db.Category.Where(c => c.ParentCategoryId == categories[i].Id).ToList();
                cat.Insert(0,categories[i]);
                regCat.Add(cat);
            }
            CategoryViewModel viewModel = new CategoryViewModel()
            {
                RegCategories = regCat
            };
            return View(viewModel);
        }
    }
}
