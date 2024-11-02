namespace Catalog.API.Features.Products.GetProductById;

internal sealed class Mapper : ResponseMapper<Response, Product>
{
    public override Response FromEntity(Product e) => new(e.Id.ToString(), e.Name,
        e.Description, e.Price, e.ImageFile, e.Categories);
}