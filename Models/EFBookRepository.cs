using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS413_Amazon_A5_ZS.Models
{
    //Create a class that inherits from IBookRepository and creates a private context variable
    public class EFBookRepository : IBookRepository
    {
        private BookDBContext _context;

        //Constructor for the class
        public EFBookRepository (BookDBContext context)
        {
            _context = context;
        }

        public IQueryable<Book> Books => _context.Books;
    }
}
