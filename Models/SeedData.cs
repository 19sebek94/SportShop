using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using SportShop.Models;

namespace SportsStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Rakieta tenisowa",
                        Description = "Wygodna w trzymaniu rakieta tenisowa",
                        Category = "Tenis",
                        Price = 275
                    },
                    new Product
                    {
                        Name = "Piłka do nogi",
                        Description = "Niezniszczalna i oryginalna piłka do nogi",
                        Category = "Piłka nożna",
                        Price = 48.95m
                    }
                );
                context.SaveChanges();
            }
        }
    }
}