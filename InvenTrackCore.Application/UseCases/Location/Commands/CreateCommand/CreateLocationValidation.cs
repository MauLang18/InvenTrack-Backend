using FluentValidation;

namespace InvenTrackCore.Application.UseCases.Location.Commands.CreateCommand;

public class CreateLocationValidation : AbstractValidator<CreateLocationCommand>
{
    public CreateLocationValidation()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("El Nombre no puede ser nulo.")
            .NotEmpty().WithMessage("El Nombre no puede ser vacío.")
            .MinimumLength(1).WithMessage("El Nombre debe tener minimo 1 caracter.")
            .MaximumLength(100).WithMessage("El Nombre debe tener máximo 100 caracteres.");
        RuleFor(x => x.Address)
            .NotNull().WithMessage("La Dirección no puede ser nulo.")
            .NotEmpty().WithMessage("La Dirección no puede ser vacío.")
            .MinimumLength(1).WithMessage("La Dirección debe tener minimo 1 caracter.");
    }
}