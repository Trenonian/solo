﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solo.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
    }
}
