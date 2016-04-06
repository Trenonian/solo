using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solo.Services.Models
{
    public abstract class VoteableDTO
    {
        public ApplicationUserDTO User { get; set; }
        public BoardDTO ParentBoard { get; set; }
        public DateTime Created { get; set; }
        public bool Deleted { get; set; }
        public string Content { get; set; }
        public int Score { get; set; }
        public ICollection<EditDTO> Edits { get; set; }
        public ICollection<CommentDTO> Comments { get; set; }
        public ICollection<VoteDTO> Votes { get; set; }
    }
}
