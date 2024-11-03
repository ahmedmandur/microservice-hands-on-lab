namespace Catalog.API.Features.Products.DeleteProduct;

public static class Data
{
    internal static async Task<Response> DeleteProductById(IDocumentSession session,
        string id, CancellationToken cancellationToken)
    {
        session.Delete<Product>(Guid.Parse(id));
        await session.SaveChangesAsync(cancellationToken);

        return new Response(true);
    }
}