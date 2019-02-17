using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportShop.Models;
using SportShop.Models.ViewModels;

namespace SportShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public ViewResult List(string category) 
            => View(new ProductListViewModel
            {
                Products = _productRepository.Products
                    .Where(p => category == null || p.Category == category || category == "All")
                    .OrderBy(p => p.ProductID),

                CurrentCategory = category
            });

        public ViewResult Details(int productId)
        {
            var product = _productRepository.Products.FirstOrDefault(d => d.ProductID == productId);
            if (product == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(product);
        }
    }
}
