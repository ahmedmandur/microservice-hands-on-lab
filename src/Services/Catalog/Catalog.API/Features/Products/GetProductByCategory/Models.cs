namespace Catalog.API.Features.Products.GetProductByCategory;

public record Response(IEnumerable<Product> Products);