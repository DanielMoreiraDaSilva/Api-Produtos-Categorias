using System;
using Lab.Core.Model;
using Xunit;
using Lab.Repository;
using Lab.Core;
using Moq;
using Microsoft.EntityFrameworkCore;

namespace Api.Test
{
    public class UnitTest1
    {
        // private readonly ICategoria categoriaRepository;

        // public UnitTest1(ICategoria CategoriaRepository)
        // {
        //     this.categoriaRepository = CategoriaRepository;
        // }
        [Fact]
        public void TestAddCategoriaRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Contexto>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            var contexto = new Contexto(optionsBuilder.Options);
            // var mockContexto = new Mock<Contexto>();
            // contextoMock.Setup(c => c.Categorias).Returns(setMock.Object);
            var categoriaRepository = new CategoriaRepository(contexto);
            var categoria = new Categoria()
            {
                codigo = "1234",
                descricao = "Eletronico",
            };
            categoriaRepository.Add(categoria);

            Assert.Contains(categoria, contexto.Categorias);
        }
    }
}
