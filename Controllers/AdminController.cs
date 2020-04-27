using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AlikHalafim.Data;
using AlikHalafim.Helpers;
using AlikHalafim.Models;
using AlikHalafim.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlikHalafim.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly UserManager<IdentityUser> _userManager;
        public AdminController(ApplicationDbContext db, IWebHostEnvironment hostingEnvironment
            ,UserManager<IdentityUser> userManager)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Category()
        {
            IEnumerable<Category> categories = await _db.Category.Include(c => c.ParentCategory)
                .ToListAsync();
            return View(categories);
        }

        public async Task<IActionResult> CategoryCreate()
        {
            IEnumerable<Category> categories = await _db.Category.Include(c => c.ParentCategory)
               .ToListAsync();
            ViewBag.Categories = categories;


            return View(new Category());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryCreateForm(Category model, IFormFile imageFile)
        {

            model.CategoryImage = "";
            if (model.ParentCategoryId != 0)
            {
                model.ParentCategory = await _db.Category.FindAsync(model.ParentCategoryId);
            }
            await _db.Category.AddAsync(model);
            await _db.SaveChangesAsync();
            if (imageFile != null)
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                string imgName = model.Id.ToString() + imageFile.FileName;
                var path = Path.Combine(webRootPath, "CategoryImages", imgName);
                var stream = new FileStream(path, FileMode.Create);
                await imageFile.CopyToAsync(stream);
                model.CategoryImage = "CategoryImages/" + imgName;
                stream.Close();
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Category", "Admin");
        }
        public async Task<IActionResult> CategoryEdit(int id)
        {
            IEnumerable<Category> categories = await _db.Category.Include(c => c.ParentCategory)
               .ToListAsync();
            ViewBag.Categories = categories;
            Category cat = await _db.Category.Include(c => c.ParentCategory)
                .FirstOrDefaultAsync(i => i.Id==id);
            return View(cat);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryEditForm(Category model, int CatId,string prevImage, IFormFile imageFile)
        {
            model.ParentCategory = await _db.Category.FindAsync(model.ParentCategoryId);
            model.CategoryImage = prevImage;

            if (imageFile != null)
            {
                string webRootPath = _hostingEnvironment.WebRootPath;

                //Delete orig file
                var imagePath = Path.Combine(webRootPath, prevImage.TrimStart('\\'));
                //Delete old image
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                string imgName = CatId.ToString() + imageFile.FileName;
                var path = Path.Combine(webRootPath, "CategoryImages", imgName);
                var stream = new FileStream(path, FileMode.Create);
                await imageFile.CopyToAsync(stream);
                model.CategoryImage = "CategoryImages/" + imgName;
                stream.Close();
            }
            Category category = await _db.Category.FindAsync(CatId);
            category.CategoryImage = model.CategoryImage;
            category.CategoryName = model.CategoryName;
            category.ParentCategory = model.ParentCategory;
            category.ParentCategoryId = model.ParentCategoryId;
            _db.Update(category);
            await _db.SaveChangesAsync();
            return RedirectToAction("Category", "Admin");
        }






        public async Task<IActionResult> CategoryRemove(int id)
        {
            if(id==3 || id == 12)
            {
                TempData["categoryRemoveMessage"] = "You Can't remove parent category, first remove or edit it's child category";
                return RedirectToAction("Category", "Admin");
            }
            var cat = await _db.Category.FindAsync(id);



            List<Category> categories = await _db.Category.Where(c => c.ParentCategoryId == id).ToListAsync();
            if (categories == null || categories.Count() < 1)
            {
                _db.Remove(cat);
                await _db.SaveChangesAsync();
                //Remove current image
                string _imageToBeDeleted = Path.Combine(_hostingEnvironment.WebRootPath, cat.CategoryImage);
                if ((System.IO.File.Exists(_imageToBeDeleted)))
                {
                    System.IO.File.Delete(_imageToBeDeleted);
                }
                TempData["categoryRemoveMessage"] = "";
                return RedirectToAction("Category", "Admin");
            }
            else
            {
                TempData["categoryRemoveMessage"] = "You Can't remove parent category, first remove or edit it's child category";
                return RedirectToAction("Category", "Admin");
            }
        }

        public IActionResult Users()
        {
            var users =  _userManager.Users.ToList();
            return View(users);
        }

        public async Task<IActionResult> Orders()
        {
            List<Order> orders = await _db.Order.OrderByDescending(o => o.OrderDate).ToListAsync();
            return View(orders);
        }

        public async Task<IActionResult> OrderStatusEdit(int id)
        {
            Order order = await _db.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            if (order.Status.Equals(OrderHelper.STATUS_OPEN))
            {
                order.Status = OrderHelper.STATUS_CLOSE;
            }
            else
            {
                order.Status = OrderHelper.STATUS_OPEN;
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Orders","Admin");
        }

        public async Task<IActionResult> OrderPaymentStatusEdit(int id)
        {
            Order order = await _db.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            if (order.PaymentStatus.Equals(OrderHelper.PAYMENT_STATUS_BAD))
            {
                order.PaymentStatus = OrderHelper.PAYMENT_STATUS_GOOD;
            }
            else
            {
                order.PaymentStatus = OrderHelper.PAYMENT_STATUS_BAD;
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Orders", "Admin");
        }

        public async Task<IActionResult> OrderDetails(int id)
        {
            Order order = await _db.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            List<CartItemForDb> items = await _db.CartItemForDb.Where(c => c.OrderId == id)
                .ToListAsync();
            if (items == null)
            {
                return NotFound();
            }
            OrderDetailViewModel orderVm = new OrderDetailViewModel
            {
                Order=order,
                Products=items
            };
            return View(orderVm);
        }

        public async Task<IActionResult> UserLock(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            user.LockoutEnd = DateTime.Now.AddYears(1000);
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Users", "Admin");
        }
        public async Task<IActionResult> UserunLock(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            user.LockoutEnd = null;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Users", "Admin");
        }

    }
}