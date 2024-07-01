using Emodiario.Data.Configuration;
using Emodiario.Services;
using Emodiario.Services.DTOs;
using Emodiario.Services.Interfaces;
using Emodiario.Services.Validator;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

// Serviços
builder.Services.AddValidatorsFromAssemblyContaining<LoginDtoValidator>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IAvaliacaoService, AvaliacaoService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API Documentation",
        Version = "v1"
    });
});

var app = builder.Build();

// Middlewares e roteamento
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Emodiário V1");
});

// Endpoints expostos via Minimal API
app.MapPost("/api/register", async (CriaUsuarioDTO criaUsuarioDTO, IUsuarioService userService, IValidator<CriaUsuarioDTO> validator) =>
{
    var validationResult = validator.Validate(criaUsuarioDTO);
    if (!validationResult.IsValid)
        return Results.BadRequest(validationResult.Errors);

    var createdUser = await userService.CriaUsuarioAsync(criaUsuarioDTO);
    return Results.Created($"/api/users/{createdUser.Id}", createdUser);
});

app.MapPost("/api/login", async (LoginDTO loginDto, IUsuarioService userService, IValidator<LoginDTO> validator) =>
{
    var validationResult = validator.Validate(loginDto);
    if (!validationResult.IsValid)
        return Results.BadRequest(validationResult.Errors);

    var user = await userService.LoginAsync(loginDto);

    if (user == null)
        return Results.Unauthorized();

    return Results.Ok(user);
});

app.MapGet("/api/users/{id}", async (int id, IUsuarioService userService) =>
{
    var user = await userService.GetUsuarioByIdAsync(id);

    if (user == null)
        return Results.NotFound();

    return Results.Ok(user);
});

// Categoria Endpoints
app.MapPost("/api/categorias", async (CriaCategoriaDTO categoriaDto, ICategoriaService categoriaService, IValidator<CriaCategoriaDTO> validator) =>
{
    var validationResult = validator.Validate(categoriaDto);
    if (!validationResult.IsValid)
        return Results.BadRequest(validationResult.Errors);

    var categoriaCriada = await categoriaService.CriaCategoriaAsync(categoriaDto);
    return Results.Created($"/api/categorias/{categoriaCriada.Id}", categoriaCriada);
});

app.MapGet("/api/categorias/usuario/{usuarioId}", async (int usuarioId, ICategoriaService categoriaService) =>
{
    var categorias = await categoriaService.GetCategoriasByUsuarioIdAsync(usuarioId);
    return Results.Ok(categorias);
});

// Avaliação Endpoints
app.MapPost("/api/avaliacoes", async (CriaAvaliacaoDTO avaliacaoDto, IAvaliacaoService avaliacaoService, IValidator<CriaAvaliacaoDTO> validator) =>
{
    var validationResult = validator.Validate(avaliacaoDto);
    if (!validationResult.IsValid)
        return Results.BadRequest(validationResult.Errors);

    var avaliacaoCriada = await avaliacaoService.CriaAvaliacaoAsync(avaliacaoDto);
    return Results.Created($"/api/avaliacoes/{avaliacaoCriada.Id}", avaliacaoCriada);
});

app.MapGet("/api/avaliacoes/usuario/{usuarioId}", async (int usuarioId, int? categoriaId, IAvaliacaoService avaliacaoService) =>
{
    var avaliacoes = await avaliacaoService.GetAvaliacoesByUsuarioIdAsync(usuarioId, categoriaId);
    return Results.Ok(avaliacoes);
});

app.Run();