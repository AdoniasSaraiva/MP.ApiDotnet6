using FluentValidation;

namespace MP.ApiDotnet6.Application.DTOs.Validations
{
    public class PersonImageDTOValidation : AbstractValidator<PersonImageDTO>
    {
        public PersonImageDTOValidation()
        {
            RuleFor(x => x.PersonId).GreaterThanOrEqualTo(0).WithMessage("PersonId não pode ser menor ou igual a ZERO!");
            RuleFor(x => x.Image).NotEmpty().NotNull().WithMessage("Image deve ser informado");
        }
    }
}
