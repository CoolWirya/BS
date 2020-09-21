using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;


namespace SMSServise
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
            //serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            //serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Manual;
            //serviceInstaller1.ServiceName = "SMS Service";
            //Installers.Add(serviceInstaller1);
            //Installers.Add(serviceProcessInstaller1);

        }
    }
}
