using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaDatabase.Infrastructure
{
    public static class UrlExtensions
    {
        //   F i e l d s   &   P r o p e r t i e s

        //   C o n s t r u c t o r s

        //   M e t h o d s

        public static string PathAndQuery
           (this HttpRequest request)
        {
            if (request.QueryString.HasValue)
            {
                return $"{request.Path}{request.QueryString}";
            }
            return request.Path.ToString();
        }

    }
}
