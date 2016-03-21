using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solo.Models
{
    public class Board
    {
        private int _id;
        public int Id {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
        }
        private List<Post> _posts;
        public List<Post> Posts
        {
            get
            {
                return _posts;
            }
        }
        public void AddPost(Post newPost)
        {
            _posts.Add(newPost);
        }
        public void removePost(Post delPost)
        {
            _posts.Remove(delPost);
        }
        private List<User> _mods;
        public List<User> Mods
        {
            get
            {
                return _mods;
            }
        }
        public void addMod(User newMod)
        {
            _mods.Add(newMod);
        }
        public void removeMod(User delMod)
        {
            _mods.Remove(delMod);
        }
        private List<User> _banned;
        public List<User> Banned
        {
            get
            {
                return _banned;
            }
        }
        public void addBanned(User newBanned)
        {
            _banned.Add(newBanned);
        }
        public void removeBanned(User delBanned)
        {
            _banned.Remove(delBanned);
        }
        private List<User> _allowed;
        public List<User> Allowed
        {
            get
            {
                return _allowed;
            }
        }
        public void addAllowed(User newAllowed)
        {
            _allowed.Add(newAllowed);
        }
        public void removeAllowed(User delAllowed)
        {
            _allowed.Remove(delAllowed);
        }
        private int _score;
        public int Score
        {
            get
            {
                return _score;
            }
        }
        public void ChangeScore(int delta)
        {
            _score += delta;
        }
        Board(string name, User creator) {
            _id = ;
            _name = name;
            _posts = new List<Post>();
            _mods = new List<User>();
            _allowed = new List<User>();
            _banned = new List<User>();
            _mods.Add(creator);
        }
}

}
