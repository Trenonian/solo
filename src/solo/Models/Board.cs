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
        public List<Post> Posts { get; set; }
        public void AddPost(Post newPost)
        {
            newPost.ParentBoard = this;
            Posts.Add(newPost);
        }
        public void RemovePost(Post delPost)
        {
            Posts.Remove(delPost);
        }
        public List<User> Mods { get; set; }
        public void AddMod(User newMod)
        {
            Mods.Add(newMod);
        }
        public void RemoveMod(User delMod)
        {
            Mods.Remove(delMod);
        }
        public List<User> Banned { get; set; }
        public void addBanned(User newBanned)
        {
            Banned.Add(newBanned);
        }
        public void RemoveBanned(User delBanned)
        {
            Banned.Remove(delBanned);
        }
        public List<User> Allowed { get; set; }
        public void addAllowed(User newAllowed)
        {
            Allowed.Add(newAllowed);
        }
        public void RemoveAllowed(User delAllowed)
        {
            Allowed.Remove(delAllowed);
        }
        public bool Restricted { get; set; }
        public void SetRestricted(bool locked, User user)
        {
            if (Mods.Contains(user))
            {
                Restricted = locked;
            }
        }
    }

}
