using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS413_Amazon_A5_ZS.Models
{
    //Create a queriable book object
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
