using Emodiario.Models;
using FluentValidation;

namespace Emodiario.Services
{
    public class LoginDtoValidator : AbstractValidator<LoginDTO>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email é obrigatório").EmailAddress().WithMessage("Email inválido");
            RuleFor(x => x.Senha).NotEmpty().WithMessage("Senha é obrigatória");
        }
    }
}