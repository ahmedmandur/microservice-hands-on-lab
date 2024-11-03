namespace Catalog.API.Features.Products.GetProductByCategory;

public static class Data
{
    internal static async Task<IEnumerable<Product>?> GetProductsByCategory(
        IDocumentSession session,
        string category, CancellationToken cancellationToken)
    {
        return await session.Query<Product>().Where(p => p.Categories.Contains(category))
            .ToListAsync(cancellationToken);
    }
}