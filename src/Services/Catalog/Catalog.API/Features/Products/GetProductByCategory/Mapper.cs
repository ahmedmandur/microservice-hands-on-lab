namespace Catalog.API.Features.Products.GetProductByCategory;

internal sealed class Mapper : ResponseMapper<Response, IEnumerable<Product>>
{
    public override Response FromEntity(IEnumerable<Product> e) => new(e);
}