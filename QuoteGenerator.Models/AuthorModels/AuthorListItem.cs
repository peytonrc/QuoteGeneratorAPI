using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteGenerator.Models
{
    public class AuthorListItem
    {
        public int AuthorId { get; set; }

        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime BirthDate { get; set; }
        public bool IsUserOwned { get; set; }

    }
}
