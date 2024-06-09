using System.Text.Json;

public class Message
{
    private string serializedData = default!;

    public Message(object data) 
    {
        Data = data;
    }

    private Message()
    {
    }

    public int Id { get; private set; }

    public Type Type { get; private set; } = default!;

    public bool Published { get; private set; }

    public void MarkAsPublished() => Published = true;

    public object Data
    {
        get
        {
            return JsonSerializer.Deserialize(serializedData, Type, new JsonSerializerOptions
            {
                IgnoreNullValues = true
            });
        }
        set
        {
            Type = value.GetType();
            serializedData = JsonSerializer.Serialize(value, new JsonSerializerOptions
            {
                IgnoreNullValues = true
            });
        }
    }
}