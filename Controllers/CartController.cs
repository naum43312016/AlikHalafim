using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlikHalafim.Data;
using AlikHalafim.Helpers;
using AlikHalafim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlikHalafim.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CartController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            Cart cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session, "cart");
            List<CartObject> list = new List<CartObject>();
            List<CartForCartPage> products = new List<CartForCartPage>();
            double total = 0.0;
            if (cart != null)
            {
                list = cart.ProductsInCart;
                foreach(CartObject obj in list)
                {
                    int quantity = obj.ProductQuantiy;
                    Product prod = _db.Product.Include(c => c.Category).FirstOrDefault(i =>i.Id==obj.ProductId);
                    if (prod != null)
                    {
                        double price = double.Parse(prod.Price, System.Globalization.CultureInfo.InvariantCulture);
                        total += price * quantity;
                        CartForCartPage cfP = new CartForCartPage
                        {
                            Product=prod,
                            Quantity=quantity
                        };
                        products.Add(cfP);
                    }
                }
            }
            ViewBag.subtotal = total;
            ViewBag.totalWithDelivery = total+30.0;
            return View(products);
        }
        public IActionResult Add(int id,int quantity,string redAction="Index",string redCon="Home")
        {
            TempData["message"] = "מוצר נוסף לסל הקניות";
            CartObject cartObject = new CartObject
            {
                ProductId=id,
                ProductQuantiy=quantity
            };
            Cart cart = SessionHelper.GetObjectFromJson<Cart>(HttpContext.Session,"cart");
            if (cart == null)
            {
                cart = new Cart();
                List<CartObject> list = new List<CartObject>();
                list.Add(cartObject);
                cart.ProductsInCart = list;
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<CartObject> list = cart.ProductsInCart;
                if (list.Any(prod => prod.ProductId== cartObject.ProductId))
                {
                    int index = list.IndexOf(cartObject);
                    for(int i = 0; i < list.Count; i++)
                    {
                        if (list[i].ProductId == cartObject.ProductId)
                        {
                            list[i].ProductQuantiy = list[i].ProductQuantiy + cartObject.ProductQuantiy;
                            break;
                        }
                    }
                }
                else
                {
                    list.Add(cartObject);
                }
                cart.ProductsInCart = list;
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction(redAction, redCon);
        }
    }
}