using Emodiario.Services.DTOs;
using FluentValidation;

namespace Emodiario.Services.Validator;

public class CriaUsuarioDTOValidator : AbstractValidator<CriaUsuarioDTO>
{
    public CriaUsuarioDTOValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome é obrigatório");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email é obrigatório").EmailAddress().WithMessage("Email inválido");
        RuleFor(x => x.Senha).NotEmpty().WithMessage("Senha é obrigatória").MinimumLength(6).WithMessage("A senha deve ter pelo menos 6 caracteres");
        RuleFor(x => x.Telefone).NotEmpty().WithMessage("Telefone é obrigatório");
    }
}