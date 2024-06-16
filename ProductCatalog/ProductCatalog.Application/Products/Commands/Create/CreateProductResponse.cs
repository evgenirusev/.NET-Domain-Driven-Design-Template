public class CreateProductResponse
{
    internal CreateProductResponse(Guid id) => Id = id;

    public Guid Id { get; }
}