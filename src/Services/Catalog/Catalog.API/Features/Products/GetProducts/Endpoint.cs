using FastEndpoints;

namespace Catalog.API.Features.Products.GetProducts;

internal sealed class GetProductsEndpoint(IDocumentSession documentSession)
    : EndpointWithoutRequest<Response, Mapper>
{
    public override void Configure()
    {
        AllowAnonymous();
        Get("products");
        Options(a =>
        {
            a.WithName("GetProducts");
            a.Produces<IEnumerable<Response>>();
            a.WithDescription("Get all products");
            a.WithSummary("Get all products");
        });
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var products = await Data.GetProducts(documentSession, ct);
        await SendOkAsync(Map.FromEntity(products), ct);
    }
}