using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solo.Models
{
    public class Comment : Voteable
    {
        public Post ParentPost { get; set; }
        public override void ChangeScore(int delta)
        {
            if (delta != 1 && delta != -1)
            {
                return;
            }
            Creator.ChangeCommentScore(delta);
            Score += delta;
        }
        public override void Delete()
        {
            Creator.ChangeCommentScore(-Score);
            Creator = null;
        }
    }
}
