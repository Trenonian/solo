using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solo.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Restricted { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<UserBoard> Moderators { get; set; }
        public ICollection<ApplicationUser> Banned { get; set; }
        public ICollection<ApplicationUser> Allowed { get; set; }


        //public void AddPost(Post newPost)
        //{
        //    newPost.ParentBoard = this;
        //    Posts.Add(newPost);
        //}
        //public void RemovePost(Post delPost)
        //{
        //    Posts.Remove(delPost);
        //}
        //public void AddMod(User newMod)
        //{
        //    Moderators.Add(
        //        new UserBoard() {
        //            User = newMod,
        //            Board = this
        //        }
        //    );
        //}
        //public void addBanned(User newBanned)
        //{
        //    Banned.Add(newBanned);
        //}
        //public void RemoveBanned(User delBanned)
        //{
        //    Banned.Remove(delBanned);
        //}
        //public void addAllowed(User newAllowed)
        //{
        //    Allowed.Add(newAllowed);
        //}
        //public void RemoveAllowed(User delAllowed)
        //{
        //    Allowed.Remove(delAllowed);
        //}
        //public void SetRestricted(bool locked, User user)
        //{
        //    if (Moderators.FirstOrDefault(u => u.User == user) != null)
        //    {
        //        Restricted = locked;
        //    }
        //}
        //public void SetRestricted(bool locked, Admin admin)
        //{
        //    Restricted = locked;
        //}
    }

}
