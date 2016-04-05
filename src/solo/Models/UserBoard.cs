using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solo.Models
{
    public class UserBoard
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public Board Board { get; set; }
    }
}
