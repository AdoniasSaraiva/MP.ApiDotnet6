using FluentValidation;

namespace MP.ApiDotnet6.Application.DTOs.Validations
{
    public class PersonDTOValidation : AbstractValidator<PersonDTO>
    {
        public PersonDTOValidation(){
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("Nome deve ser enviado");
            RuleFor(p => p.Document).NotEmpty().NotNull().WithMessage("Documento deve ser enviado");
            RuleFor(p => p.Phone).NotEmpty().NotNull().WithMessage("O número de telefone deve ser enviado");
        }
    }
}