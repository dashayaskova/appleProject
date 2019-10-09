using System.Configuration;

namespace Tools
{
	internal class ProviderConfiguration
	{
		internal class ProvidersConfiguration : ConfigurationSection
		{
			[ConfigurationProperty("DBProvider")]
			public ProviderSettings DBProvider
			{
				get
				{
					return (ProviderSettings)base["DBProvider"];
				}
			}

		}
	}
}
