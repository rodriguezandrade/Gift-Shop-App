using SS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Mvc.GiftShopApp.Core.Models
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public decimal Cost { get; set; }
        public int Cant { get; set; }
        //public string  Category { get; set; }
        public int Status { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
