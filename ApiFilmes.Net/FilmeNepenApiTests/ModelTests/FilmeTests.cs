using FilmeNepenApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit;

namespace FilmeNepenApi.Tests
{
    public class FilmeTests
    {
        [Fact]
        public void Filme_DeveTerAtributoId()
        {
            // Arrange
            var filme = new Filme();

            // Act
            var idProperty = filme.GetType().GetProperty("Id");

            // Assert
            Assert.NotNull(idProperty);
            Assert.True(idProperty.GetCustomAttributes(typeof(KeyAttribute), false).Length > 0);
            Assert.True(idProperty.GetCustomAttributes(typeof(DatabaseGeneratedAttribute), false).Length > 0);
        }

        [Theory]
        [InlineData(1, "Nome", "Descricao", "Banner", "Ano", "Comentario", "Usuario")]
        public void Filme_DeveInicializarCorretamente(int id, string nome, string descricao, string banner, string anoLancamento, string comentario, string usernameCriador)
        {
            // Arrange & Act
            var filme = new Filme(id, nome, descricao, banner, anoLancamento, comentario, usernameCriador);

            // Assert
            Assert.Equal(id, filme.Id);
            Assert.Equal(nome, filme.Nome);
            Assert.Equal(descricao, filme.Descricao);
            Assert.Equal(banner, filme.Banner);
            Assert.Equal(anoLancamento, filme.AnoLancamento);
            Assert.Equal(comentario, filme.Comentario);
            Assert.Equal(usernameCriador, filme.UsernameCriador);
        }

        [Theory]
        [InlineData(null, "Descricao", "Banner", "Ano", "Comentario", "Usuario")]
        [InlineData("", "Descricao", "Banner", "Ano", "Comentario", "Usuario")]
        public void Filme_DeveFalharValidacaoSemNome(string nome, string descricao, string banner, string anoLancamento, string comentario, string usernameCriador)
        {
            // Arrange
            var filme = new Filme(1, nome, descricao, banner, anoLancamento, comentario, usernameCriador);
            var context = new ValidationContext(filme, null, null);
            var results = new System.Collections.Generic.List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(filme, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Single(results);
            Assert.Equal("O campo Nome é obrigatório.", results[0].ErrorMessage);
        }

        // Adicione mais testes para validar outras propriedades conforme necessário
    }
}
