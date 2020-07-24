using System;

namespace DL.NetCore.EmptySolution.Web.UI.Models.Product
{
    public class FakeProductEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public FakeProductCategoryEntity ProductCategory { get; set; }
        public double UnitPrice { get; set; }
        public bool OutOfStock { get; set; }
        public DateTime DateCreatedUtc { get; set; }
        public DateTime? RestockDate { get; set; }
    }
}
