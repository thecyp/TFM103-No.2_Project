using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwenGo.Data;

namespace TwenGo.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context=new TwenGoContext(
                    serviceProvider.GetRequiredService<DbContextOptions<TwenGoContext>>()
                ))
            {
                if (context.Product.Any())
                {
                    return;
                }
                context.Product.AddRange(
                    new Product
                    {
                        ProductName="可口可樂",
                        Quantity="8-16 OZ",
                        Description="沁涼消暑好喝喔",
                        Price=39
                    },
                    new Product
                    {
                        ProductName = "百事可樂",
                        Quantity = "8-16 OZ",
                        Description = "沁涼消暑沒有到很好喝喔",
                        Price = 32
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
