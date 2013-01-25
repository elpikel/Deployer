using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace Deployer
{
    [RunInstaller(true)]
    public class DeployerInstaller : Installer
    {
        public DeployerInstaller()
        {
            Installers.Add(new ServiceProcessInstaller
                {
                    Account = ServiceAccount.LocalSystem
                });
            Installers.Add(new ServiceInstaller
                {
                    DisplayName = "My Service",
                    StartType = ServiceStartMode.Manual,
                    ServiceName = "My Service"
                });
        }
    }
}