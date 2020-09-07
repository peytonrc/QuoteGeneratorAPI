using QuoteGeneratorAPI.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
        [ForeignKey(nameof(QuoteUser))]
        public double Rating { get; set; } 
        public virtual QuoteUser QuoteUser { get; set; }

    }
}
