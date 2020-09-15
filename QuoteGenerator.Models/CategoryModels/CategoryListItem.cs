using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuoteGeneratorAPI.Data.ApplicationUser;

namespace QuoteGenerator.Models
{
    public class CategoryListItem
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
      
    }
}
