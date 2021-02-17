using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS413_Amazon_A5_ZS.Models
{
    public class BookDBContext : DbContext
    {
        //Constructor for the class
        public BookDBContext (DbContextOptions<BookDBContext> options) : base (options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
    }
}
