using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DL.NetCore.EmptySolution.Web.UI.Models.Product
{
    public class ProductListRowViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public double UnitPrice { get; set; }
        public bool OutOfStock { get; set; }
        public DateTime DateCreated { get; set; }

        public string UnitPriceStr => this.UnitPrice.ToString("c");

        public string DateCreatedStr => this.DateCreated.ToShortDateString();
    }
}
