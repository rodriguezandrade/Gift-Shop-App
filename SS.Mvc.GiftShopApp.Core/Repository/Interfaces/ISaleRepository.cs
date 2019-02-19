using SS.Mvc.GiftShopApp.Core.Models;
using SS.Mvc.GiftShopApp.Core.Models.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Mvc.GiftShopApp.Core.Repository.Interfaces
{
    public interface ISaleRepository
    {
        List<SaleDto> GetDto(int userId);

        Sale Save(Sale entity);
    }
}
