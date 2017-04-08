using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SelfHostOwinWithWindowsService.controller
{
    public class ValueController :ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] {"value2","value3"};
        }
    }
}
