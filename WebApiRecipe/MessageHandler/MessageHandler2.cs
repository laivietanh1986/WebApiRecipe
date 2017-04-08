using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebApiRecipe.MessageHandler
{
    public class MessageHandler2:DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var respose = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent("Message Handler 2 Has interupt this")
            };
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(respose);
            return await tsc.Task;

        }
    }
}