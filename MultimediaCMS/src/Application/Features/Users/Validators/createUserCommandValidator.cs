// using Application.Features.Users.Commands;
// using FluentValidation;

// namespace Application.Features.Users.Validators;

// public class createUserCommandValidator : AbstractValidator<CreateUserCommand>
// {
//     public createUserCommandValidator()
//     {
//         RuleFor(x => x.Username).NotEmpty().MinimumLength(3);
//         RuleFor(x => x.Email).NotEmpty().EmailAddress();
//         RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
//     }
// }
