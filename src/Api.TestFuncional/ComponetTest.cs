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

namespace Api.TestFuncional
{
    public class ComponentTest
            : IClassFixture<WebApplicationFactory<Startup>>

    {
        private readonly WebApplicationFactory<Startup> factory;
        private readonly HttpClient client;

        public ComponentTest(WebApplicationFactory<Startup> factory, HttpClient client)
        {
            this.factory = factory;
            this.client = factory.CreateClient();
        }

        [Fact]
        public void TestPost()
        {
            var mockBusines = new Mock<IBusinessCategoria>();
            
            var controller = new categoriasController(mockBusines.Object);
            
            var categoria = new Categoria(){
                codigo = "1234",
                descricao = "nome"
            
            };

            controller.Post(categoria);

            mockBusines.Verify(c => c.Add(categoria),Times.Once());

        }

        // [Fact]
        // public void TestDelete()
        // {
        //     var mockBusines = new Mock<IBusinessCategoria>();
        //     var controller = new categoriasController(mockBusines.Object);

        //     var categoria = new Categoria(){
        //         codigo = "1234",
        //         descricao = "nome"
        //     };

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
        
        public void Teste()
        {

            var endpoint = new Uri($"api/categorias", UriKind.Relative);

            var client = factory.CreateClient();

            var resposta = client.GetAsync(endpoint).Result;

            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
    
        }
    }
}
