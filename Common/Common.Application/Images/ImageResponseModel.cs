public class ImageResponseModel
{
    public ImageResponseModel(
        byte[] originalContent,
        byte[] thumbnailContent)
    {
        this.OriginalContent = originalContent;
        this.ThumbnailContent = thumbnailContent;
    }

    public byte[] OriginalContent { get; }

    public byte[] ThumbnailContent { get; }
}