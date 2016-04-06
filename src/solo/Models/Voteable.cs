using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace solo.Models
{
    public abstract class Voteable
    {
        public int CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public ApplicationUser Creator { get; set; }

        public int ParentBoardId { get; set; }
        [ForeignKey("ParentBoardId")]
        public Board ParentBoard { get; set; }

        public DateTime Created { get; set; }
        public bool Deleted { get; set; }
        public string Content { get; set; }
        public int Score { get; set; }

        public ICollection<Edit> Edits;
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Vote> Votes { get; set; }

        //public abstract void Delete();
        
        //public void EditContent(User newUser, string newContent)
        //{
        //    Edits.Add(new Edit
        //    {
        //        Time = DateTime.Now,
        //        OldContent = Content
        //    });
        //    Content = newContent;
        //}
        //public void RemoveComment(Comment delComment)
        //{
        //    Comments.Remove(delComment);
        //}
        //public void AddComment(Comment newComment)
        //{
        //    newComment.ParentBoard = ParentBoard;
        //    Comments.Add(newComment);
        //}
        //public abstract void ChangeScore(int delta);
        //public bool HasVoted(User votedUser)
        //{
        //    return Votes.Any(x => x.Voter.Id == votedUser.Id);
        //}
        //public Vote CheckVote(User checkUser)
        //{
        //    return Votes.FirstOrDefault(x => x.Voter.Id == checkUser.Id);
        //}
        //public void UpVote(User upUser)
        //{
        //    if (!HasVoted(upUser))
        //    {
        //        Votes.Add(new Vote()
        //        {
        //            Voter = upUser,
        //            Poll = 1
        //        });
        //        ChangeScore(1);
        //        return;
        //    }
        //    Vote oldVote = CheckVote(upUser);
        //    switch (oldVote.Poll)
        //    {
        //        case 1:
        //            oldVote.Poll = 0;
        //            Votes.Remove(oldVote);
        //            ChangeScore(-1);
        //            break;
        //        case 0:
        //            ChangeScore(1);
        //            oldVote.Poll = 1;
        //            break;
        //        case -1:
        //            ChangeScore(2);
        //            oldVote.Poll = 1;
        //            break;
        //    }
        //}
        //public void DownVote(User downUser)
        //{
        //    if (!HasVoted(downUser))
        //    {
        //        Votes.Add(new Vote()
        //        {
        //            Voter = downUser,
        //            Poll = -1
        //        });
        //        ChangeScore(-1);
        //        return;
        //    }
        //    Vote oldVote = CheckVote(downUser);
        //    switch (oldVote.Poll)
        //    {
        //        case -1:
        //            Votes.Remove(oldVote);
        //            ChangeScore(1);
        //            break;
        //        case 0:
        //            ChangeScore(-1);
        //            oldVote.Poll = -1;
        //            break;
        //        case 1:
        //            ChangeScore(-2);
        //            oldVote.Poll = -1;
        //            break;
        //    }
        //}
    }
}
