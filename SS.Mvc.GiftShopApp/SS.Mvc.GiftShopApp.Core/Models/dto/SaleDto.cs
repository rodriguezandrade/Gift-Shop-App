using SS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Mvc.GiftShopApp.Core.Models.dto
{
    public class SaleDto:IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public decimal subTotal { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
