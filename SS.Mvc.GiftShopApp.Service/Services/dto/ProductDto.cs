using SS.Mvc.GiftShopApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS.Mvc.GiftShopApp.Service
{
    public class ProductDto : Product
    {
        public string categoryName { get; set; }
        public string categoryId { get; set; }
    }

}