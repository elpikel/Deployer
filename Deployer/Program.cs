using System.ServiceProcess;
using System.Threading;
using System.Timers;

namespace Deployer
{
    class Program : ServiceBase
    {
        private const int TenMinutes = 60000;

        static void Main(string[] args)
        {
            ServiceBase.Run(new Program());
        }

        public Program()
        {
            ServiceName = "Deployer";
            EventLog.Source = "Deployer";
            EventLog.Log = "Application";

            // These Flags set whether or not to handle that specific
            //  type of event. Set to true if you need it, false otherwise.
            CanHandlePowerEvent = true;
            CanHandleSessionChangeEvent = true;
            CanPauseAndContinue = true;
            CanShutdown = true;
            CanStop = true;

            var time = new System.Timers.Timer();
            time.Start();
            time.Interval = TenMinutes;
            time.Elapsed += RunScript;
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
        }

        private void RunScript(object sender, ElapsedEventArgs e)
        {
            var scriptRunner = new ScriptRunner(new PowershellWrapper());
            scriptRunner.Run();
        }
    }
}
