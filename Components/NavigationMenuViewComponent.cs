using IS413_Amazon_A5_ZS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS413_Amazon_A5_ZS.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBookRepository _repository;

        //set the private _repository variable when this object is first loaded
        public NavigationMenuViewComponent (IBookRepository r)
        {
            _repository = r;
        }

        public IViewComponentResult Invoke()
        {
            //Store the currently selected category that is present in the URL in the viewbag to dynamically highlight the button for the current
            //category
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(_repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
