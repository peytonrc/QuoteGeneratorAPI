using QuoteGenerator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteGenerator.Models.QuoteModels
{
    public class QuoteCreate
    {
        [Required]
        [MinLength(5, ErrorMessage = "This quote needs at least 5 characters")]
        [MaxLength(500, ErrorMessage = "This quote cannot exceed 500 characters")]
        [Display(Name = "Quote")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Author")]
        public int AuthorId { get; set; }
      
        [Required]
        [Display (Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Date Spoken YYYY/MM/DD")]
        public DateTime DateSpoken { get; set; }
    }
}
