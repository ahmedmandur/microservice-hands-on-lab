﻿namespace Catalog.API.Features.Products.GetProducts;

internal sealed class Mapper : ResponseMapper<Response, IEnumerable<Product>>
{
    public override Response FromEntity(IEnumerable<Product> e) => new(e);
}