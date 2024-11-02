namespace Catalog.API.Features.Products.GetProducts;

public record Response(
    string Id,
    string Name,
    string Description,
    decimal Price,
    string ImageFile,
    List<string> Categories);