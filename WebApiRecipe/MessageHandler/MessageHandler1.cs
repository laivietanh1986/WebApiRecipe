using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebApiRecipe.MessageHandler
{
    public class MessageHandler1:DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Go inside Message Handler 1 request");
            var respose = await base.SendAsync(request, cancellationToken);
            Debug.WriteLine("Go inside Message Handler 1 respose ");
            return respose;
        }
    }
}