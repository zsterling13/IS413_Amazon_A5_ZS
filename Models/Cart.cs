using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS413_Amazon_A5_ZS.Models
{
    public class Cart
    {
        //Create new list object that stores cart lines
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        //Method that adds a book item to the list object Lines
        public virtual void AddItem (Book leBook, int quant)
        {
            CartLine line = Lines.Where(p => p.Book.BookId == leBook.BookId).FirstOrDefault();

            //If the line is empty then add a new cartline object, else concatenate to the already made item
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = leBook,
                    Quantity = quant
                });
            }
            else
            {
                line.Quantity += quant;
            }
        }

        //Method that removes a list item
        public virtual void RemoveLine(Book bigBook) =>
            Lines.RemoveAll(x => x.Book.BookId == bigBook.BookId);

        //Method that clears all books in the cart
        public virtual void Clear() => Lines.Clear();

        //Dynamically compute the total price by referencing the correct values stored in the model
        public decimal ComputeTotalSum() => Lines.Sum(e => (decimal)e.Book.Price * e.Quantity);

        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
