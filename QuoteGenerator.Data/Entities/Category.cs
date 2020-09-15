﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuoteGeneratorAPI.Data.ApplicationUser;

namespace QuoteGenerator.Data
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public ICollection<Quote> QuoteFromCategory { get; set; }

    }
}
