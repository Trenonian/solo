using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solo.Models
{
    public class Vote
    {
        public User Voter { get; set; }
        private int _poll;
        public int Poll
        {
            get
            {
                return _poll;
            }
            set
            {
                if (value != 1 && value != 0 && value != -1)
                {
                    _poll = 0;
                }
                _poll = value;
            }
        }
    }
}
