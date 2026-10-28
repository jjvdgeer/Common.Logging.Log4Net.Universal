using System;
using Common.Logging.Configuration;
using Microsoft.Extensions.Configuration;

namespace Common.Logging.Log4Net.Universal
{
    public class Log4NetInitializer
    {
        /// <summary>
        /// This method should ideally be in Common.Logging somewhere, but in absence of that I've parked it here
        /// Run this method to initialise the configuration in the appsettings.json that could look like this:
        /// {
        ///     "LogConfiguration": {
        ///         "factoryAdapter": {
        ///             "type": "Common.Logging.Log4Net.Universal.Log4NetFactoryAdapter, Common.Logging.Log4Net.Universal",
        ///             "arguments": {
        ///                 "configType": "INLINE"
        ///             }
        ///         }
        ///     }
        /// }
        /// </summary>
        public static void Initialize()
        {
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            Initialize(configBuilder);
        }

        /// <summary>
        /// Initializes Common.Logging from the LogConfiguration section of an existing configuration.
        /// </summary>
        /// <param name="configuration">The application's root configuration.</param>
        /// <exception cref="ArgumentNullException">The configuration is null.</exception>
        public static void Initialize(IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            LogConfiguration logConfiguration = new LogConfiguration();
            configuration.GetSection("LogConfiguration").Bind(logConfiguration);
            LogManager.Configure(logConfiguration);
        }
    }
}