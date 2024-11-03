namespace Catalog.API.Features.Products.CreateProduct;

public static class Data
{
    internal static async Task<Guid> CreateProduct(IDocumentSession session,
        Product product,
        CancellationToken cancellationToken)
    {
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        return product.Id;
    }
}