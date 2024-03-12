using AutoMapper;
using PPBLL;
using PPDAL;
using ProductPlannerEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductPlannerEF.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetProduct()
        {
            ProductService ps = new ProductService();
            var products = ps.GetProduct();

            List<ProductVM> productVMs = new List<ProductVM>();

            // Mapper.Initialize(x => x.CreateMap<Trip, TripVM>());
            productVMs = Mapper.Map<List<Product>, List<ProductVM>>(products);

            // Mapper.Map(trips, tripVMs);

            return Json(productVMs, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetProductById(int id)
        {
            ProductService ps = new ProductService();
            var product = ps.GetProductInfo(id);
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddProduct(Product product)
        {
            ProductService ps = new ProductService();
            var productAdded = ps.AddProduct(product);
            return Json(productAdded, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateProduct(Product product)
        {
            ProductService ps = new ProductService();

            var productUpdated = ps.UpdateProduct(product);
            return Json(productUpdated, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteProduct(int id)
        {
            ProductService ps = new ProductService();

            if (ps.DeleteProduct(id))
            {
                return Json(JsonRequestBehavior.AllowGet);
            }
            return null;
        }
    }
}