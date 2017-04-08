using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SelfHostWithOwin.controller
{
    public class StudentController:ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] {"value1","values2"};
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
