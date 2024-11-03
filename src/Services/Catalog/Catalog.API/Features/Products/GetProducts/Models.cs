namespace Catalog.API.Features.Products.GetProducts;

public record Response(IEnumerable<Product> Products);