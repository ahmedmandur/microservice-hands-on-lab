using Catalog.API.Exceptions;

namespace Catalog.API.Features.Products.GetProductByCategory;

internal sealed class GetProductByCategoryEndpoint(IDocumentSession documentSession)
    : EndpointWithoutRequest<Response, Mapper>
{
    public override void Configure()
    {
        AllowAnonymous();
        Get("products/category/{category}");
        Options(a =>
        {
            a.WithName("GetProductByCategory");
            a.Produces<Response>();
            a.ProducesProblem(StatusCodes.Status404NotFound);
            a.WithDescription("Get products with providing category");
            a.WithSummary("Get products with providing category");
        });
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var category = Route<string>("category");
        var response = await Data.GetProductsByCategory(documentSession, category!, ct);

        await SendOkAsync(Map.FromEntity(response), ct);
    }
}