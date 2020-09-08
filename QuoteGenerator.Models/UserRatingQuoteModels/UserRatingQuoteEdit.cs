using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteGenerator.Models.UserRatingQuoteModels
{
     public class UserRatingQuoteEdit
    {
        [Required]
        public int UserRatingQuoteId { get; set; }

        [Required]
        [Display(Name = "Rating")]
        [Range(1, 5, ErrorMessage = "Please enter a number between 1 and 5")]
        public double UserRating { get; set; }
    }
}
