using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EStore.Business.Abstract;
using EStore.Entities;
using EStore.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        #region Injection Process
        private IProductService _productService;
        private ICategoryService _categoryService;
        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        #endregion

        #region Products Process

        public IActionResult erorr()
        {
            return View();
        }
        public IActionResult ListProducts()
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetAll()
            }); ;
        }
        [HttpGet]
        public IActionResult CreateProduct()
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
                ImageUrl = model.ImageUrl,
                Description = model.Description

            };
            _productService.Create(entity);
            return RedirectToAction("ListProducts");
        }
        public IActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("erorr");
            }
            var entity = _productService.GetById((int)id);
            if (entity == null)
            {
                return RedirectToAction("erorr");
            }
            var model = new ProductModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                ImageUrl = entity.ImageUrl,
                Description = entity.Description

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductModel model)
        {
            var entity = _productService.GetById(model.Id);
            if (entity == null)
            {
                return RedirectToAction("erorr");
            }
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.ImageUrl = model.ImageUrl;
            entity.Price = model.Price;
            _productService.Update(entity);

            return RedirectToAction("ListProducts");
        }
        [HttpPost]
        public IActionResult DeleteProduct(int ProductId)
        {
            var entity = _productService.GetById(ProductId);
            if (entity != null)
            {
                _productService.Delete(entity);
            }
            return RedirectToAction("ListProducts");
        }
        #endregion

        #region Category Process

        public IActionResult ListCategorys()
        {
            return View(new CategoryListModel()
            {
                Categories = _categoryService.GetAll()
            });
        }
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var entity = _categoryService.GetById(id);

            return View(new CategoryModel()
            {
                Id = entity.Id,
                Name = entity.Name
            });

        }

        [HttpPost]
        public IActionResult EditCategory(CategoryModel model)
        {
            var entity = _categoryService.GetById(model.Id);
            if (entity == null)
            {
                return RedirectToAction("erorr");
            }
            entity.Name = model.Name;
            _categoryService.Update(entity);
            return RedirectToAction("ListCategorys");
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryModel model)
        {
            var entity = new Category()
            {
                Name = model.Name
            };
            _categoryService.Create(entity);
            return RedirectToAction("ListCategorys");
        }

        [HttpPost]
        public IActionResult DeleteCategory(int categoryid)
        {
            var entity = _categoryService.GetById(categoryid);
            if (entity != null)
            {
                _categoryService.Delete(entity);
            }
            return RedirectToAction("ListCategorys");
        }
        #endregion
    }  
}