using Microsoft.EntityFrameworkCore;
using Emodiario.Services;
using Emodiario.Services.DTOs;
using Emodiario.Data.Configuration;

namespace Emodiario.Testes.Services;

public class CategoriaServiceTests
{
    [Fact]
    public async Task CriaCategoriaAsync_WithValidData_ReturnsCategoriaDTO()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "BaseDeTestesEmMemoria")
            .Options;

        using (var context = new AppDbContext(options))
        {
            var service = new CategoriaService(context);
            var usuarioId = 1;
            var categoriaDto = new CriaCategoriaDTO
            {
                Nome = "Tecnologia",
                Descricao = "UFES",
                IdUsuario = usuarioId
            };

            var result = await service.CriaCategoriaAsync(usuarioId, categoriaDto);

            Assert.NotNull(result);
            Assert.Equal(categoriaDto.Nome, result.Nome);
            Assert.Equal(categoriaDto.Descricao, result.Descricao);
            Assert.Equal(categoriaDto.IdUsuario, result.IdUsuario);
        }
    }

    [Fact]
    public async Task GetCategoriasByUsuarioIdAsync_WithValidId_ReturnsListOfCategoriaDTO()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "BaseDeTestesEmMemoria")
            .Options;

        using (var context = new AppDbContext(options))
        {
            var service = new CategoriaService(context);
            var usuarioId = 1;

            var categoriaDto = new CriaCategoriaDTO
            {
                Nome = "Tecnologia",
                Descricao = "UFES",
                IdUsuario = usuarioId
            };
            await service.CriaCategoriaAsync(usuarioId, categoriaDto);

            var result = await service.GetCategoriasByUsuarioIdAsync(usuarioId);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            Assert.Equal(categoriaDto.Nome, result[0].Nome);
        }
    }
}