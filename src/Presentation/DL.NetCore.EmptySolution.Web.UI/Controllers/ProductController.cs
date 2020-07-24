using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DL.NetCore.EmptySolution.Web.UI.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace DL.NetCore.EmptySolution.Web.UI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private IEnumerable<FakeProductEntity> GetFakeProducts()
        {
            var categories = new List<FakeProductCategoryEntity>
            {
                new FakeProductCategoryEntity
                {
                    ProductCategoryId = 1,
                    CategoryName = "Arts, Crafts & Sewing"
                },
                new FakeProductCategoryEntity
                {
                    ProductCategoryId = 2,
                    CategoryName = "Baby"
                },
                new FakeProductCategoryEntity
                {
                    ProductCategoryId = 3,
                    CategoryName = "Cell Phones"
                },
                new FakeProductCategoryEntity
                {
                    ProductCategoryId = 4,
                    CategoryName = "Computers"
                },
                new FakeProductCategoryEntity
                {
                    ProductCategoryId = 5,
                    CategoryName = "Home Audio"
                },
                new FakeProductCategoryEntity
                {
                    ProductCategoryId = 6,
                    CategoryName = "Kitchen"
                },
                new FakeProductCategoryEntity
                {
                    ProductCategoryId = 7,
                    CategoryName = "Clothing"
                },
                new FakeProductCategoryEntity
                {
                    ProductCategoryId = 8,
                    CategoryName = "Musical Instruments"
                },
                new FakeProductCategoryEntity
                {
                    ProductCategoryId = 9,
                    CategoryName = "Jewelry"
                }
            };

            // Randomly assign the categories to products, just for fun
            Random rnd = new Random();

            yield return new FakeProductEntity
            {
                ProductId = 1,
                ProductName = "Samsung Galaxy S20 Plus",
                ProductCategory = categories[rnd.Next(0, categories.Count)],
                UnitPrice = 949.99,
                OutOfStock = false,
                DateCreatedUtc = DateTime.Parse("2020/07/01")
            };

            yield return new FakeProductEntity
            {
                ProductId = 2,
                ProductName = "Bath Rug",
                ProductCategory = categories[rnd.Next(0, categories.Count)],
                UnitPrice = 24.5,
                OutOfStock = false,
                DateCreatedUtc = DateTime.Parse("2013/07/10"),
                RestockDate = DateTime.Parse("2015/01/01")
            };

            yield return new FakeProductEntity
            {
                ProductId = 3,
                ProductName = "Shower Curtain",
                ProductCategory = categories[rnd.Next(0, categories.Count)],
                UnitPrice = 30.99,
                OutOfStock = false,
                DateCreatedUtc = DateTime.Parse("2014/02/14"),
                RestockDate = DateTime.Parse("2016/04/18")
            };

            yield return new FakeProductEntity
            {
                ProductId = 4,
                ProductName = "Soap Dispenser",
                ProductCategory = categories[rnd.Next(0, categories.Count)],
                UnitPrice = 12.4,
                OutOfStock = true,
                DateCreatedUtc = DateTime.Parse("2015/03/6")
            };

            yield return new FakeProductEntity
            {
                ProductId = 5,
                ProductName = "Toilet Tissue",
                ProductCategory = categories[rnd.Next(0, categories.Count)],
                UnitPrice = 15,
                OutOfStock = false,
                DateCreatedUtc = DateTime.Parse("2018/09/10"),
                RestockDate = DateTime.Parse("2013/05/06")
            };

            yield return new FakeProductEntity
            {
                ProductId = 6,
                ProductName = "Branket",
                ProductCategory = categories[rnd.Next(0, categories.Count)],
                UnitPrice = 60,
                OutOfStock = false,
                DateCreatedUtc = DateTime.Parse("2014/03/08"),
                RestockDate = DateTime.Parse("2017/08/22")
            };

            yield return new FakeProductEntity
            {
                ProductId = 7,
                ProductName = "Mattress Protector",
                ProductCategory = categories[rnd.Next(0, categories.Count)],
                UnitPrice = 30.4,
                OutOfStock = true,
                DateCreatedUtc = DateTime.Parse("2011/01/01")
            };
        }
    }
}
