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
        public void Test1()
        {
            var contextoMock = new Mock<Contexto>();
            var setMock = new Mock<DbSet<Categoria>>();
            contextoMock.Setup(c => c.Categorias).Returns(setMock.Object);
            var categoriaRepository = new CategoriaRepository(contextoMock.Object);

            var categoria = new Categoria()
            {
                codigo = "1234",
                descricao = "Eletronico",
            };
            
            categoriaRepository.Add(categoria);
            // var teste = categoria;
            // var teste = categoriaRepository.GetById(categoria.Id);
            contextoMock.Verify(c => c.SaveChanges(),Times.Once());
        }
    }
}
