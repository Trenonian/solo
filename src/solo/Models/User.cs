using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solo.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Signature { get; set; }
        public List<Tag> Tagged { get; set; }
        public void AddTag(Tag newTag)
        {
            Tagged.Add(newTag);
        }
        public void RemoveTag(Tag delTag)
        {
            Tagged.Remove(delTag);
        }
        public List<Post> Posts { get; set; }
        public void AddPost(Post newPost)
        {
            Posts.Add(newPost);
        }
        public void DeletePost(Post delPost)
        {
            if (ModdedBoards.Contains(delPost.ParentBoard) || delPost.Creator == this)
            {
                delPost.Creator.Posts.Remove(delPost);
                delPost.Delete();
            }
        }
        public List<Comment> Comments { get; set; }
        public void AddComment(Comment newComment)
        {
            Comments.Add(newComment);
        }
        public void DeleteComment(Comment delComment)
        {
            if (ModdedBoards.Contains(delComment.ParentBoard) || delComment.Creator == this)
            {
                delComment.Creator.Comments.Remove(delComment);
                delComment.Delete();
            }
        }
        public int PostScore { get; set; }
        public int CommentScore { get; set; }

        public void ChangePostScore(int poll)
        {
            PostScore += poll;
        }
        public void ChangeCommentScore(int poll)
        {
            CommentScore += poll;
        }
        public List<Board> ModdedBoards { get; set; }
    }
}
