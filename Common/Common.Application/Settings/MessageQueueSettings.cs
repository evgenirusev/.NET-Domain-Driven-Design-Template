public class MessageQueueSettings
{
    public MessageQueueSettings(
        string host,
        string userName,
        string password)
    {
        this.Host = host;
        this.UserName = userName;
        this.Password = password;
    }

    public string Host { get; }

    public string UserName { get; }

    public string Password { get; }
}