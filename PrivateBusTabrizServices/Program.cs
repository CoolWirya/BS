using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrivateBusTabrizServices
{



    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static int State = 1;
        static void Main()
        {
            if (State == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new TestForm());
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
            {

                new PrivateBusTabrizServices()
            };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
