using Catalog.API.Exceptions;

namespace Catalog.API.Features.Products.DeleteProduct;

internal sealed class DeleteProductEndpoint(IDocumentSession documentSession)
    : EndpointWithoutRequest<Response>
{
    public override void Configure()
    {
        AllowAnonymous();
        Delete("products/{id}");
        Options(a =>
        {
            a.Produces<Response>()
                .WithName("DeleteProduct")
                .ProducesProblem(StatusCodes.Status404NotFound)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithDescription("Delete Product with providing its Id")
                .WithSummary("Delete Product with providing its Id");
        });
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var id = Route<string>("Id");
        var response = await Data.DeleteProductById(documentSession, id!, ct);
        await SendOkAsync(response, ct);
    }
}