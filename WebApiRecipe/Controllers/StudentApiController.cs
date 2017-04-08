using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApiRecipe.Models;

namespace WebApiRecipe.Controllers
{
    public class StudentApiController : ApiController
    {
        public IHttpActionResult Create(Student student)
        {
            
            if (ModelState.IsValid)
            {
                return RedirectToRoute("Default", new { controller = "Home", action = "index" });
            }
           throw  new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest,"hehe bug rui"));

        }
    }
}
