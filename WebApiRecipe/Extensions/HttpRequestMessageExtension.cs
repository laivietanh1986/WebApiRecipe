using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WebApiRecipe.Extensions
{
    public static class HttpRequestMessageExtension
    {
        public static bool IsAjaxRequest(this HttpRequestMessage request)
        {
            IEnumerable<string> headers;
            if (request == null)
                throw new ArgumentNullException("request");
            if (request.Headers.TryGetValues("X-Requested-With", out headers))
            {
                 var header = headers.FirstOrDefault();
                if (!string.IsNullOrEmpty(header))
                {
                    return header.ToLowerInvariant() == "xmlhttprequest";
                }
            }
            return false;
        }
    }
}