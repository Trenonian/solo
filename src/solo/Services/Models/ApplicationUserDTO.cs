using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solo.Services.Models
{
    public class ApplicationUserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Signature { get; set; }
        public int PostScore { get; set; }
        public int CommentScore { get; set; }
        public ICollection<TagDTO> Tagged { get; set; }
        public ICollection<PostDTO> Posts { get; set; }
        public ICollection<CommentDTO> Comments { get; set; }
    }
}
