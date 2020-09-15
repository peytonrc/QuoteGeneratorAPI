using QuoteGenerator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuoteGeneratorAPI.Data.ApplicationUser;

namespace QuoteGenerator.Models.QuoteModels
{
    public class QuoteDetail
    {
        public int QuoteId { get; set; }

        [Display(Name = "Quote")]
        public string Content { get; set; }


        public int AuthorId { get; set; }
        [Display(Name = "Author")]
        public string AuthorName { get; set; }


        public int CategoryId { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }


        [Display(Name = "Date Spoken YYYY/MM/DD")]
        public DateTime DateSpoken { get; set; }

        public double AverageRating { get; set; }
    }
}
