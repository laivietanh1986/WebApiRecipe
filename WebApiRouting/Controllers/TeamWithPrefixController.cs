using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebApiRouting.App_Start
{
    [RoutePrefix("api/Teams")]
    public class TeamWithPrefixController : ApiController
    {
        [Route("{id:int}")]
        public string GetTeam(int id)
        {
            return "Get Team";
        }
        [Route]
        public string GetTeams()
        {
            return "Get Teams";
        }
        [Route("{playername:alpha}")]
        public string GetPlayer(string playername)
        {
            return "Get Player";
        }

        
    }
}
