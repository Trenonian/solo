using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solo.Services.Models
{
    public class EditDTO
    {
        public int Id { get; set; }
        public VoteableDTO Parent { get; set; }
        public DateTime Time { get; set; }
        public string Content { get; set; }
    }
}
