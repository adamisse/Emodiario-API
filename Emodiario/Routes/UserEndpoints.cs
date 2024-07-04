using Emodiario.Services.DTOs;
using Emodiario.Services.Interfaces;
using FluentValidation;

namespace Emodiario.Routes;

public static class UsuarioEndpoints
{
    public static void ConfiguraEndpointsUsuario(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/api/usuarios", async (CriaUsuarioDTO criaUsuarioDTO, IUsuarioService userService, IValidator<CriaUsuarioDTO> validator) =>
        {
            var validationResult = validator.Validate(criaUsuarioDTO);
            if (!validationResult.IsValid)
                return Results.BadRequest(validationResult.Errors);

            var createdUser = await userService.CriaUsuarioAsync(criaUsuarioDTO);
            return Results.Created($"/api/usuarios/{createdUser.Id}", createdUser);
        });

        endpoints.MapPost("/api/usuarios/login", async (LoginDTO loginDto, IUsuarioService userService, IValidator<LoginDTO> validator) =>
        {
            var validationResult = validator.Validate(loginDto);
            if (!validationResult.IsValid)
                return Results.BadRequest(validationResult.Errors);

            var user = await userService.LoginAsync(loginDto);

            if (user == null)
                return Results.Unauthorized();

            return Results.Ok(user);
        });

        endpoints.MapGet("/api/usuarios/{id}", async (int id, IUsuarioService userService) =>
        {
            var user = await userService.GetUsuarioByIdAsync(id);

            if (user == null)
                return Results.NotFound();

            return Results.Ok(user);
        });
    }
}