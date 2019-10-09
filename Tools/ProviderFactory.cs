using Providers;
using System;
using System.Configuration;
using static Tools.ProviderConfiguration;

namespace Tools
{
	public static class ProviderFactory
	{
		private static ProvidersConfiguration _configuration;
		static ProviderFactory()
		{
			Initialize();
		}

		private static void Initialize()
		{
			_configuration = (ProvidersConfiguration)ConfigurationManager.GetSection("providers");
			if (_configuration == null)
				throw new ConfigurationErrorsException("Data provider section is not set.");
		}

		public static IDBProvider CreateNewDBProvider()
		{
			return (IDBProvider)Activator.CreateInstance(_configuration.DBProvider.Name, _configuration.DBProvider.Type).Unwrap();
		}

		public static IDBProvider CreateNewDbProvider()
		{
			return new EFDBProvider();
		}
	}
}

