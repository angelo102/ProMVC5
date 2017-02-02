﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EssentialTools.Models;
using Ninject;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        private Product[] products = {
                new Product{Name="Kayak", Category="Watersoprts",Price=275M},
                new Product{Name="Lifejacket", Category="Watersoprts",Price=48.95M},
                new Product{Name="Soccer Ball", Category="Soccer",Price=19.50M},
                new Product{Name="Corner Flag",Category="Soccer",Price=34.95M}
        };

        // GET: Home
        public ActionResult Index()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();

            IValueCalculator calc = ninjectKernel.Get<IValueCalculator>();
            ShoppingCart cart = new ShoppingCart(calc) { Products = products };
            decimal totalValue = cart.CalculateProductTotal();

            return View(totalValue);
        }
    }
}