using FluentValidation;

namespace InvenTrackCore.Application.UseCases.Department.Commands.CreateCommand;

public class CreateDepartmentValidator : AbstractValidator<CreateDepartmentCommand>
{
    public CreateDepartmentValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("El Nombre no puede ser nulo")
            .NotEmpty().WithMessage("El Nombre no puede ser vacío.")
            .MinimumLength(1).WithMessage("El Nombre debe tener almenos 1 caracter.")
            .MaximumLength(100).WithMessage("El Nombre debe tener como máximo 100 caracteres.");
        RuleFor(x => x.Company)
            .NotNull().WithMessage("La Compañia no puede ser nulo")
            .NotEmpty().WithMessage("La Compañia no puede ser vacío.")
            .MinimumLength(1).WithMessage("La Compañia debe tener almenos 1 caracter.")
            .MaximumLength(100).WithMessage("La Compañia debe tener como máximo 100 caracteres.");
    }
}