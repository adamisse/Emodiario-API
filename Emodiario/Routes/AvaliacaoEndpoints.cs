using Emodiario.Services.DTOs;
using Emodiario.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Emodiario.Routes;

public static class AvaliacaoEndpoints
{
    public static void ConfigureEndpointsAvaliacao(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/api/categorias/{idCategoria}/avaliacoes", async ([FromRoute] int idCategoria, CriaAvaliacaoDTO avaliacaoDto, IAvaliacaoService avaliacaoService, ICategoriaService categoriaService, IValidator<CriaAvaliacaoDTO> validator) =>
        {
            var categoria = await categoriaService.GetCategoriaByIdAsync(idCategoria);
            if (categoria == null)
                return Results.NotFound($"Categoria com ID {idCategoria} não encontrada.");

            avaliacaoDto.IdCategoria = idCategoria;
            var validationResult = validator.Validate(avaliacaoDto);
            if (!validationResult.IsValid)
                return Results.BadRequest(validationResult.Errors);

            var avaliacaoCriada = await avaliacaoService.CriaAvaliacaoAsync(idCategoria, avaliacaoDto);
            return Results.Created($"/api/avaliacoes/{avaliacaoCriada.Id}", avaliacaoCriada);
        });

        endpoints.MapGet("/api/categorias/{idCategoria}/avaliacoes", async (int idCategoria, IAvaliacaoService avaliacaoService) =>
        {
            var avaliacoes = await avaliacaoService.GetAvaliacoesByCategoriaIdAsync(idCategoria);
            return Results.Ok(avaliacoes);
        });
    }
}