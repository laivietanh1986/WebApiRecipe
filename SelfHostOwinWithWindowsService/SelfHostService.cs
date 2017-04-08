using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace SelfHostOwinWithWindowsService
{
    public class SelfHostService :ServiceBase
    {
        private IDisposable _webapp;

        

        protected override void OnStart(string[] args)
        {
            _webapp=WebApp.Start<Startup>("http://localhost:9001");

        }

        protected override void OnStop()
        {
            _webapp?.Dispose();
        }
    }
}
