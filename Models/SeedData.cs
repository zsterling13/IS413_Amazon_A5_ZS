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
                        Author = "Victor Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Category  = "Fiction, Classic",
                        Price = 9.95
                    },

                    new Book
                    {
                        //BookId = 2,
                        Title = "Team of Rivals",
                        Author = "Doris Kearns Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Category = "Non-Fiction, Biography",
                        Price = 14.58
                    },

                    new Book
                    {
                        //BookId = 3,
                        Title = "The Snowball",
                        Author = "Alice Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Category = "Non-Fiction, Biography",
                        Price = 21.54
                    },

                    new Book
                    {
                        //BookId = 4,
                        Title = "American Ulysses",
                        Author = "Ronald C. White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Category = "Non-Fiction, Biography",
                        Price = 11.61
                    },


                    new Book
                    {
                        //BookId = 5,
                        Title = "Unbroken",
                        Author = "Laura Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Category = "Non-Fiction, Historical ",
                        Price = 13.33,
                    },

                    new Book
                    {
                        //BookId = 6,
                        Title = "The Great Train Robbery",
                        Author = "Michael Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Category = "Fiction, Historical Fiction",
                        Price = 15.95
                    },

                    new Book
                    {
                        //BookId = 7,
                        Title = "Deep Work",
                        Author = "Cal Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Category = "Non-Fiction, Self-Help",
                        Price = 14.99
                    },

                    new Book
                    {
                        //BookId = 8,
                        Title = "It's Your Ship",
                        Author = "Michael Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Category = "Non-Fiction, Self-Help",
                        Price = 21.66
                    },

                    new Book
                    {
                        //BookId = 9,
                        Title = "The Virgin Way",
                        Author = "Richard Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Category = "Non-Fiction, Business",
                        Price = 29.16,
                    },
                    
                    new Book
                    {
                        //BookId = 10,
                        Title = "Sycamore Row",
                        Author = "John Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Category = "Fiction, Thrillers",
                        Price = 15.03,
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
