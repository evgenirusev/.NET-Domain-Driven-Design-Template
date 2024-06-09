using Microsoft.Extensions.Configuration;

public static class ConfigurationExtensions
{
    public static string GetDefaultConnectionString(
        this IConfiguration configuration)
        => configuration.GetConnectionString("DefaultConnection");
    
    public static string GetCronJobsConnectionString(
        this IConfiguration configuration)
        => configuration.GetConnectionString("CronJobsConnection");

    public static MessageQueueSettings GetMessageQueueSettings(
        this IConfiguration configuration)
    {
        var settings = configuration.GetSection(nameof(MessageQueueSettings));

        return new MessageQueueSettings(
            settings.GetValue<string>(nameof(MessageQueueSettings.Host)),
            settings.GetValue<string>(nameof(MessageQueueSettings.UserName)),
            settings.GetValue<string>(nameof(MessageQueueSettings.Password)));
    }
}