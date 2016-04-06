using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solo.Services.Models
{
    public class VoteDTO
    {
        public int Id { get; set; }
        public ApplicationUserDTO Voter { get; set; }
        public VoteableDTO Target { get; set; }
        public bool isUpVote { get; set; }
    }
}
