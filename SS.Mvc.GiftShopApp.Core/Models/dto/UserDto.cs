using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Mvc.GiftShopApp.Core.Models.dto
{
    public class UserDto: CreateUserDto
    {
        public string Role { get; set; }
    }
}
