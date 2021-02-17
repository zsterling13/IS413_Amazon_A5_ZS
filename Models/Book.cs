using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IS413_Amazon_A5_ZS.Models
{
    public class Book
    {
        [Key, Required]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author_First_Name { get; set; }

        public string Author_Middle_In { get; set; } = "";

        [Required]
        public string Author_Last_Name { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required, RegularExpression("[0-9]{3}-[0-9]{10}")]
        public string ISBN { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Classification { get; set; }

        [Required]
        public double Price { get; set; }

    }
}
