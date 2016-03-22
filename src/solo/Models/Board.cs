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
        public void removePost(Post delPost)
        {
            Posts.Remove(delPost);
        }
        public List<User> Mods { get; set; }
        public void addMod(User newMod)
        {
            Mods.Add(newMod);
        }
        public void removeMod(User delMod)
        {
            Mods.Remove(delMod);
        }
        public List<User> Banned { get; set; }
        public void addBanned(User newBanned)
        {
            Banned.Add(newBanned);
        }
        public void removeBanned(User delBanned)
        {
            Banned.Remove(delBanned);
        }
        public List<User> Allowed { get; set; }
        public void addAllowed(User newAllowed)
        {
            Allowed.Add(newAllowed);
        }
        public void removeAllowed(User delAllowed)
        {
            Allowed.Remove(delAllowed);
        }
        public int Score { get; set; }
        public void ChangeScore(int delta)
        {
            Score += delta;
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
