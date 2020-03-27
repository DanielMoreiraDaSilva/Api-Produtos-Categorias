using System;
using Lab.Business;
using Lab.Core;
using Lab.Core.Model;
using Moq;
using Xunit;

namespace Api.TestUnitário
{
    public class TestUnitarioBusinessCategoria
    {
        [Fact]
        public void TestFailAddCategoriaAttributeCodigoLowerThanFourDigits()
        {
            var mockCategoriaRepository = new Mock<ICategoria>();
            var businessCategoria = new BusinessCategoria(mockCategoriaRepository.Object);

            var categoria = new Categoria() { codigo = "123" };

            Assert.Throws<BusinessException>(() => businessCategoria.Add(categoria));
        }

        [Fact]
        public void TestFailAddCategoriaAttributeCodigoBiggerThanFourDigits()
        {
            var mockCategoriaRepository = new Mock<ICategoria>();
            var businessCategoria = new BusinessCategoria(mockCategoriaRepository.Object);

            var categoria = new Categoria() { codigo = "12345" };

            Assert.Throws<BusinessException>(() => businessCategoria.Add(categoria));

        }

        [Fact]
        public void TestAddCategoria()
        {
            var mockCategoriaRepository = new Mock<ICategoria>();
            var businessCategoria = new BusinessCategoria(mockCategoriaRepository.Object);

            var categoria = new Categoria() { codigo = "1234", descricao = "budega" };

            businessCategoria.Add(categoria);

            mockCategoriaRepository.Verify(m => m.Add(categoria), Times.Once());

        }

        [Fact]
        public void TestFailUpdateCategoriaAttributeBiggerThanFourDigits()
        {
            
            var mockCategoriaRepository = new Mock<ICategoria>();
            var businessCategoria = new BusinessCategoria(mockCategoriaRepository.Object);

            var categoria = new Categoria() { codigo = "1234" };

            businessCategoria.Add(categoria);

            categoria.codigo = "12345";

            Assert.Throws<BusinessException>(() => businessCategoria.Update(categoria));
        }

        [Fact]
        public void TestFailUpdateCategoriaAttributeLowerThanFourDigits()
        {
            
            var mockCategoriaRepository = new Mock<ICategoria>();
            var businessCategoria = new BusinessCategoria(mockCategoriaRepository.Object);

            var categoria = new Categoria() { codigo = "1234" };

            businessCategoria.Add(categoria);

            categoria.codigo = "123";

            Assert.Throws<BusinessException>(() => businessCategoria.Update(categoria));
        }

        [Fact]
        public void TestUpdateCategoria()
        {
            var mockCategoriaRepository = new Mock<ICategoria>();
            var businessCategoria = new BusinessCategoria(mockCategoriaRepository.Object);

            var categoria = new Categoria() { codigo = "1234", descricao = "budega" };

            businessCategoria.Add(categoria);

            categoria.codigo = "4567";

            businessCategoria.Update(categoria);

            mockCategoriaRepository.Verify(m => m.Update(categoria), Times.Once());

        }
    }
}
