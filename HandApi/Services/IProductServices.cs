using HandApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandApi.Services
{
    public interface IProductServices
    {
        IEnumerable<ProductEntity> GetAll();
        ProductEntity GetById(int? id);
        ProductEntity Create(ProductEntity model);
        void Delete(int? id);
        ProductEntity Update(ProductEntity model);
    }
}
