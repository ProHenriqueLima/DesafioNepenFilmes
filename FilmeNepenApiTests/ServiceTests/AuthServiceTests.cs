using System;
using System.Linq;
using System.Threading.Tasks;
using FilmeNepenApi.Data;
using FilmeNepenApi.Models;
using FilmeNepenApi.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FilmeNepenApiTests.ServiceTests
{
    public class AuthServiceTests
    {
        [Fact]
        public async Task Cadastrar_DeveCadastrarUsuarioComSenhaCriptografada()
        {
            // Arrange
            var dbContextOptions = new DbContextOptions<DataContext>();
            using (var context = new DataContext(dbContextOptions))
            {
                var authService = new AuthService(context);

                // Act
                var usuario = await authService.Cadastrar(new Usuario
                {
                    Nome = "TestUser",
                    Username = "testuser",
                    Password = "testpassword",
                    Cargo = "TestCargo",
                    Ativo = 1
                });

                // Assert
                Assert.NotNull(usuario);
                Assert.NotEqual("testpassword", usuario.Password);
            }
        }
    }
}