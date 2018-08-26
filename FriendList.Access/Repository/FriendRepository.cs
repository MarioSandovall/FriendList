using FriendList.Access.Dtos;
using FriendList.Access.Model;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace FriendList.Access.Repository
{
    public class FriendRepository
    {
        public void Add(FriendDto friend)
        {
            using (var ctx = new FriendListContext())
            {
                var newFriend = new Friend()
                {
                    Id = friend.Id,
                    Name = friend.Name,
                    LastName = friend.LastName
                };

                ctx.Friends.Add(newFriend);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<FriendDto> GetAll()
        {
            using (var ctx = new FriendListContext())
            {
                return ctx.Friends.Select(x => new FriendDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    LastName = x.LastName
                }).ToList();
            }
        }

        public void Remove(int friendId)
        {
            using (var ctx = new FriendListContext())
            {
                var friend = ctx.Friends.Single(x => x.Id == friendId);
                ctx.Friends.Remove(friend);
                ctx.SaveChanges();
            }
        }

        public void Update(FriendDto friendDto)
        {
            using (var ctx = new FriendListContext())
            {
                var friend = ctx.Friends.Single(x => x.Id == friendDto.Id);
                friend.Name = friendDto.Name;
                friend.LastName = friendDto.LastName;

                ctx.Friends.AddOrUpdate(friend);
                ctx.SaveChanges();
            }
        }
    }
}
