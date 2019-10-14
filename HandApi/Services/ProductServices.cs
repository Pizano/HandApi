using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandApi.Data;
using HandApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HandApi.Services
{
    public class ProductServices : Controller, IProductServices
    {

        private readonly ProductDbContext _contextProducto;

        public ProductServices(ProductDbContext contextProducto)
        {
            _contextProducto = contextProducto;
        }
        public ProductEntity Create(ProductEntity productEntity)
        {
             _contextProducto.Product.Add(productEntity);
             _contextProducto.SaveChanges();
            return productEntity;
        }

        public  void Delete(int? id)
        {
           
            ProductEntity productEntity =  _contextProducto.Product.Find(id);
            _contextProducto.Product.Remove(productEntity);
             _contextProducto.SaveChanges();
            
        }

        public IEnumerable<ProductEntity>GetAll()
        {
            List<ProductEntity> productEntity =   _contextProducto.Product.ToList();
            return productEntity;
        }

        public  ProductEntity GetById(int? id)
        {
            ProductEntity productEntity =  _contextProducto.Product.Find(id);
            return productEntity;
        }

        public ProductEntity Update(ProductEntity productEntity)
        {
            _contextProducto.Product.Update(productEntity);
             _contextProducto.SaveChanges();
            return productEntity;
        }
    }
}
