namespace Deployer.Abstract
{
    public interface IConfigReader
    {
        T GetSetting<T>(string settingName); 
    }
}