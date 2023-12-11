using System;
using System.Linq;
using FilmeNepenApi.Data;
using FilmeNepenApi.Models;
using FilmeNepenApi.Repositories;
using FilmeNepenApi.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace FilmeNepenApi.Tests
{
    public class FilmeServiceTests
    {
        [Fact]
        public void ListarFilmes_DeveRetornarFilmesDoUsuario()
        {
            // Arrange
            var filmes = new[]
            {
                new Filme { Id = 1, Nome = "Filme1", UsernameCriador = "user1" },
                new Filme { Id = 2, Nome = "Filme2", UsernameCriador = "user2" },
                new Filme { Id = 3, Nome = "Filme3", UsernameCriador = "user1" },
            };

            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(repo => repo.GetAllFilmes()).Returns(filmes);

            var contextMock = new Mock<DataContext>();

            var filmeService = new FilmeService(repositoryMock.Object, contextMock.Object);

            // Act
            var result = filmeService.ListarFilmes(null, "user1");

            // Assert
            Assert.Equal(2, result.Length);
            Assert.True(result.All(f => f.UsernameCriador == "user1"));
        }

        [Fact]
        public void AdicionarFilme_DeveAdicionarFilme() { 
        
                var filme = new Filme { Nome = "NovoFilme", UsernameCriador = "user1" };
                // Arrange
                var dbContextOptions = new DbContextOptions<DataContext>();
                var dbContext = new Mock<DataContext>(dbContextOptions);
                var repository = new Mock<IRepository>();
                var filmeService = new FilmeService(repository.Object, dbContext.Object);

                // Act
                var result = filmeService.AdicionarFilmes(filme);

                // Assert
                repository.Verify(repo => repo.Add(filme), Times.Once);
                repository.Verify(repo => repo.SaveChanges(), Times.Once);
                Assert.Equal(filme, result);
        }

        // Adicione mais testes para os outros métodos conforme necessário
    }
}
