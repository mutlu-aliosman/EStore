using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EStore.Business.Abstract;
using EStore.Entities;
using EStore.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EStore.WebUI.Controllers
{
    public class EStoreController : Controller
    {
        private IProductService _productService;
        public EStoreController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetAll()
            });
        }
        public IActionResult Urunler(string category,int page=1)
        {
            const int pageSize = 3;
            return View(new ProductListModel()
            {
                Products = _productService.GetProductsByCategory(category,page,pageSize)
            });
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = _productService.GetProductDetails((int)id);
            if (product == null)
            {
                return NotFound();
            }
            return View(new ProductDetailsModel()
            {
                Product = product,
                Categories = product.ProductCategories.Select(i => i.Category).ToList()
            });
        }
    }
    
}