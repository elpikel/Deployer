using System.ServiceProcess;
using System.Threading;

namespace Deployer
{
    class Program : ServiceBase
    {
        private const int TenMinutes = 60000;

        static void Main()
        {
            Run(new Program());
        }

        public Program()
        {
            this.ServiceName = "My Service";
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);

            var scriptRunner = new ScriptRunner(new ConfigReader(), new PowershellWrapper());

            while (true)
            {
                scriptRunner.Run();
                Thread.Sleep(TenMinutes);
            }
        }
    }
}
