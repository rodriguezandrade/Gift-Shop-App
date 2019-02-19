using SS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Mvc.GiftShopApp.Core.Models
{
    public class CartItem : IEntity
    {   //total cantidad, id
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId{ get; set; }
        public int Amount { get; set; }
        public int SubTotal { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
