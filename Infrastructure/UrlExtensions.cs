using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS413_Amazon_A5_ZS.Infrastructure
{
    public static class UrlExtensions
    {
        //Creates a static variable for the UrlExtensions class that dynamically helps with querying
        //If the http request has a query string in it then return the correct path associated with the query string, else just return
        //the URL's requested path
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
    }
}
