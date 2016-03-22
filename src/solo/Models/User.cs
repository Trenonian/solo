using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solo.Models
{
    public class User
    {
        public int Id { get; set; }
        public int PostScore { get; private set; }
        public int CommentScore { get; private set; }

        public void ChangePostScore(int poll)
        {
            PostScore += poll;
        }
        public void ChangeCommentScore(int poll)
        {
            CommentScore += poll;
        }
    }
}
