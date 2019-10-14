using HandApi.Data;
using HandApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandApi
{
    public class ApplicationDbInitializer
    {
        public static void SeedUsers( DbContextOptions<ProductDbContext> dbContext)
        {
            using (var miDbContext = new ProductDbContext(dbContext))
            {
                if (miDbContext.Product.Count() <= 0)
                {
                    miDbContext.Product
                        .AddRange(
                        new List<ProductEntity> {
                            new ProductEntity{ Model = "Focus", Description = "", Year = 2010, Brand = "Ford", Kilometers = 10000, Price = 1000000 },
                            new ProductEntity{ Model = "Impala", Description = "", Year = 2011, Brand = "Chevrolet", Kilometers = 100000, Price = 150000 },
                            new ProductEntity{ Model = "GTR", Description = "", Year = 2015, Brand = "Nissan", Kilometers = 5000, Price = 1000000 },
                            new ProductEntity{ Model = "Jetta", Description = "", Year = 2009, Brand = "Volkswagen", Kilometers = 120000, Price = 110000 },
                            new ProductEntity{ Model = "RAV-4", Description = "", Year = 2015, Brand = "Toyota", Kilometers = 50000, Price = 200000 }
                        });
                }
                miDbContext.SaveChanges();
            }      
        }
    }
}
