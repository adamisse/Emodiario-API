using Emodiario.Services.DTOs;
using FluentValidation;

namespace Emodiario.Services.Validator;

public class CriaCategoriaDTOValidator : AbstractValidator<CriaCategoriaDTO>
{
    public CriaCategoriaDTOValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("Nome é obrigatório")
            .MaximumLength(100).WithMessage("Nome pode ter no máximo 100 caracteres");
    }
}