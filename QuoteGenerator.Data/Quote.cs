using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace QuoteGenerator.Data
{
    public class Quote
    {
        [Key]
        public int QuoteId { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string Content { get; set; }
        
        public DateTime DateSpoken { get; set; }
        
        public double Rating { get; set; }
    }
}
