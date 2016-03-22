using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solo.Models
{
    public abstract class Voteable
    {
        public int Id { get; set; }
        public User Creator { get; set; }
        public Board ParentBoard { get; set; }
        public string Content { get; set; }
        public void EditContent(User newUser, string newContent)
        {
            Edits.Add(new Edit
            {
                Time = DateTime.Now,
                OldContent = Content
            });
            Content = newContent;
        }
        public DateTime Created { get; set; }
        private List<Edit> Edits;
        public List<Comment> Comments { get; set; }
        public void addComment(Comment newComment)
        {
            newComment.ParentBoard = ParentBoard;
            Comments.Add(newComment);
        }
        public void removeComment(Comment delComment, User deleter)
        {
            if (ParentBoard.Mods.Contains(deleter))
            {
                Comments.Remove(delComment);
            }
        }
        public int Score { get; private set; }
        public abstract void ChangeScore(int delta);
        public bool HasVoted(User votedUser)
        {
            return Votes.Exists(x => x.Voter.Id == votedUser.Id);
        }
        public int CheckVote(User checkUser)
        {
            return Votes.FindIndex(x => x.Voter.Id == checkUser.Id);
        }
        public List<Vote> Votes { get; set; }
        public void upVote(User upUser)
        {
            if (!HasVoted(upUser))
            {
                Votes.Add(new Vote()
                {
                    Voter = upUser,
                    Poll = 1
                });
                ChangeScore(1);
                return;
            }
            int oldVote = CheckVote(upUser);
            switch (Votes[oldVote].Poll)
            {
                case 1:
                    Votes[oldVote].Poll = 0;
                    ChangeScore(-1);
                    break;
                case 0:
                    ChangeScore(1);
                    Votes[oldVote].Poll = 1;
                    break;
                case -1:
                    ChangeScore(2);
                    Votes[oldVote].Poll = 1;
                    break;
            }
        }
        public void downVote(User downUser)
        {
            if (!HasVoted(downUser))
            {
                Votes.Add(new Vote()
                {
                    Voter = downUser,
                    Poll = -1
                });
                ChangeScore(-1);
                return;
            }
            int oldVote = CheckVote(downUser);
            switch (Votes[oldVote].Poll)
            {
                case -1:
                    Votes[oldVote].Poll = 0;
                    ChangeScore(1);
                    break;
                case 0:
                    ChangeScore(-1);
                    Votes[oldVote].Poll = -1;
                    break;
                case 1:
                    ChangeScore(-2);
                    Votes[oldVote].Poll = -1;
                    break;
            }
        }
    }
}
