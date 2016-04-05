using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace solo.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public int VoterId { get; set; }
        public ApplicationUser Voter { get; set; }

        public int TargetId { get; set; }
        public Voteable Target { get; set; }

        private int _poll;
        //[NotMapped]
        public int Poll
        {
            get
            {
                if (_poll != 1 || _poll != -1)
                {
                    return _poll;
                }
                return 0;
            }
            set
            {
                _poll = value;
            }
        }
    }
}
