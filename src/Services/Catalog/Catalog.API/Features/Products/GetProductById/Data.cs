namespace Catalog.API.Features.Products.GetProductById;

public static class Data
{
    internal static async Task<Product?> GetProductById(IDocumentSession session,
        string id, CancellationToken cancellationToken)
    {
        return await session.LoadAsync<Product>(Guid.Parse(id), cancellationToken);
    }
}