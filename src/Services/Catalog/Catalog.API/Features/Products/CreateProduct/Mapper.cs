namespace Catalog.API.Features.Products.CreateProduct;

internal sealed class Mapper : Mapper<Request, Response, object>
{
    public override Product ToEntity(Request r) => new()
    {
       Price = r.Price,
       Categories = r.Categories,
       Description = r.Description,
       ImageFile = r.ImageFile,
       Name = r.Name
    };
} 