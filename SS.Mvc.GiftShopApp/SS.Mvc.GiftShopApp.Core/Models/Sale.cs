using SS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Mvc.GiftShopApp.Core.Models
{
    public class Sale : IEntity
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public int Amount { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<SaleDetail> Products { get; set; }
    }
}
