using System;
using Lab.Core.Model;
using Xunit;
using Lab.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Api.Test
{
    public class TestCategoriaRepositoy
    {

        [Fact] 
        public void TestAddCategoriaRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Contexto>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            var contexto = new Contexto(optionsBuilder.Options);
            var categoriaRepository = new CategoriaRepository(contexto);
            var categoria = new Categoria()
            {
                codigo = "1234",
                descricao = "Eletronico",
            };
            categoriaRepository.Add(categoria);

            Assert.Contains(categoria, contexto.Categorias);
        }

        [Fact]
        public void TestDeleteCategoriaRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Contexto>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            var contexto = new Contexto(optionsBuilder.Options);

            var categoriaRepository = new CategoriaRepository(contexto);

            var categoria = new Categoria() { codigo = "1234", descricao = "categoria" };

            categoriaRepository.Add(categoria);

            categoriaRepository.Delete(categoria.Id);

            Assert.Empty(contexto.Categorias);
        }

        [Fact]
        public void TestGetCategoriaRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Contexto>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            var contexto = new Contexto(optionsBuilder.Options);

            var categoriaRepository = new CategoriaRepository(contexto);
            var categoria1 = new Categoria() { codigo = "1234", descricao = "Categoria1" };
            var categoria2 = new Categoria();

            categoriaRepository.Add(categoria1);
            categoriaRepository.Add(categoria2);

            var getCategoria = categoriaRepository.GetCategoria(categoria1);
            var getCategoriaIdEmpty = categoriaRepository.GetCategoria(categoria2);

            //if (id da categoria tiver algum valor)
            Assert.Equal(categoria1.Id, getCategoria);
            //else (id da categoria for null)
            Assert.Equal(Guid.Empty, getCategoriaIdEmpty);

        }

        [Fact]
        public void TestGetByDescricaoCategoriaRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Contexto>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            var contexto = new Contexto(optionsBuilder.Options);

            var categoriaRepository = new CategoriaRepository(contexto);
            var categoria1 = new Categoria() { codigo = "1234", descricao = "Categoria1" };

            categoriaRepository.Add(categoria1);

            var getCategoriaByDescricao = categoriaRepository.GetDescricao(categoria1.descricao);

            Assert.Equal(categoria1, getCategoriaByDescricao);

        }

        [Fact]
        public void TestGetAllCategoriaRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Contexto>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            var contexto = new Contexto(optionsBuilder.Options);

            var categoriaRepository = new CategoriaRepository(contexto);
            var categoria1 = new Categoria() { codigo = "1234", descricao = "Categoria1" };
            var categoria2 = new Categoria() { codigo = "4567", descricao = "Categoria2" };
            var categoria3 = new Categoria() { codigo = "8910", descricao = "Categoria3" };

            List<Categoria> listaCategoria = new List<Categoria>();
            listaCategoria.Add(categoria1);
            listaCategoria.Add(categoria2);
            listaCategoria.Add(categoria3);

            categoriaRepository.Add(categoria1);
            categoriaRepository.Add(categoria2);
            categoriaRepository.Add(categoria3);

            Assert.Equal(listaCategoria, contexto.Categorias);
        }

        [Fact]
        public void TestGetByIdCategoriaRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Contexto>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            var contexto = new Contexto(optionsBuilder.Options);

            var categoriaRepository = new CategoriaRepository(contexto);
            var categoria1 = new Categoria() { codigo = "1234", descricao = "Categoria1" };

            categoriaRepository.Add(categoria1);

            var getCategoriaById = categoriaRepository.GetById(categoria1.Id);

            Assert.Equal(categoria1, getCategoriaById);

        }

        [Fact]
        public void TestUpdateCategoriaRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Contexto>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            var contexto = new Contexto(optionsBuilder.Options);

            var categoriaRepository = new CategoriaRepository(contexto);

            var categoria1 = new Categoria() { codigo = "1234", descricao = "ABCD" };
            categoriaRepository.Add(categoria1);

            // var categoria2 = new Categoria(){Id = categoria1.Id, codigo = "5678", descricao = "EFGH"};
            categoria1.descricao = "EFGH";
            categoria1.codigo = "5678";
            categoriaRepository.Update(categoria1);

            Assert.Equal("EFGH", categoriaRepository.GetById(categoria1.Id).descricao);
            Assert.Equal("5678", categoriaRepository.GetById(categoria1.Id).codigo);

        }
    }
}
