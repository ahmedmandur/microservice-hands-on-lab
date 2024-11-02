namespace Catalog.API.Features.Products.GetProducts;

public static class Data
{
    internal static async Task<IReadOnlyList<Product>> GetProducts(
        IDocumentSession session,
        CancellationToken cancellationToken)
    {
        return await session.Query<Product>().ToListAsync(cancellationToken);
    }
}