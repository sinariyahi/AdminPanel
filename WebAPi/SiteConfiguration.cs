using Application;

namespace WebAPi
{
    public static class SiteConfiguration
    {
        public static AppSetting GetAppSetting(IConfiguration configuration)
        {
            return configuration.GetSection(nameof(AppSetting)).Get<AppSetting>();
        }
    }
}
