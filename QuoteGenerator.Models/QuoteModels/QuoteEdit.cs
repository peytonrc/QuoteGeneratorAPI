using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteGenerator.Models.QuoteModels
{
    public class QuoteEdit
    {
        [Required]
        public int QuoteId { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "This quote needs at least 5 characters")]
        [MaxLength(500, ErrorMessage = "This quote cannot exceed 500 characters")]
        [Display(Name = "Quote")]
        public string Content { get; set; }

        [Display(Name = "Date Spoken YYYY/MM/DD")]
        public DateTime DateSpoken { get; set; }

       
    }
}
