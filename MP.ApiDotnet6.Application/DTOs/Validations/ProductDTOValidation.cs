using FluentValidation;

namespace MP.ApiDotnet6.Application.DTOs.Validations
{
    public class ProductDTOValidation : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name deve ser infomado!");
            RuleFor(x => x.CodeErp).NotNull().NotEmpty().WithMessage("CodErp deve ser infomado!");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price deve ser maior que ZERO!");
        }
    }
}
