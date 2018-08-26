using FriendList.Access.Model;
using System.Data.Entity;

namespace FriendList.Access
{
    public class FriendListContext : DbContext
    {
        public FriendListContext() : base("FriendList") { }

        public DbSet<Friend> Friends { get; set; }
    }
}
