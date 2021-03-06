using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace solo.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Signature { get; set; }
        public int PostScore { get; set; }
        public int CommentScore { get; set; }
        public ICollection<Tag> Tagged { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }

        //public ICollection<UserBoard> ModdedBoards { get; set; }
        //public bool IsAdmin { get; set; }

        //public void AddTag(Tag newTag)
        //{
        //    Tagged.Add(newTag);
        //}
        //public void RemoveTag(Tag delTag)
        //{
        //    Tagged.Remove(delTag);
        //}
        //public void AddPost(Post newPost)
        //{
        //    Posts.Add(newPost);
        //}
        //public void DeletePost(Post delPost)
        //{
        //    if (ModdedBoards.FirstOrDefault(b => b.Board == delPost.ParentBoard) != null || delPost.Creator == this)
        //    {
        //        delPost.Creator.Posts.Remove(delPost);
        //        delPost.Delete();
        //    }
        //}
        //public void AddComment(Comment newComment)
        //{
        //    Comments.Add(newComment);
        //}
        //public void DeleteComment(Comment delComment)
        //{
        //    if (ModdedBoards.FirstOrDefault(u => u.Board == delComment.ParentBoard) != null || delComment.Creator == this)
        //    {
        //        delComment.Creator.Comments.Remove(delComment);
        //        delComment.Delete();
        //    }
        //}
        //public void ChangePostScore(int poll)
        //{
        //    PostScore += poll;
        //}
        //public void ChangeCommentScore(int poll)
        //{
        //    CommentScore += poll;
        //}
        //public void AddMod(Board modBoard, ApplicationUser currentMod)
        //{
        //    if (ModdedBoards.FirstOrDefault(u => u.User == currentMod) != null)
        //    {
        //        ModdedBoards.Add(
        //            new UserBoard()
        //            {
        //                User = this,
        //                Board = modBoard
        //            }
        //        );
        //    }

        //}
        //public void AddMod(Board modBoard, Admin admin)
        //{
        //    ModdedBoards.Add(
        //        new UserBoard()
        //        {
        //            User = this,
        //            Board = modBoard
        //        }
        //    );

        //}
    }
}
