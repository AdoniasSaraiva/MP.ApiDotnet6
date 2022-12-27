using FluentValidation;

namespace MP.ApiDotnet6.Application.DTOs.Validations
{
    public class PurchaseDTOValidation : AbstractValidator<PurchaseDTO>
    {
        public PurchaseDTOValidation()
        {
            RuleFor(x => x.CodErp).NotEmpty().NotNull().WithMessage("CodErp deve ser informado!");
            RuleFor(x => x.Document).NotEmpty().NotNull().WithMessage("Documento deve ser informado!");
        }
    }
}
