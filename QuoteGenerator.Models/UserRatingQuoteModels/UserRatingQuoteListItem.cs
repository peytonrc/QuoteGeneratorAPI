using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteGenerator.Models.UserRatingQuoteModels
{
    public class UserRatingQuoteListItem
    {
        public int UserRatingQuoteId { get; set; }

        public int QuoteId { get; set; }

        public string UserId { get; set; }

        public double UserRating { get; set; }

        public int CategoryId { get; set; }
        
    }
}
