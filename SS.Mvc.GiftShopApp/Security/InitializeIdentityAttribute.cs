using System;
using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SS.Mvc.GiftShopApp.Core.Models;

namespace SS.Mvc.GiftShopApp.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class InitializeIdentityAttribute : ActionFilterAttribute
    {
        private static IdentityInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class IdentityInitializer
        {
            public IdentityInitializer()
            {
                try
                {
                    var roleManager = DependencyResolver.Current.GetService<IRoleManager>();
                    if (!roleManager.RoleExistsAsync("admin").Result)
                    {
                        roleManager.CreateAsync(new Role { Name = "admin" });
                    }

                    if (!roleManager.RoleExistsAsync("Client").Result)
                    {
                        roleManager.CreateAsync(new Role { Name = "Client" });
                    }

                    var appUserManager = DependencyResolver.Current.GetService<IUserManager>();
                    User user = appUserManager.FindByNameAsync("Master").Result;
                    if (user == null)
                    {
                        user = new User { UserName = "Master", Email = "master@mail.com", IsEmailConfirmed = true };
                        IdentityResult result = appUserManager.CreateAsync(user, "P@ssw0rd").Result;
                        if (result.Succeeded)
                        {
                            result = appUserManager.AddToRolesAsync(user.Id, "admin").Result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Identity database could not be initialized.", ex);
                }
            }
        }
    }
}