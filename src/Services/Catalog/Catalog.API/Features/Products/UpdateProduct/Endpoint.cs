namespace Catalog.API.Features.Products.UpdateProduct;

internal sealed class UpdateProductEndpoint(IDocumentSession documentSession)
    : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        AllowAnonymous();
        Put("products");
        Options(a =>
        {
            a.WithName("UpdateProduct");
            a.Produces<Response>();
            a.ProducesProblem(StatusCodes.Status400BadRequest);
            a.ProducesProblem(StatusCodes.Status404NotFound);
            a.WithSummary("Update Product");
            a.WithDescription("Update Product");
        });
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var response = await Data.UpdateProduct(documentSession, Map.ToEntity(req), ct);
        await SendOkAsync(new Response(response), ct);
    }
}