using System;
using Lab.Api.Controllers;
using Xunit;
using Lab.Core;
using Moq;
using Lab.Core.Model;
using Microsoft.AspNetCore.Mvc.Testing;
using Lab.Api;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace Api.TestFuncional
{
    public class TestFuncional
            : IClassFixture<WebApplicationFactory<Startup>>

    {
        private readonly WebApplicationFactory<Startup> factory;
        // private readonly HttpClient client;

        public TestFuncional(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        // [Fact]
        // public void TestPost()
        // {
        //     var mockBusines = new Mock<IBusinessCategoria>();

        //     var controller = new categoriasController(mockBusines.Object);

        //     var categoria = new Categoria()
        //     {
        //         codigo = "1234",
        //         descricao = "nome"

        //     };

        //     controller.Post(categoria);

        //     mockBusines.Verify(c => c.Add(categoria), Times.Once());

        // }

        // [Fact]
        // public void TestDelete()
        // {
        //     var mockBusines = new Mock<IBusinessCategoria>();
        //     var controller = new categoriasController(mockBusines.Object);

        //     var categoria = new Categoria()
        //     {
        //         codigo = "1234",
        //         descricao = "nome"
        //     };
        //     controller.Post(categoria);
        //     controller.Delete(categoria.Id);

        //     mockBusines.Verify(c => c.Delete(categoria.Id), Times.Once);
        // }

        //     controller.Post(categoria);
        //     controller.Delete(categoria.Id);

        //     http://localhost:8080/#/categorias/create

        //     fetch('http://localhost:8080/#/categorias/create', {
        //         method: 'POST',
        //         body: JSON.stringify({
        //         title: 'foo',
        //         body: 'bar',
        //         userId: 1
        //     }),
        //     headers: {
        //         "Content-type": "application/json; charset=UTF-8"
        //     }
        //     })
        //         .then(response => response.json())
        //             .then(json => console.log(json))


        // }

        [Fact]

        public void TestGetAll()
        {

            var endpoint = new Uri($"api/categorias", UriKind.Relative);

            var client = factory.CreateClient();

            var resposta = client.GetAsync(endpoint).Result;

            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);

        }
        [Fact]
        public void TestGetById()
        {
            //Given
            var client = factory.CreateClient();
            var categoria = new Categoria()
            {
                Id = Guid.NewGuid(),
                codigo = "1234",
                descricao = "name"
            };
            var endpoint = new Uri($"api/categorias/{categoria.Id}", UriKind.Relative);

            //When
            var result = client.GetAsync(endpoint).Result;

            //Then
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }

        [Fact]
        public void TestGetByDescricao()
        {
            //Given
            var client = factory.CreateClient();
            var categoria = new Categoria()
            {
                Id = Guid.NewGuid(),
                codigo = "1234",
                descricao = "name"
            };
            var endpoint = new Uri($"api/categorias/search?{categoria.descricao}", UriKind.Relative);

            //When
            var result = client.GetAsync(endpoint).Result;

            //Then
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }


        [Fact]
        public void TestPost()
        {
            //Given

            var endpoint = new Uri($"api/categorias", UriKind.Relative);

            var categoria = new Categoria()
            {
                Id = Guid.NewGuid(),
                codigo = "1234",
                descricao = "name"
            };
            //When
            var client = factory.CreateClient();
            var result = client.PostAsync(endpoint, categoria, new JsonMediaTypeFormatter()).Result;
            //Then
            Assert.Equal(HttpStatusCode.OK,result.StatusCode);
        }

        [Fact]
        public void TestPut()
        {
            //Given

            var categoria = new Categoria()
            {
                Id = Guid.NewGuid(),
                codigo = "1234",
                descricao = "name"
            };
            var endpoint = new Uri($"api/categorias/{categoria.Id}", UriKind.Relative);

            //When
            var client = factory.CreateClient();
            var result = client.PutAsync(endpoint, categoria, new JsonMediaTypeFormatter()).Result;
            //Then
            Assert.Equal(HttpStatusCode.OK,result.StatusCode);
        }
    }
}