namespace Deployer.Abstract
{
    public interface IPowershellWrapper
    {
        string RunScript(string scriptText); 
    }
}