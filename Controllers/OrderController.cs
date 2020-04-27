using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AlikHalafim.Data;
using AlikHalafim.Helpers;
using AlikHalafim.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlikHalafim.Controllers
{
    public class OrderController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        public OrderController(ApplicationDbContext db,UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        
        public IActionResult CreateOrder()
        {


            double total = getSubTotal();
            Order order = new Order();
            order.SubTotal = total;
            order.Total = total + 30.0;
            return View(order);
        }
        private double getSubTotal()
        {
            Cart cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");
            List<CartObject> list = new List<CartObject>();
            double total = 0.0;
            if (cart != null)
            {
                list = cart.ProductsInCart;
                foreach (CartObject obj in list)
                {
                    int quantity = obj.ProductQuantiy;
                    Product prod = _db.Product.Include(c => c.Category).FirstOrDefault(i => i.Id == obj.ProductId);
                    if (prod != null)
                    {
                        double price = double.Parse(prod.Price, System.Globalization.CultureInfo.InvariantCulture);
                        total += price * quantity;
                    }
                }
            }
            return total;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOrder(Order model)
        {
            double total = getSubTotal();
            model.SubTotal = total;
            model.Total = total + 30.0;
            if (ModelState.IsValid)
            {
                model.OrderDate = DateTime.Today;
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if(userId!=null && userId.Length > 0)
                {
                    model.UserId = userId;
                }
                model.PaymentMethod = OrderHelper.PAYMENT_METHOD_CREDITCARD;
                model.PaymentStatus = OrderHelper.PAYMENT_STATUS_BAD;
                model.DeliveryMethod = OrderHelper.DELIVERY_MAIL;
                model.Status = OrderHelper.STATUS_OPEN;
                _db.Order.Add(model);
                //Cart items add
                Cart cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");
                List<CartObject> list = new List<CartObject>();
                if (cart != null)
                {
                    list = cart.ProductsInCart;
                    foreach (CartObject obj in list)
                    {
                        Product prod = _db.Product.Include(c => c.Category).FirstOrDefault(i => i.Id == obj.ProductId);
                        CartItemForDb item = new CartItemForDb
                        {
                            Quantity=obj.ProductQuantiy,
                            ProductId=obj.ProductId,
                            ProductCurrentPrice=prod.Price,
                            ProductName=prod.ProductName,
                            ProductNumber=prod.CatalogNumber,
                            OrderId=model.Id,
                            Order=model
                        };
                        _db.CartItemForDb.Add(item);
                    }
                }
                HttpContext.Session.Remove("cart");
                _db.SaveChanges();
                return Content("Valid");
            }
            return View(model);
        }
    }
}