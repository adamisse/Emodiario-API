using Emodiario.Services.DTOs;
using FluentValidation;

namespace Emodiario.Services.Validator;

public class CriaAvaliacaoDTOValidator : AbstractValidator<CriaAvaliacaoDTO>
{
    public CriaAvaliacaoDTOValidator()
    {
        RuleFor(x => x.Descricao)
            .MaximumLength(500).WithMessage("Descrição pode ter no máximo 500 caracteres");

        RuleFor(x => x.IdCategoria)
            .GreaterThan(0).WithMessage("ID da categoria deve ser maior que zero");
    }
}