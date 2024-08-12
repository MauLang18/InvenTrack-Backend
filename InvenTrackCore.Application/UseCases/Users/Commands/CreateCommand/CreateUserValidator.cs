using FluentValidation;

namespace InvenTrackCore.Application.UseCases.Users.Commands.CreateCommand;

public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("El Nombre no puede ser nulo.")
            .NotEmpty().WithMessage("El Nombre no puede ser vacio.")
            .MinimumLength(3).WithMessage("El Nombre debe tener un minimo de 3 caracteres.")
            .MaximumLength(100).WithMessage("El Nombre debe tener un máximo de 100 caracteres.");
        RuleFor(x => x.LastName)
            .NotNull().WithMessage("El Apellido no puede ser nulo.")
            .NotEmpty().WithMessage("El Apellido no puede ser vacio.")
            .MinimumLength(3).WithMessage("El Apellido debe tener un minimo de 3 caracteres.")
            .MaximumLength(100).WithMessage("El Apellido debe tener un máximo de 100 caracteres.");
        RuleFor(x => x.UserName)
            .NotNull().WithMessage("El Usuario no puede ser nulo.")
            .NotEmpty().WithMessage("El Usuario no puede ser vacio.")
            .MinimumLength(3).WithMessage("El Usuario debe tener un minimo de 3 caracteres.")
            .MaximumLength(100).WithMessage("El Usuario debe tener un máximo de 100 caracteres.");
        RuleFor(x => x.PassWord)
            .NotNull().WithMessage("La Contraseña no puede ser nulo.")
            .NotEmpty().WithMessage("La Contraseña no puede ser vacio.")
            .MinimumLength(8).WithMessage("La Contraseña debe tener un minimo de 8 caracteres.")
            .MaximumLength(100).WithMessage("La Contraseña debe tener un máximo de 100 caracteres.");
        RuleFor(x => x.Email)
            .MinimumLength(5).WithMessage("El Correo debe tener un minimo de 5 caracteres.")
            .MaximumLength(100).WithMessage("El Correo debe tener un máximo de 100 caracteres.");
    }
}