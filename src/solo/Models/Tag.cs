using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solo.Models
{
    public class Tag
    {
        public int Id { get; set; }

        public int CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }

        public int TargetId { get; set; }
        public ApplicationUser Target { get; set; }

        public string Content { get; set; }
    }
}
