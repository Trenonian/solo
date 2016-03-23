using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solo.Models
{
    public class Post : Voteable
    {
        public string Title { get; set; }
        public override void ChangeScore(int delta)
        {
            if (delta != 1 && delta != -1)
            {
                return;
            }
            Creator.ChangePostScore(delta);
            Score += delta;
        }
        public override void Delete()
        {
            Creator.ChangePostScore(-Score);
            Creator = null;
        }
    }
}
