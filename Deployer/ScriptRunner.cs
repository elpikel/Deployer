using Deployer.Abstract;

namespace Deployer
{
    public class ScriptRunner : IScriptRunner
    {
        private readonly IConfigReader _configReader;
        private readonly IPowershellWrapper _powershellWrapper;

        public ScriptRunner(IConfigReader configReader, IPowershellWrapper powershellWrapper)
        {
            _configReader = configReader;
            _powershellWrapper = powershellWrapper;
        }

        public string Run()
        {
            var scriptName = _configReader.GetSetting<string>("scriptsName");
            var deployedPackagesPath = _configReader.GetSetting<string>("deployedPackagesPath");
            var scriptText = string.Format("cd {0} ; powershell -ExecutionPolicy ByPass -File {1} ", deployedPackagesPath, scriptName);

            return _powershellWrapper.RunScript(scriptText);
        }
    }
}