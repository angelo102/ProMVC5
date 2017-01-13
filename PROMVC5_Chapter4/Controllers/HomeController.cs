using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PROMVC5_Chapter4.Models;

namespace PROMVC5_Chapter4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "navigate to URL to show an example";
        }

        public ViewResult AutoProperty()
        {
            Product myProduct = new Product();
            myProduct.Name = "Kayak";

            string productName = myProduct.Name;

            return View("Result", (object)String.Format("Product Name: {0}", productName));
        }

        public ViewResult CreateProduct()
        {
            Product myP = new Product
            {
                ProductID = 100,
                Name = "Kayak",
                Description = "A boat for one person",
                Price = 275M,
                Category = "Watersports"
            };

            return View("Result", (object)String.Format("Category Name: {0}", myP.Category));
        }

        public ViewResult CreateCollection()
        {
            string[] stringArray = { "apple", "orange", "plum" };
            List<int> intList = new List<int> { 10, 20, 30, 40 };
            Dictionary<string, int> myDict = new Dictionary<string, int>{
                {"apple",10},{"orange",20},{"plum",30}
            };

            return View("Result", (object)stringArray[1]);
        }

        public ViewResult UseExtension()
        {
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product>{
                    new Product{Name="Kayak",Price=275M},
                    new Product{Name="Lifejacket",Price=48.95M},
                    new Product{Name="Soccer Ball",Price=19.50M},
                    new Product{Name="Corner Flag",Price=34.95M}
                }
            };

            decimal cartTotal = cart.TotalPrices();

            return View("Result", (object)string.Format("Total: {0:c}", cartTotal));

        }
    }
}