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
    public class CheckApiKeyMessageHandler:DelegatingHandler
    {
        private string key = null;

        public CheckApiKeyMessageHandler(string inputKey)
        {
            key = inputKey;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!ValidateKey(request))
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Missing Key")
                };
                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(response);
                return await tsc.Task;
            }
            return await base.SendAsync(request, cancellationToken);
        }

        private bool ValidateKey(HttpRequestMessage request)
        {
            var query = request.RequestUri.ParseQueryString();
            var inputKey = query["key"];
            return inputKey == key;
        }
    }
}