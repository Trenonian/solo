using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solo.Models
{
    public class Edit
    {
        public int Id { get; set; }

        public int ParentId { get; set; }
        public Voteable Parent { get; set; }

        public DateTime Time { get; set; }
        public string Content { get; set; }
    }
}
