public class MessageQueueSettings
{
    public MessageQueueSettings(
        string host,
        string userName,
        string password)
    {
        Host = host;
        UserName = userName;
        Password = password;
    }

    public string Host { get; }

    public string UserName { get; }

    public string Password { get; }
}