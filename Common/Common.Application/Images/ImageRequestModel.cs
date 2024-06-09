public class ImageRequestModel
{
    public ImageRequestModel(Stream content) => this.Content = content;

    public Stream Content { get; }
}