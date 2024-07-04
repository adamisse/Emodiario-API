using Microsoft.EntityFrameworkCore;
using Emodiario.Services;
using Emodiario.Services.DTOs;
using Emodiario.Data.Configuration;
using Emodiario.Utils.Enums;

namespace Emodiario.Testes.Services;

public class AvaliacaoServiceTests
{
    [Fact]
    public async Task CriaAvaliacaoAsync_WithValidData_ReturnsAvaliacaoDTO()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "BaseDeTestesEmMemoria")
        .Options;

        using (var context = new AppDbContext(options))
        {
            var service = new AvaliacaoService(context);
            var idCategoria = 1;
            var avaliacaoDto = new CriaAvaliacaoDTO
            {
                Valor = ValorAvaliacao.Normal,
                Descricao = "Sistemas Operacionais",
                IdCategoria = idCategoria
            };

            var result = await service.CriaAvaliacaoAsync(idCategoria, avaliacaoDto);

            Assert.NotNull(result);
            Assert.Equal(idCategoria, result.IdCategoria);
        }
    }

    [Fact]
    public async Task GetAvaliacoesByCategoriaIdAsync_WithValidId_ReturnsListOfAvaliacaoDTO()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "BaseDeTestesEmMemoria")
            .Options;

        using (var context = new AppDbContext(options))
        {
            var service = new AvaliacaoService(context);
            var categoriaId = 1;

            var avaliacaoDto = new CriaAvaliacaoDTO
            {
                Valor = ValorAvaliacao.Normal,
                Descricao = "Sistemas Operacionais",
                IdCategoria = categoriaId
            };

            if (context.Avaliacoes.Count() == 0)
                await service.CriaAvaliacaoAsync(categoriaId, avaliacaoDto);

            var result = await service.GetAvaliacoesByCategoriaIdAsync(categoriaId);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            Assert.Equal(avaliacaoDto.Valor, result[0].Valor);
        }
    }
}