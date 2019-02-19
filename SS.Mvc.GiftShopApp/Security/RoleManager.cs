using Microsoft.AspNet.Identity;
using SS.Mvc.GiftShopApp.Core.Models;

namespace SS.Mvc.GiftShopApp.Security
{
    public class RoleManager : RoleManager<Role, int>, IRoleManager
    {
        public RoleManager(IRoleStore<Role, int> store)
            : base(store)
        {
        }
    }
}