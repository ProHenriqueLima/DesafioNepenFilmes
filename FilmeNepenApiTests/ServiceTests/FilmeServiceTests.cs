using FilmeNepenApi.Data;
using FilmeNepenApi.Models;
using FilmeNepenApi.Repositories;
using FilmeNepenApi.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace FilmeNepenApiTests.ServiceTests
{
    public class FilmeServiceTests
    {
        [Fact]
        public void ListarFilmes_DeveRetornarFilmesCorretosComPesquisa()
        {
            // Arrange
            var dbContextOptions = new DbContextOptions<DataContext>();
            var dbContext = new Mock<DataContext>(dbContextOptions);
            var repository = new Mock<IRepository>();
            var filmeService = new FilmeService(repository.Object, dbContext.Object);

            var filmes = new Filme[]
            {
            new Filme { Id = 1, Nome = "Filme A", Descricao = "Descrição A", AnoLancamento = 2020 },
            new Filme { Id = 2, Nome = "Filme B", Descricao = "Descrição B", AnoLancamento = 2021 },
            };
            repository.Setup(r => r.GetAllFilmes()).Returns(filmes);

            // Act
            var resultado1 = filmeService.ListarFilmes(null); // Sem pesquisa
            var resultado2 = filmeService.ListarFilmes(""); // Pesquisa vazia
            var resultado3 = filmeService.ListarFilmes("A"); // Pesquisa válida

            // Assert
            Assert.Equal(filmes, resultado1);
            Assert.Equal(filmes, resultado2);
            Assert.Equal(new Filme[] { filmes[0] }, resultado3);
        }

        [Fact]
        public void AdicionarFilmes_DeveAdicionarFilmeCorretamente()
        {
            // Arrange
            var dbContextOptions = new DbContextOptions<DataContext>();
            var dbContext = new Mock<DataContext>(dbContextOptions);
            var repository = new Mock<IRepository>();
            var filmeService = new FilmeService(repository.Object, dbContext.Object);

            var novoFilme = new Filme { Id = 3, Nome = "Novo Filme", Descricao = "Nova Descrição", AnoLancamento = 2022 };

            // Act
            var resultado = filmeService.AdicionarFilmes(novoFilme);

            // Assert
            repository.Verify(r => r.Add(novoFilme), Times.Once);
            repository.Verify(r => r.SaveChanges(), Times.Once);
            Assert.Equal(novoFilme, resultado);
        }

        [Fact]
        public void FilmeExistente_DeveRetornarCorretamente()
        {
            // Arrange
            var dbContextOptions = new DbContextOptions<DataContext>();
            var dbContext = new Mock<DataContext>(dbContextOptions);
            var repository = new Mock<IRepository>();
            var filmeService = new FilmeService(repository.Object, dbContext.Object);

            var filmes = new Filme[]
            {
            new Filme { Id = 1, Nome = "Filme A", Descricao = "Descrição A", AnoLancamento = 2020 },
            new Filme { Id = 2, Nome = "Filme B", Descricao = "Descrição B", AnoLancamento = 2021 },
            };
            repository.Setup(r => r.GetAllFilmes()).Returns(filmes);

            // Act
            var resultado1 = filmeService.FilmeExistente("Filme A"); // Filme existente
            var resultado2 = filmeService.FilmeExistente("Filme C"); // Filme inexistente

            // Assert
            Assert.True(resultado1);
            Assert.False(resultado2);
        }

    }
}
