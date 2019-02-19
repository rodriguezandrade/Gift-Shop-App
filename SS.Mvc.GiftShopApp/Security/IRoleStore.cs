using System.Linq;
using System.Threading.Tasks;
using SS.Mvc.GiftShopApp.Core.Models;

namespace SS.Mvc.GiftShopApp.Security
{
    public interface IRoleStore
    {
        Task CreateAsync(Role role);
        Task DeleteAsync(Role role);
        Task<Role> FindByIdAsync(int roleId);
        Task<Role> FindByNameAsync(string roleName);
        Task UpdateAsync(Role role);
    }
}