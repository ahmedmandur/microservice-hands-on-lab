namespace Catalog.API.Features.Products.GetProducts;

internal sealed class Mapper : ResponseMapper<IEnumerable<Response>, IEnumerable<Product>>
{
    public override IEnumerable<Response> FromEntity(IEnumerable<Product> e) => e.Select(
        a =>
            new Response(a.Id.ToString(), a.Name,
                a.Description, a.Price, a.ImageFile, a.Categories));
}