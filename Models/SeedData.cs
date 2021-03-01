﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS413_Amazon_A5_ZS.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            BookDBContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookDBContext>();

            //If database has pending migrations then move those migrations into the database
            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            //If database does not have any books in it then populate it with the following data
            if(!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book
                    {
                        //BookId = 1,
                        Title = "Les Miserables",
                        Author_First_Name = "Victor",
                        Author_Last_Name = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification  = "Fiction",
                        Category = "Classic",
                        Price = 9.95,
                        Page_Num = 1488
                    },

                    new Book
                    {
                        //BookId = 2,
                        Title = "Team of Rivals",
                        Author_First_Name = "Doris",
                        Author_Middle_In = "K", 
                        Author_Last_Name = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58,
                        Page_Num = 944
                    },

                    new Book
                    {
                        //BookId = 3,
                        Title = "The Snowball",
                        Author_First_Name = "Alice",
                        Author_Last_Name = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54,
                        Page_Num = 832
                    },

                    new Book
                    {
                        //BookId = 4,
                        Title = "American Ulysses",
                        Author_First_Name = "Ronald",
                        Author_Middle_In = "C",
                        Author_Last_Name = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 11.61,
                        Page_Num = 864
                    },


                    new Book
                    {
                        //BookId = 5,
                        Title = "Unbroken",
                        Author_First_Name = "Laura",
                        Author_Last_Name = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.33,
                        Page_Num = 528
                    },

                    new Book
                    {
                        //BookId = 6,
                        Title = "The Great Train Robbery",
                        Author_First_Name = "Michael",
                        Author_Last_Name = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 15.95,
                        Page_Num = 288
                    },

                    new Book
                    {
                        //BookId = 7,
                        Title = "Deep Work",
                        Author_First_Name = "Cal",
                        Author_Last_Name = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 14.99,
                        Page_Num = 304
                    },

                    new Book
                    {
                        //BookId = 8,
                        Title = "It's Your Ship",
                        Author_First_Name = "Michael",
                        Author_Last_Name = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 21.66,
                        Page_Num = 240
                    },

                    new Book
                    {
                        //BookId = 9,
                        Title = "The Virgin Way",
                        Author_First_Name = "Richard",
                        Author_Last_Name = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = 29.16,
                        Page_Num = 400
                    },
                    
                    new Book
                    {
                        //BookId = 10,
                        Title = "Sycamore Row",
                        Author_First_Name = "John",
                        Author_Last_Name = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = 15.03,
                        Page_Num = 642
                    },

                    new Book
                    {
                        //BookId = 11,
                        Title = "The Name of the Wind",
                        Author_First_Name = "Patrick",
                        Author_Last_Name = "Rothfuss",
                        Publisher = "Penguin Books",
                        ISBN = "978-0583493633",
                        Classification = "Fiction",
                        Category = "Fantasy",
                        Price = 35.99,
                        Page_Num = 488
                    },

                    new Book
                    {
                        //BookId = 12,
                        Title = "The Great Gatsby",
                        Author_First_Name = "F",
                        Author_Middle_In = "S",
                        Author_Last_Name = "Fitzgerald",
                        Publisher = "Squire & Co.",
                        ISBN = "978-0533933660",
                        Classification = "Fiction",
                        Category = "Drama",
                        Price = 13.99,
                        Page_Num = 153
                    },

                    new Book
                    {
                        //BookId = 13,
                        Title = "Brave New World",
                        Author_First_Name = "Aldous",
                        Author_Last_Name = "Huxley",
                        Publisher = "Chatto and Windus",
                        ISBN = "978-0559334113",
                        Classification = "Fiction",
                        Category = "Dystopia",
                        Price = 5.99,
                        Page_Num = 121
                    }
                );

                //Save changes
                context.SaveChanges();
            }
        }
    }
}
