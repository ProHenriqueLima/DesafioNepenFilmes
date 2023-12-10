using System;
using FilmeNepenApi.Models;
using FilmeNepenApi.Models.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace FilmeNepenApiTests.ModelTests
{
    public class FilmeValidatorTests
    {
        [Fact]
        public void FilmeValidator_DevePassarQuandoPropriedadesSaoValidas()
        {
            // Arrange
            var filme = new Filme
            {
                Nome = "Filme Teste",
                Descricao = "Descrição do Filme",
                AnoLancamento = 2000
            };

            var validator = new FilmeValidator();

            // Act
            var result = validator.Validate(filme);

            // Assert
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("", "Descrição do Filme", 2000)] // Nome vazio
        [InlineData("Filme Teste", "", 2000)]         // Descrição vazia
        [InlineData("Filme Teste", "Descrição do Filme", 2025)]  // AnoLancamento maior que 2024
        [InlineData("Filme Teste", "Descrição do Filme", 1890)]  // AnoLancamento menor que 1895
        public void FilmeValidator_DeveFalharQuandoPropriedadesSaoInvalidas(string nome, string descricao, int anoLancamento)
        {
            // Arrange
            var filme = new Filme
            {
                Nome = nome,
                Descricao = descricao,
                AnoLancamento = anoLancamento
            };

            var validator = new FilmeValidator();

            // Act
            var result = validator.Validate(filme);

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }
    }
}