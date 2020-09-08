using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteGenerator.Models.UserRatingQuoteModels
{
   public class UserRatingQuoteCreate
    {
        [Required]
        public int QuoteId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Please enter a number between 1 and 5")]
        public double UserRating { get; set; }
    }
}
