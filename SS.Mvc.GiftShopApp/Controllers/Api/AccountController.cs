using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using SS.Mvc.GiftShopApp.Core.Models;
using SS.Mvc.GiftShopApp.Core.Models.ContextDB;
using SS.Mvc.GiftShopApp.Core.Models.dto;
using SS.Mvc.GiftShopApp.Core.Repository.Interfaces;
using SS.Mvc.GiftShopApp.Properties;
using SS.Mvc.GiftShopApp.Security;
using SS.Mvc.GiftShopApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace SS.Mvc.GiftShopApp.Controllers.Api
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController, IPasswordHasher
    {
        private readonly CoreDbContext context = new CoreDbContext();
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationManager _authenticationManager;
        private readonly ISignInManager _signInManager;
        private readonly IUserManager _userManager;

        public AccountController(IUserManager userManager, ISignInManager signInManager, IAuthenticationManager authenticationManager, IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationManager = authenticationManager;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Save([FromBody]CreateUserDto model)
        {

            var repeated = _userRepository.GetUserByName(model.UserName);

            if (repeated != null)
            {
                return BadRequest("User already exists!");
            }

            var user = new User { UserName = model.UserName, Email = model.Email, IsEmailConfirmed=model.IsEmailConfirmed };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                result = await _userManager.AddToRoleAsync(user.Id, Role.Client);

                if (result.Succeeded)
                {
                    return Ok();
                }

                var createdUser = _userRepository.GetUserByName(model.UserName);
                if (createdUser != null)
                {
                    await _userManager.DeleteAsync(createdUser);
                }
            }

            return BadRequest(result.Errors.FirstOrDefault());
        }

        public string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            throw new NotImplementedException();
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: true);
            var data = _userRepository.GetUserByEmail(model.UserName);
            switch (result)
            {
                case SignInStatus.Success:
                    return Ok(data);

                case SignInStatus.LockedOut:
                    return BadRequest();
                case SignInStatus.RequiresVerification:
                    return BadRequest();
                case SignInStatus.Failure:
                    return BadRequest(Resources.InvalidCredentials);
                default:
                    throw new InvalidEnumArgumentException("result", (int)result, typeof(SignInStatus));
            }
        }

        [Route("GetIdentity")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult GetIdentity()
        {

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId<int>();
                var data = _userRepository.GetIdentity(userId);

                return Ok(data);
            }
            return Ok();
        }

        [Route("Logout")]
        [HttpPost]
        public IHttpActionResult Logout()
        {

            if (User.Identity.IsAuthenticated)
            {
                _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

                return Ok();
            }

            return BadRequest();
        }

    }

}