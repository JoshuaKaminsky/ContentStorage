using System;
using System.Configuration;
using System.Diagnostics;

namespace ContentStorage.Configuration
{
    internal class BaseStorageConfigurationSection : ConfigurationSection
    {
        private const string ImageStorageConfigurationFileName = "contentStorage.config";

        protected static TConfigurationSection GetStorageConfig<TConfigurationSection>(string sectionName) where TConfigurationSection : BaseStorageConfigurationSection 
        {
            System.Configuration.Configuration imageStorageConfiguration;

            try
            {
                var configMap = new ExeConfigurationFileMap { ExeConfigFilename = ImageStorageConfigurationFileName };
                imageStorageConfiguration = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            }
            catch (Exception)
            {
                Trace.TraceError("Could not open configuration file contentStorage.config.  Make sure it is placed in the execution directory.");
                return null;
            }

            return imageStorageConfiguration.GetSection(sectionName) as TConfigurationSection;
        }
    }
}
