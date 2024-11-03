
namespace Catalog.API.Features.Products.CreateProduct;

public record Request(
    string Name,
    string Description,
    decimal Price,
    string ImageFile,
    List<string> Categories);

public record Response(Guid Id);

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Categories).NotEmpty().WithMessage("Category is required");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}
