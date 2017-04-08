using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace SelfHostWithOwin
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAdress = "http://localhost:9000";
            using (WebApp.Start<Startup>(url:baseAdress))
            {
                HttpClient client = new HttpClient();
                var respose = client.GetAsync(baseAdress + "/api/Student");
                Console.WriteLine("reponse:");
                Console.WriteLine(respose.Result.Content.ReadAsStringAsync().Result);
                Console.ReadLine();

            }
        }
    }
}
