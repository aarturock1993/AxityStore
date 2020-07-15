using AxityStoreBackEnd.Services.Model.Request;
using FluentValidation;

namespace AxityStoreBackEnd.Services.Model.Validator
{
    public class ModelLoginValidator: AbstractValidator<ModelLogin>
    {
        public ModelLoginValidator()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage("Nombre es necesario")
                                    .MaximumLength(20).WithMessage("Nombre no debe exceder los 20 caracteres");

            RuleFor(u => u.LastName).NotEmpty().WithMessage("Apellido es necesaria")
                                    .MaximumLength(20).WithMessage("Apellido no debe exceder los 20 caracteres");
        }
    }
}
