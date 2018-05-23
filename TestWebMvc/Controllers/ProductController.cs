using Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestWebMvc.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IService<Product> _productService;
        private readonly IService<ProductModelProductDescription> _prodModProdDesService;
        public ProductController(IService<Product> productService
            , IService<ProductModelProductDescription> prodModProdDesService)
        {
            _productService = productService;
            _prodModProdDesService = prodModProdDesService;
        }
        // GET: Product
        public ActionResult Index()
        {
            ICollection<Product> productList = _productService.Get(_controllerName, "GetProducts");
            return View(productList);
        }
        public ActionResult Details(int id)
        {
            Product product = _productService.Get(_controllerName, "GetProduct", id);
            return View(product);
        }
        public ActionResult ProductDetails(int id)
        {
            ProductModelProductDescription prodModProdDes = new ProductModelProductDescription();
            prodModProdDes = _prodModProdDesService.Get("ProductModelProductDescription", "GetProductModelProductDescriptionByProductModelID", id);
            return View(prodModProdDes);
        }
    }
}