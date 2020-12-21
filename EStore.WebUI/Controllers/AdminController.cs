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
    public class AdminController : Controller
    {
        private IProductService _productService;
        public AdminController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult erorr()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetAll()
            }); ;
        }
        [HttpGet]
        public IActionResult CreateProduct( )
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(ProductModel model)
        {
            var entity = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                ImageUrl=model.ImageUrl,
                 Description=model.Description
                
            };
            _productService.Create(entity);
            return RedirectToAction("Index");
        }
        public IActionResult ProductEdit(int? id)
        {
            if(id==null)
            {
                return RedirectToAction("erorr");
            }
            var entity = _productService.GetById((int)id);
            if(entity==null)
            {
                return RedirectToAction("erorr");
            }
            var model = new ProductModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                ImageUrl = entity.ImageUrl,
                Description=entity.Description
                
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult ProductEdit(ProductModel model)
        {
            var entity = _productService.GetById(model.Id);
            if(entity==null)
            {
                return RedirectToAction("erorr");
            }
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.ImageUrl = model.ImageUrl;
            entity.Price = model.Price;
            _productService.Update(entity);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult ProductDelete(int ProductId)
        {
            var entity = _productService.GetById(ProductId);
            if(entity!=null)
            {
                _productService.Delete(entity);
            }
            return RedirectToAction("Index");
        }
        
    }
}