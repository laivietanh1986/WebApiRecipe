using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace WebApiRouting.Controllers
{
    [RoutePrefix("api/Stream")]
    public class StreamDataController : ApiController
    {
        [Route("readfile/{filename:alpha}")]
      
        public HttpResponseMessage ReadFile(string filename)
        {
            var path = Path.Combine(HttpContext.Current.Server.MapPath("/file/") + filename);
            if (!File.Exists(path))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Could not find the file you need"));
            }
            var result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(path, FileMode.Open);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return result;
        }

        [Route("readbyte/{filename:alpha}")]
        public HttpResponseMessage GetByte(string filename)
        {
            var path = Path.Combine(HttpContext.Current.Server.MapPath("/file/") + filename);
            if (!File.Exists(path))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound,"Could not find your file"));
            }
            var result = new HttpResponseMessage(HttpStatusCode.OK);
            var data = File.ReadAllBytes(path);
            result.Content = new ByteArrayContent(data);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return result;
        }
    }
}
