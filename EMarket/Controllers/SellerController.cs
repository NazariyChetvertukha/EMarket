﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMarket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using AppContext = EMarket.Models.AppContext;

namespace EMarket.Controllers
{
    //[Authorize(Roles = "Seller")]
    public class SellerController : Controller
    {
        public async Task<IActionResult> Index()
        {
            await using AppContext db = new AppContext();
            var orders = db.Orders.Where(o => o.SellerId == Int32.Parse(User.FindFirst("Id").Value))
                .Include(o => o.Buyer)
                .Include(o => o.Delivery)
                .Include(o => o.Destination)
                .Include(o => o.ProductOrder)
                .ThenInclude(po => po.Product).ToList();
            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            await using AppContext db = new AppContext();
            var categories = db.Categories.ToList();
            ViewBag.Categories = categories;
            
            return View(new Product());
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                await using AppContext db = new AppContext();
                product.SellerId = Int32.Parse(User.FindFirst("Id")?.Value ?? string.Empty);
                await db.Products.AddAsync(product);
                await db.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
