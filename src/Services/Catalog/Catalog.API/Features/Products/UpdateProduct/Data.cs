using Catalog.API.Exceptions;

namespace Catalog.API.Features.Products.UpdateProduct;

public static class Data
{
    internal static async Task<bool> UpdateProduct(IDocumentSession session,
        Product product,
        CancellationToken cancellationToken)
    {
        var productDb = await session.LoadAsync<Product>(product.Id, cancellationToken);

        if (productDb is null)
            throw new ProductNotFoundException(product.Id);

        productDb.Name = product.Name;
        productDb.Categories = product.Categories;
        productDb.Description = product.Description;
        productDb.ImageFile = product.ImageFile;
        productDb.Price = product.Price;

        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);

        return true;
    }
}