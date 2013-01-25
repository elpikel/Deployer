using System.Text;
using System.Management.Automation.Runspaces;
using Deployer.Abstract;

namespace Deployer
{
    public class PowershellWrapper : IPowershellWrapper
    {
        public string RunScript(string scriptText)
        {
            var runspace = RunspaceFactory.CreateRunspace();

            runspace.Open();

            var pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(scriptText);
            pipeline.Commands.Add("Out-String");

            var results = pipeline.Invoke();

            runspace.Close();

            var stringBuilder = new StringBuilder();
            foreach (var obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }

            return stringBuilder.ToString();
        } 
    }
}