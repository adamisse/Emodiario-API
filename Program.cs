using Emodiario.Data.Configuration;
using Emodiario.Models;
using Emodiario.Services;
using Emodiario.Services.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

// Serviços
builder.Services.AddValidatorsFromAssemblyContaining<LoginDtoValidator>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

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

app.Run();