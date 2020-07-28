using System;
using System.Collections.Generic;
using System.Linq;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using DL.NetCore.EmptySolution.Web.Common.DataTables.Extensions;
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

        [HttpPost]
        public IActionResult GetList(IDataTablesRequest request)
        {
            var products = GetFakeProducts();

            var rows = new List<ProductListRowViewModel>();
            foreach (var product in products)
            {
                rows.Add(new ProductListRowViewModel
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductCategory = product.ProductCategory.CategoryName,
                    OutOfStock = product.OutOfStock,
                    UnitPrice = product.UnitPrice,
                    DateCreated = product.DateCreatedUtc.ToLocalTime()
                });
            }

            // Filtering
            var filteredRows = rows.AsQueryable()
                .GlobalFilterBy(request.Search, request.Columns);

            // Ordering and Paging
            var pagedRows = filteredRows
                .SortBy(request.Columns)
                .Skip(request.Start)
                .Take(request.Length);

            var response = DataTablesResponse.Create(request, rows.Count, filteredRows.Count(), pagedRows);

            return new DataTablesJsonResult(response);
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

            yield return new FakeProductEntity
            {
                ProductId = 8,
                ProductName = "Architecting ASP.NET eBook",
                ProductCategory = categories[rnd.Next(0, categories.Count)],
                UnitPrice = 19.95,
                OutOfStock = true,
                DateCreatedUtc = DateTime.Parse("2000/01/01")
            };

            yield return new FakeProductEntity
            {
                ProductId = 9,
                ProductName = "Zero SF/f Motorcycle",
                ProductCategory = categories[rnd.Next(0, categories.Count)],
                UnitPrice = 19985,
                OutOfStock = false,
                DateCreatedUtc = DateTime.Parse("2020/03/08")
            };

            yield return new FakeProductEntity
            {
                ProductId = 10,
                ProductName = "VB.NET Fundamentals eBook",
                ProductCategory = categories[rnd.Next(0, categories.Count)],
                UnitPrice = 9.95,
                OutOfStock = false,
                DateCreatedUtc = DateTime.Parse("1998/07/06")
            };

            yield return new FakeProductEntity
            {
                ProductId = 11,
                ProductName = "Security for ASP.NET",
                ProductCategory = categories[rnd.Next(0, categories.Count)],
                UnitPrice = 21,
                OutOfStock = false,
                DateCreatedUtc = DateTime.Parse("2012/03/04")
            };

            yield return new FakeProductEntity
            {
                ProductId = 12,
                ProductName = "Fundamentals of SQL Server",
                ProductCategory = categories[rnd.Next(0, categories.Count)],
                UnitPrice = 21.34,
                OutOfStock = true,
                DateCreatedUtc = DateTime.Parse("1999/09/30")
            };
        }
    }
}
