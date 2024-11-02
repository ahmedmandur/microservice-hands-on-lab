namespace Catalog.API.Features.Products.CreateProduct;

internal sealed class CreateProductEndpoint(IDocumentSession documentSession)
    : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        AllowAnonymous();
        Post("products");
        Options(a =>
        {
            a.Produces<Response>(StatusCodes.Status201Created);
            a.ProducesProblem(StatusCodes.Status400BadRequest);
            a.WithDescription("Create a new product");
            a.WithSummary("Create a product");
        });
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var response = await Data.CreateProduct(documentSession, Map.ToEntity(req), ct);
        await SendCreatedAtAsync("GetProductByIdEndpoint", new { id = response.Id },
            response, cancellation: ct);
    }
}