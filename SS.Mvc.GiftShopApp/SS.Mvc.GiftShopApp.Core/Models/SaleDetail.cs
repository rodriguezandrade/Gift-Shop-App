using SS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Mvc.GiftShopApp.Core.Models
{
    public class SaleDetail : IEntity
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public decimal subTotal { get; set; }
        public DateTime Date { get; set; }

        public int ProductId { get; set; }
        public int SaleId { get; set; }

        public virtual Sale Sale { get; set; }
        public virtual Product Product { get; set; }
       
    }
}
