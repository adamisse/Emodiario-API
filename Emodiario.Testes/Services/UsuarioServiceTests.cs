using Microsoft.EntityFrameworkCore;
using Emodiario.Services;
using Emodiario.Services.DTOs;
using Emodiario.Data.Configuration;

namespace Emodiario.Testes.Services;

public class UsuarioServiceTests
{
    [Fact]
    public async Task CriaUsuarioAsync_WithValidData_ReturnsUsuarioDTO()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "BaseDeTestesEmMemoria")
            .Options;

        using (var context = new AppDbContext(options))
        {
            var service = new UsuarioService(context);
            var criaUsuarioDto = new CriaUsuarioDTO
            {
                Nome = "João da Silva",
                Email = "joao.silva@example.com",
                Senha = "senha123",
                Telefone = "999999999"
            };

            // Act
            var result = await service.CriaUsuarioAsync(criaUsuarioDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(criaUsuarioDto.Nome, result.Nome);
            Assert.Equal(criaUsuarioDto.Email, result.Email);
            Assert.Equal(criaUsuarioDto.Telefone, result.Telefone);
            Assert.NotEqual(0, result.Id);
        }
    }

    [Fact]
    public async Task LoginAsync_WithValidCredentials_ReturnsUsuarioDTO()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "BaseDeTestesEmMemoria")
            .Options;

        using (var context = new AppDbContext(options))
        {
            var service = new UsuarioService(context);

            var criaUsuarioDto = new CriaUsuarioDTO
            {
                Nome = "Maria Souza",
                Email = "maria.souza@example.com",
                Senha = "senha456",
                Telefone = "888888888"
            };
            await service.CriaUsuarioAsync(criaUsuarioDto);

            var loginDto = new LoginDTO
            {
                Email = criaUsuarioDto.Email,
                Senha = "senha456"
            };

            var result = await service.LoginAsync(loginDto);

            Assert.NotNull(result);
            Assert.Equal(criaUsuarioDto.Nome, result.Nome);
            Assert.Equal(criaUsuarioDto.Email, result.Email);
            Assert.Equal(criaUsuarioDto.Telefone, result.Telefone);
        }
    }

    [Fact]
    public async Task GetUsuarioByIdAsync_WithValidId_ReturnsUsuarioDTO()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "BaseDeTestesEmMemoria")
            .Options;

        using (var context = new AppDbContext(options))
        {
            var service = new UsuarioService(context);

            var criaUsuarioDto = new CriaUsuarioDTO
            {
                Nome = "Carlos Oliveira",
                Email = "carlos.oliveira@example.com",
                Senha = "senha789",
                Telefone = "777777777"
            };
            var createdUser = await service.CriaUsuarioAsync(criaUsuarioDto);

            var result = await service.GetUsuarioByIdAsync(createdUser.Id);

            Assert.NotNull(result);
            Assert.Equal(criaUsuarioDto.Nome, result.Nome);
            Assert.Equal(criaUsuarioDto.Email, result.Email);
            Assert.Equal(criaUsuarioDto.Telefone, result.Telefone);
        }
    }

    [Fact]
    public async Task GetUsuarioByUsernameAsync_WithValidUsername_ReturnsUsuarioDTO()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "BaseDeTestesEmMemoria")
            .Options;

        using (var context = new AppDbContext(options))
        {
            var service = new UsuarioService(context);

            var criaUsuarioDto = new CriaUsuarioDTO
            {
                Nome = "Fernanda Lima",
                Email = "fernanda.lima@example.com",
                Senha = "senhaabc",
                Telefone = "666666666"
            };
            var createdUser = await service.CriaUsuarioAsync(criaUsuarioDto);
            var result = await service.GetUsuarioByUsernameAsync(criaUsuarioDto.Nome);

            Assert.NotNull(result);
            Assert.Equal(criaUsuarioDto.Nome, createdUser.Nome);
            Assert.Equal(createdUser.Nome, result.Nome);
            Assert.Equal(criaUsuarioDto.Email, result.Email);
            Assert.Equal(criaUsuarioDto.Telefone, result.Telefone);
        }
    }
}