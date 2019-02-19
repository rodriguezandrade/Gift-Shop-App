using SS.Data.EntityFramework;
using SS.Mvc.GiftShopApp.Core.Models;
using SS.Mvc.GiftShopApp.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Mvc.GiftShopApp.Core.Models.dto;

namespace SS.Mvc.GiftShopApp.Core.Repository
{
    public class CartRepository : EfRepositoryBase<CartItem>, ICartRepository
    {
        public CartRepository(IWorkspace workspace) : base(workspace)
        {
        }

        public List<CartDto> GetItemCart(int userId)
        {
            var result = ReadOnlyWorkspace.Query<CartItem>(x => x.UserId == userId).Select(x => new CartDto
            {
                Id = x.Id,
                UserId = x.UserId,
                ProductId = x.ProductId,
                Amount = x.Amount,
                SubTotal = x.SubTotal,
                Product = x.Product,
            }).ToList();
       
            return result;
        }

        
    }
}
