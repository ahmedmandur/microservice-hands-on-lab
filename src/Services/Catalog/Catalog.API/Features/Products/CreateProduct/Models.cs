
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
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name is required!")
            .MinimumLength(3).WithMessage("name is too short!")
            .MaximumLength(25).WithMessage("name is too long!");
    }
}
