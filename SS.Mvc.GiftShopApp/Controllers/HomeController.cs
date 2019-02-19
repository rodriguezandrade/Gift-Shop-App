using System;
using System.Web.Mvc;
using SS.Data;
using System.Web.Http;
using SS.Mvc.GiftShopApp.Security;

namespace SS.Mvc.GiftShopApp.Controllers
{
    [InitializeIdentity]
    public class HomeController : Controller
    {
  

        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

#if DEBUG
	
		[System.Diagnostics.DebuggerStepThrough]
		public ActionResult ErrorTest()
		{
			throw new ApplicationException("Error test.");
		}

#endif
    }
}