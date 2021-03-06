﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesLab2.Models
{
    public class Comment
    {
        public long Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        [MinLength(2, ErrorMessage = "Content must be longer than 2 chars")]
        public int MovieId { get; set; }
    }
}
