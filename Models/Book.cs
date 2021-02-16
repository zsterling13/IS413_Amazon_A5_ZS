using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IS413_Amazon_A5_ZS.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required, RegularExpression("[7,9,8]{3}-[0-9]{10}")]
        public string ISBN { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public double Price { get; set; }

    }
}
