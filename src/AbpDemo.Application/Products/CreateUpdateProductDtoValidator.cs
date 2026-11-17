using FluentValidation;

namespace AbpDemo.Products;

public class CreateUpdateProductDtoValidator : AbstractValidator<CreateUpdateProductDto>
{
    public CreateUpdateProductDtoValidator()
    {
        RuleFor(p => p.NameAr).NotEmpty().MaximumLength(300);
        RuleFor(p => p.NameEn).NotEmpty().MaximumLength(300);
        RuleFor(p => p.DescripationAr).NotEmpty().MaximumLength(1000);
        RuleFor(p => p.DescripationEn).NotEmpty().MaximumLength(1000);
        RuleFor(p => p.Price).GreaterThanOrEqualTo(1);
        RuleFor(p => p.CategoryId).GreaterThanOrEqualTo(1);
    }
}



