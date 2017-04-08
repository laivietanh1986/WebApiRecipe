using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SelfHostOwinWithWindowsService
{
    class Program
    {
        static void Main(string[] args)
        {
            // the way to attach service to windows need to google , very easy :D
            var services = new ServiceBase[]
            {
                new SelfHostService()
            };
            ServiceBase.Run(services);
        }
    }
}
