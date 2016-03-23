using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solo.Models
{
    public class Admin : User
    {
        public void RemoveBoard(Board delBoard)
        {
            //AllBoards.Remove(delBoard);
        }
        public void RemovePost(Post delPost)
        {
            delPost.ParentBoard.RemovePost(delPost);
        }
        public void RemoveComment(Comment delComment)
        {
            delComment.ParentPost.RemoveComment(delComment);
        }
    }
}
