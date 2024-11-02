namespace Catalog.API.Features.Products.CreateProduct;

public static class Data
{
    internal static async Task<Response> CreateProduct(IDocumentSession session, Product product,
        CancellationToken cancellationToken)
    {
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        return new Response(product.Id);
    }
}