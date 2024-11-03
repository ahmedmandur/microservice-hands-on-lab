namespace Catalog.API.Features.Products.GetProductById;

internal sealed class Mapper : ResponseMapper<Response, Product>
{
    public override Response FromEntity(Product? e) => new(e!);
}