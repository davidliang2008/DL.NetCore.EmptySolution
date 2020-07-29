using System;
using System.ComponentModel.DataAnnotations;

namespace DL.NetCore.EmptySolution.Web.UI.Models.Product
{
    public class CreateProductViewModel
    {
        [Required]
        [Display(Name = "Product name")]
        public string ProductName { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Unit price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "{0} needs to be at least {1}.")]
        public double UnitPrice { get; set; }

        [Display(Name = "Out of stock?")]
        public bool OutOfStock { get; set; }
    }
}
