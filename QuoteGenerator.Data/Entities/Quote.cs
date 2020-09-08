using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public Guid OwnerId { get; set; }


        [Required]
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }


        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


        [Required]
        public string Content { get; set; }
        
        public DateTime DateSpoken { get; set; }
        

       // public double Rating { get; set; } // Add foreign key
    }
}
