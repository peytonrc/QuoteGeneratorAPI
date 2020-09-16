using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuoteGeneratorAPI.Data.ApplicationUser;

namespace QuoteGenerator.Models
{
    public class CategoryEdit
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 1 character.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }
    }
}
