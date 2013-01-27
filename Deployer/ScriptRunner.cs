using Deployer.Abstract;

namespace Deployer
{
    public class ScriptRunner : IScriptRunner
    {
        private readonly IPowershellWrapper _powershellWrapper;

        public ScriptRunner(IPowershellWrapper powershellWrapper)
        {
            _powershellWrapper = powershellWrapper;
        }

        public string Run()
        {
            return _powershellWrapper.RunScript("cd D:\\Pubish ; powershell -ExecutionPolicy ByPass -File .\\publishScript");
        }
    }
}