﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteGenerator.Data
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
        
        public ICollection<Quote> AuthorQuotes { get; set; }
    }
}
