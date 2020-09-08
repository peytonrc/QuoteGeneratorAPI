using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteGenerator.Data
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public Guid CreatorId { get; set; }
        
        public ICollection<Quote> QuoteFromCategory { get; set; }

    }
}
