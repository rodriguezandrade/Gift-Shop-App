using SS.Model;
using System;

namespace SS.Mvc.GiftShopApp.Core.Models
{
    public class UserRole : IEquatable<UserRole>, IEntity
    {
        public int Id { get; set; }
        
        public Role Role { get; set; }

        public int RoleId { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public bool Equals(UserRole other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            return RoleId == other.RoleId && UserId == other.UserId;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as UserRole);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (RoleId * 397) ^ UserId;
            }
        }
    }
}