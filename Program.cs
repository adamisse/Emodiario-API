using Emodiario.Data.Configuration;
using Emodiario.Routes;
using Emodiario.Services;
using Emodiario.Services.Interfaces;
using Emodiario.Services.Validator;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

// Validator
builder.Services.AddValidatorsFromAssemblyContaining<LoginDtoValidator>();

// Servi�os
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IAvaliacaoService, AvaliacaoService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Emodi�rio API",
        Version = "v1"
    });
});

var app = builder.Build();

// Middlewares e roteamento
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Emodi�rio V1");
});

app.UseRouting();

// Configura��o das rotas
app.UseEndpoints(endpoints =>
{
    endpoints.ConfiguraEndpointsUsuario();
    endpoints.ConfiguraEndpointsCategoria();
    endpoints.ConfigureEndpointsAvaliacao();
});

app.Run();