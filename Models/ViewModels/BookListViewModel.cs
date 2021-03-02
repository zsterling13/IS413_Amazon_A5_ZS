using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS413_Amazon_A5_ZS.Models.ViewModels
{
    public class BookListViewModel
    {
        //Enumerable/iterative object based on the book class
        public IEnumerable<Book> Books { get; set; }

        //Information on paging object
        public PagingInfo PagingInfo { get; set; }

        //Keeps track of what category is currently being used to filter
        public string CurrentCategory { get; set; }
    }
}
