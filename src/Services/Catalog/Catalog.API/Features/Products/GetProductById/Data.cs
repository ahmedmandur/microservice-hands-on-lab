namespace Catalog.API.Features.Products.GetProductById;

public static class Data
{
    internal static async Task<Product> GetProductById(IDocumentSession session,
        string id, CancellationToken cancellationToken)
    {
        return new Product();
    }
}