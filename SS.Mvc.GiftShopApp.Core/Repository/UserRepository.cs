using SS.Mvc.GiftShopApp.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Mvc.GiftShopApp.Core.Models;
using SS.Data.EntityFramework;
using SS.Mvc.GiftShopApp.Core.Models.dto;
using System.Data.Entity;

namespace SS.Mvc.GiftShopApp.Core.Repository
{
    public class UserRepository : EfRepositoryBase<User>, IUserRepository
    {
        public UserRepository(IWorkspace workspace) :base(workspace) 
        {
        }
        
        public UserDto GetUserByEmail(string email)
        {
            var user = ReadOnlyWorkspace.Query<User>(x => x.Email == email, x => x.Roles).FirstOrDefault();
            var roleId = user.Roles.First().RoleId;

            var result = new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };

            if (user.Roles.Any())
            {
                
                var role = ReadOnlyWorkspace.Query<Role>(x => x.Id == roleId).FirstOrDefault();
                if(role != null)
                {
                    result.Role = role.Name;
                }
            }


            return result;
        }

        public List<User> GetUsers()
        {
            return ReadOnlyWorkspace.Query<User>().ToList();
        }

        public void AddUser(User user)
        {
            this.Add(user);
            this.SaveChanges();
        }
        public User GetUserByName(string name)
        {
            var user = ReadOnlyWorkspace.Query<User>().FirstOrDefault(x => x.UserName == name);

            return user;
        }



        public UserDto GetIdentity(int userId)
        {
           // var user1 = ReadOnlyWorkspace.Query<User>(x => x.Id == userId, x => x.Roles).Include(u => u.Roles).FirstOrDefault();
            var user = ReadOnlyWorkspace.Query<User>(x => x.Id == userId, x => x.Roles).FirstOrDefault();
            var roleId = user.Roles.First().RoleId;

            var result = new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };

            if (user.Roles.Any())
            {

                var role = ReadOnlyWorkspace.Query<Role>(x => x.Id == roleId).FirstOrDefault();
                if (role != null)
                {
                    result.Role = role.Name;
                }
            }

            return result;
        }

       
    }
}
