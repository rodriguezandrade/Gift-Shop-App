using SS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Mvc.GiftShopApp.Core.Models
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }   
    }
}
