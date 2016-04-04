using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solo.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public int VoterId { get; set; }
        public User Voter { get; set; }

        public int TargetId { get; set; }
        public Voteable Target { get; set; }

        private int _poll;
        public int Poll
        {
            get
            {
                return _poll;
            }
            set
            {
                if (value != 1 && value != -1)
                {
                    value = 0;
                }
                _poll = value;
            }
        }
    }
}
