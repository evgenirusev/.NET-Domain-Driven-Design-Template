namespace BettingSystem.Infrastructure.Common.Services;

using System.IO;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

internal class ImageService : IImageService
{
    private const int ThumbnailWidth = 100;

    public async Task<ImageResponseModel> Process(ImageRequestModel image)
    {
        using var imageResult = await Image.LoadAsync(image.Content);

        var original = await this.SaveImage(imageResult, imageResult.Width);
        var thumbnail = await this.SaveImage(imageResult, ThumbnailWidth);

        return new ImageResponseModel(original, thumbnail);
    }

    private async Task<byte[]> SaveImage(Image image, int resizeWidth)
    {
        var width = image.Width;
        var height = image.Height;

        if (width > resizeWidth)
        {
            height = (int)((double)resizeWidth / width * height);
            width = resizeWidth;
        }

        image
            .Mutate(i => i
                .Resize(new Size(width, height)));

        image.Metadata.ExifProfile = null;

        await using var memoryStream = new MemoryStream();

        await image.SaveAsJpegAsync(memoryStream);

        return memoryStream.ToArray();
    }
}