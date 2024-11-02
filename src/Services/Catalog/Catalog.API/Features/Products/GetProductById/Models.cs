
namespace Catalog.API.Features.Products.GetProductById;

public record Response(
    string Id,
    string Name,
    string Description,
    decimal Price,
    string ImageFile,
    List<string> Categories);