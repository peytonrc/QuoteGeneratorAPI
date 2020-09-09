
using QuoteGeneratorAPI.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuoteGenerator.Data
{
    public class UserRatingQuote
    {
        [Key]
        public int UserRatingQuoteId { get; set; }

        [Required]
        [ForeignKey(nameof(Quote))]
        public int QuoteId { get; set; }
        public virtual Quote Quote { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public double UserRating { get; set; }

    }
}
