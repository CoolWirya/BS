using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PublicBusTabrizService
{
    static class Program
    {
        static int FormId = 1;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            switch (FormId)
            {
                case 1:
                    {
                        ServiceBase[] ServicesToRun;
                        ServicesToRun = new ServiceBase[] 
                        { 
                            new PublicBusTabrizService() 
                        };
                        ServiceBase.Run(ServicesToRun);
                        break;
                    }
                case 2:
                    {
                        try
                        {
                            Application.Run(new Form1());
                        }
                        catch
                        {
                        }
                        break;
                    }
            }

        }

    }
}