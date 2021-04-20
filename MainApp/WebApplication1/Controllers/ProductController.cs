using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLib;

namespace WebApplication1.Controllers
{
    //[Authorize]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewProduct()
        {
            Product product = new Product();
            product.Name = "Climatiseur";
            product.Price = 10;

            return View(product);
        }

        [HttpPost]
        public ActionResult ViewProduct(Product product)
        {
            product.Name = product.Name + "la detaille";
            return View(product);
        }

        

        public ActionResult CreateProduct()
        {
            Product product = new Product();
            return View(product);
        }

        
        [HttpPost]
        
        public void CreateProduct(Product product)
        {
            ProductManager manager = new ProductManager();
            manager.insert(product);

            Response.RedirectToRoute("GetAll");
        }

        
        public Object EditProduct(string ID)
        {
            ProductManager manager = new ProductManager();

            if (ID == null)
            {
                Response.RedirectToRoute("GetAll");
                return false;
            }
            
            var product = manager.Get(ID);

            return View(product);
        }

        [HttpPost]
        public void EditProduct(Product product)
        {
            ProductManager manager = new ProductManager();
            manager.update(product);

            Response.RedirectToRoute("GetAll");
        }

        public ActionResult DeleteProduct(string ID)
        {
            bool result;

            if (ID == null) {
                result = false;
            } else {
                ProductManager manager = new ProductManager();
                result = manager.remove(ID);
            }

            return Json(result);
        }

        //[AllowAnonymous]
        public ActionResult GetAll()
        {
            ProductManager manager = new ProductManager();
            var products = manager.GetAll();

            return View(products);
        }
    }
}