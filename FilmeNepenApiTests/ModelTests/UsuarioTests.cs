using FilmeNepenApi.Models;
using FilmeNepenApi.Models.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace FilmeNepenApiTests.ModelTests
{
    public class UsuarioValidatorTests
    {
        [Fact]
        public void UsuarioValidator_DevePassarQuandoPropriedadesSaoValidas()
        {
            // Arrange
            var usuario = new Usuario
            {
                Nome = "Nome do Usuário",
                Password = "senha123",
                Username = "user123"
            };

            var validator = new UsuarioValidator();

            // Act
            var result = validator.Validate(usuario);

            // Assert
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("", "senha123", "user123")]          // Nome vazio
        [InlineData("Nome", "", "user123")]               // Senha vazia
        [InlineData("Nome", "senha123", "")]              // Username vazio
        [InlineData("Na", "senha123", "user123")]        // Nome com menos de 3 caracteres
        public void UsuarioValidator_DeveFalharQuandoPropriedadesSaoInvalidas(string nome, string password, string username)
        {
            // Arrange
            var usuario = new Usuario
            {
                Nome = nome,
                Password = password,
                Username = username
            };

            var validator = new UsuarioValidator();

            // Act
            var result = validator.Validate(usuario);

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }
    }
}
