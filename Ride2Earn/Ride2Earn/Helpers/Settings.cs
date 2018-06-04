using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Ride2Earn.Helpers
{
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		private const string SettingsKey = "settings_key";
		private static readonly string SettingsDefault = "yes";


		public static string GeneralSettings
		{
			get
			{
				return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(SettingsKey, value);
			}
		}

	}
}