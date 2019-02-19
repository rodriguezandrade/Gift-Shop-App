using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SS.Mvc.GiftShopApp.Core.Models.LoginJWT
{
   public class LoginRequest: ApiController
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
