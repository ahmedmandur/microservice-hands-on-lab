﻿namespace Catalog.API.Features.Products.GetProductById;

internal sealed class GetProductByIdEndpoint(IDocumentSession documentSession)
    : EndpointWithoutRequest<Response, Mapper>
{
    public override void Configure()
    {
        AllowAnonymous();
        Get("products/{id}");
        Options(a =>
        {
            a.Produces<Response>();
            a.ProducesProblem(StatusCodes.Status404NotFound);
            a.WithDescription("Get a product with providing its Id");
            a.WithSummary("Get a product with providing its Id");
        });
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var id = Route<string>("Id");
        var response = await Data.GetProductById(documentSession, id!, ct);
        await SendOkAsync(Map.FromEntity(response), ct);
    }
}