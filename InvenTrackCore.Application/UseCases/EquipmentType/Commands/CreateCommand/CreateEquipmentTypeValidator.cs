using FluentValidation;

namespace InvenTrackCore.Application.UseCases.EquipmentType.Commands.CreateCommand;

public class CreateEquipmentTypeValidator : AbstractValidator<CreateEquipmentTypeCommand>
{
    public CreateEquipmentTypeValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("El Nombre no puede ser nulo.")
            .NotEmpty().WithMessage("El Nombre no puede ser vacío.")
            .MinimumLength(1).WithMessage("El Nombre debe de tener como minimo 1 caracter.")
            .MaximumLength(256).WithMessage("El Nombre debe de tener como máximo 256 caracteres.");
    }
}