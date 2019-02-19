using SS.Data.EntityFramework;
using SS.Mvc.GiftShopApp.Core.Models;
using SS.Mvc.GiftShopApp.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Mvc.GiftShopApp.Core.Models.dto;
using System.Collections.ObjectModel;

namespace SS.Mvc.GiftShopApp.Core.Repository
{
    public class SaleRepository : EfRepositoryBase<Sale>, ISaleRepository
    {
        public SaleRepository(IWorkspace workspace) : base(workspace)
        {
        }
 
        List<SaleDto> ISaleRepository.GetDto(int userId)
        {
            var result = ReadOnlyWorkspace.Query<Sale>(x => x.UserId == userId).Select(x => new SaleDto
            {
                Id = x.Id,
                Total = x.Total,
                Amount = x.Amount,
                Date = x.Date
            }).ToList();

            return result;
        }
    }
}
