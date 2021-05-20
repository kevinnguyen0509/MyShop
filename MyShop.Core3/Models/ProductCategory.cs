using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShop.Core3.Models
{
    public class ProductCategory
    {
        public string Id { get; set; }
        public string Category { get; set;  }

        public ProductCategory()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}