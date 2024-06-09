public interface IImageService
{
    Task<ImageResponseModel> Process(ImageRequestModel image);
}