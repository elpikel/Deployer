using System.Configuration;
using System.Globalization;
using Deployer.Abstract;

namespace Deployer
{
    public class ConfigReader : IConfigReader
    {
        public T GetSetting<T>(string settingName)
        {
            string settingValue = ConfigurationManager.AppSettings[settingName];

            int intSetting;
            if (int.TryParse(settingValue, NumberStyles.Any, CultureInfo.InvariantCulture, out intSetting))
            {
                return (T)((object)intSetting);
            }

            double doubleSetting;
            if (double.TryParse(settingValue, NumberStyles.Any, CultureInfo.InvariantCulture, out doubleSetting))
            {
                return (T)((object)doubleSetting);
            }

            return (T)((object)settingValue);
        }
    }
}