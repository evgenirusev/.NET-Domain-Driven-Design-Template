using Microsoft.AspNetCore.Mvc.ModelBinding;

public class ImageModelBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
        => context.Metadata.ModelType == typeof(ImageRequestModel)
            ? new ImageModelBinder()
            : default;
}