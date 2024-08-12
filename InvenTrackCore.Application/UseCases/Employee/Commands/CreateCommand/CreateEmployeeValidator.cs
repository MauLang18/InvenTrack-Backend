using FluentValidation;

namespace InvenTrackCore.Application.UseCases.Employee.Commands.CreateCommand;

public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("El Nombre no puede ser nulo.")
            .NotEmpty().WithMessage("El Nombre no pueder ser vacío.")
            .MinimumLength(1).WithMessage("El Nombre debe tener almenos 1 caracter.")
            .MaximumLength(50).WithMessage("El Nombre debe tener como máximo 50 caracteres.");
        RuleFor(x => x.LastName)
            .NotNull().WithMessage("El Apellido no puede ser nulo.")
            .NotEmpty().WithMessage("El Apellido no pueder ser vacío.")
            .MinimumLength(1).WithMessage("El Apellido debe tener almenos 1 caracter.")
            .MaximumLength(50).WithMessage("El Apellido debe tener como máximo 50 caracteres.");
        RuleFor(x => x.Email)
            .MinimumLength(1).WithMessage("El Correo debe tener almenos 1 caracter.")
            .MaximumLength(100).WithMessage("El Correo debe tener como máximo 100 caracteres.");
        RuleFor(x => x.Phone)
            .MinimumLength(1).WithMessage("El Teléfono debe tener almenos 1 caracter.")
            .MaximumLength(100).WithMessage("El Teléfono debe tener como máximo 100 caracteres.");
    }
}