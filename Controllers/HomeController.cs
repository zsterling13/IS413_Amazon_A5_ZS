using IS413_Amazon_A5_ZS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IS413_Amazon_A5_ZS.Models.ViewModels;

namespace IS413_Amazon_A5_ZS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //Create a private repository from IBookRepository
        private IBookRepository _repository;

        //Determines how many book items are displayed per page
        public int ItemsPerPage = 5;

        //Constructor for the HomeController, that mainly sets a few private variables with parameters
        public HomeController(ILogger<HomeController> logger, IBookRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        //Return the index/home page that queries the appropriate number of books as well as allows filters
        public IActionResult Index(string category, int pageNum = 1)
        {
            return View(new BookListViewModel
                //Query to get the correct book information for each page
                {
                    Books = _repository.Books
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.BookId)
                .Skip((pageNum - 1) * ItemsPerPage)
                .Take(ItemsPerPage)
                ,
                //Modify certain attributes of the PagingInfo object in the BookListViewModel class
                PagingInfo = new PagingInfo
                    {  
                        CurrentPage = pageNum,
                        ItemsPerPage = ItemsPerPage,

                        //If statement to determine the correct number of page options that is displayed under the table
                        TotalNumItems = category == null ? _repository.Books.Count() :
                            _repository.Books.Where(x => x.Category == category).Count()
                    },
                CurrentCategory = category
                }
            );
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
