using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS413_Amazon_A5_ZS.Models.ViewModels
{
    public class PagingInfo
    {
        //Getters and setters for some important variables that are used for creating pages for the website
        public int TotalNumItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        //Create a TotalPages variable that receives a rounded value of the total number of items available divided by the 
        //items per page value
        public int TotalPages => (int)(Math.Ceiling((decimal) TotalNumItems / ItemsPerPage));


    }
}
