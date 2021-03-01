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

        public HomeController(ILogger<HomeController> logger, IBookRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        //Return the index/home page that queries the appropriate number of books
        public IActionResult Index(int page = 1)
        {
            return View(new BookListViewModel
                //Query to get the correct book information for each page
                {
                    Books = _repository.Books
                .OrderBy(p => p.BookId)
                .Skip((page - 1) * ItemsPerPage)
                .Take(ItemsPerPage)
                ,
                //Modify certain attributes of the PagingInfo object in the BookListViewModel class
                PagingInfo = new PagingInfo
                    {  
                        CurrentPage = page,
                        ItemsPerPage = ItemsPerPage,
                        TotalNumItems = _repository.Books.Count()
                    }
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
