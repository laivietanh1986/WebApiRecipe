using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApiRecipe.Extensions;

namespace WebApiRecipe.MessageHandler
{
    public class AntiForgeryMessageHandler:DelegatingHandler
    {
        public const string antiForgeryKeyName = "__RequestVerificationToken";
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string cookiekey = null;
            string formKey = null;
            if (request.IsAjaxRequest())
            {
                IEnumerable<string> forms;
                if (request.Headers.TryGetValues(antiForgeryKeyName,out forms))
                {
                    var cookie = request.Headers.GetCookies(AntiForgeryConfig.CookieName).FirstOrDefault();
                    if (cookie != null)
                    {
                        cookiekey = cookie[AntiForgeryConfig.CookieName].Value;
                    }
                    formKey = forms.FirstOrDefault();
                }
            }
            try
            {
                if (cookiekey != null && formKey != null)
                {
                    AntiForgery.Validate(cookiekey,formKey);
                }
                else
                {
                    AntiForgery.Validate();
                }
            }
            catch (HttpAntiForgeryException exception)
            {
                return request.CreateResponse(HttpStatusCode.Forbidden);
                
            }
            return await base.SendAsync(request, cancellationToken);
        }

    }
}