﻿using EStore.Business.Abstract;
using EStore.DataAccess.Abstract;
using EStore.DataAccess.Concrete.EfCore;
using EStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace EStore.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public string ErorMesaage { get; set; }

        public bool Create(Product entity)
        {
            if(Validate(entity))
            {
                _productDal.Create(entity);
                return true;
            }
            return false;
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public Product GetByIdWithCategorys(int id)
        {
            return _productDal.GetByIdWithCategorys(id);
        }

        public Product GetProductDetails(int id)
        {
            return _productDal.GetProductDetails(id);
        }

        public List<Product> GetProductsByCategory(string category,int page,int pageSize)
        {
            return _productDal.GetProductsByCategory(category, page, pageSize);
        }

        public object GetProductsByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }

        public void Update(Product entity, int[] categoryId)
        {
            _productDal.Update(entity, categoryId);
        }

        public bool Validate(Product entity)
        {
            var IsValid = true;
            if(string.IsNullOrEmpty(entity.Name))
            {
                ErorMesaage += "Lütfen ürün ismi giriniz.";
                IsValid = false;
            }

            return IsValid;
        }
    }
}
