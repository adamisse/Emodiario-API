using Emodiario.Services.DTOs;
using Emodiario.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Emodiario.Routes;

public static class CategoriaEndpoints
{
    public static void ConfiguraEndpointsCategoria(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/api/usuarios/{idUsuario}/categorias", async ([FromRoute] int idUsuario, CriaCategoriaDTO categoriaDto, ICategoriaService categoriaService, IValidator<CriaCategoriaDTO> validator) =>
        {
            categoriaDto.idUsuario = idUsuario;
            var validationResult = validator.Validate(categoriaDto);
            if (!validationResult.IsValid)
                return Results.BadRequest(validationResult.Errors);

            var categoriaCriada = await categoriaService.CriaCategoriaAsync(idUsuario, categoriaDto);
            return Results.Created($"/api/categorias/{categoriaCriada.Id}", categoriaCriada);
        });

        endpoints.MapGet("/api/usuarios/{idUsuario}/categorias", async (int idUsuario, ICategoriaService categoriaService) =>
        {
            var categorias = await categoriaService.GetCategoriasByUsuarioIdAsync(idUsuario);
            return Results.Ok(categorias);
        });
    }
}