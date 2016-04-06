using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solo.Services.Models
{
    public class TagDTO
    {
        public int Id { get; set; }
        public ApplicationUserDTO Creator { get; set; }
        public ApplicationUserDTO Target { get; set; }
        public string Content { get; set; }
    }
}
