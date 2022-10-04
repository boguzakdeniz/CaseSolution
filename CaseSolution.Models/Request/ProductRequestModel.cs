using System;
using System.Collections.Generic;
using System.Text;

namespace CaseSolution.Models.Request
{
    public class ProductRequestModel
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double Amount { get; set; }
    }
}
