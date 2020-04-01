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
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Newtonsoft.Json;
using Lab.Repository;
using Microsoft.EntityFrameworkCore;

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
            TestGetAll();
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

        public async void TestGetAll()
        {

            var endpoint = new Uri($"api/categorias", UriKind.Relative);
            var mockBusinesCategoria = new Mock<IBusinessCategoria>();

            var listCategoria = new List<Categoria>(){
                new Categoria(){
                    codigo = "1234",
                    descricao = "name"
                }
            };

            mockBusinesCategoria.Setup(m => m.GetAll()).Returns(listCategoria);

            var client = factory.WithWebHostBuilder(builder => builder.ConfigureServices(
                services => { 

                    services.AddTransient<IBusinessCategoria>(s => mockBusinesCategoria.Object); 

                })).CreateClient();

            var resposta = await client.GetAsync(endpoint);

            var respostaContent = await resposta.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<Categoria>>(respostaContent);

            
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
            Assert.Equal(result.FirstOrDefault().codigo, "1234");
            Assert.Equal(result.FirstOrDefault().descricao, "name");

        }

        [Fact]
        public async void TestGetById()
        {
        //Given

        var mockBusinesCategoria = new Mock<IBusinessCategoria>();
        var listCategoria = new List<Categoria>(){new Categoria(){
            Id = Guid.NewGuid(),
            codigo = "1234",
            descricao = "name"
        }};

        var endpoint = new Uri($"api/categorias/{listCategoria.FirstOrDefault().Id}", UriKind.Relative);

        mockBusinesCategoria.Setup(s => s.GetById(listCategoria.FirstOrDefault().Id)).Returns(listCategoria[0]);

        var client = factory.WithWebHostBuilder(builder => builder.ConfigureServices(services =>

            services.AddTransient<IBusinessCategoria>(s => mockBusinesCategoria.Object)
        
        )).CreateClient();

        //When

        var result = await client.GetAsync(endpoint);

        var resultContent = await result.Content.ReadAsStringAsync();

        var resultObject = JsonConvert.DeserializeObject<Categoria>(resultContent);
        
        //Then

        mockBusinesCategoria.Verify(m => m.GetById(listCategoria.FirstOrDefault().Id), Times.Once());
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.Equal("1234", resultObject.codigo);
        Assert.Equal("name", resultObject.descricao);
        
        }


        [Fact]
        public async void TestGetDescricao()
        {
        //Given

        var mockBusinesCategoria = new Mock<IBusinessCategoria>();
        var listCategoria = new List<Categoria>(){new Categoria(){
            Id = Guid.NewGuid(),
            codigo = "1234",
            descricao = "name"
        }};

        var endpoint = new Uri($"api/categorias/search?descricao={listCategoria.FirstOrDefault().descricao}", UriKind.Relative);

        mockBusinesCategoria.Setup(s => s.GetDescricao(listCategoria.FirstOrDefault().descricao)).Returns(listCategoria[0]);

        var client = factory.WithWebHostBuilder(builder => builder.ConfigureServices(services =>

            services.AddTransient<IBusinessCategoria>(s => mockBusinesCategoria.Object)
        
        )).CreateClient();

        //When

        var result = await client.GetAsync(endpoint);

        var resultContent = await result.Content.ReadAsStringAsync();

        var resultObject = JsonConvert.DeserializeObject<Categoria>(resultContent);
        
        //Then

        mockBusinesCategoria.Verify(m => m.GetDescricao(listCategoria.FirstOrDefault().descricao), Times.Once());
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.Equal("1234", resultObject.codigo);
        Assert.Equal("name", resultObject.descricao);
        
        }        


        [Fact]
        public async void TestDelete()
        {
            //Given
            var mockBusinesCategoria = new Mock<IBusinessCategoria>();            
            var listCategoria = new List<Categoria>(){new Categoria()
            {
                Id = Guid.NewGuid(),
                codigo = "1234",
                descricao = "name"
            }};

            var endpoint = new Uri($"api/categorias/{listCategoria.ToList().FirstOrDefault().Id}", UriKind.Relative);            

            mockBusinesCategoria.Setup(s => 
                
                s.Delete(listCategoria.FirstOrDefault().Id)
                
            );
            
            var client = factory.WithWebHostBuilder(builder => builder.ConfigureServices(services => {
                
                services.AddTransient<IBusinessCategoria>(s => mockBusinesCategoria.Object);
            
            })).CreateClient();


            //When
            var result = await client.DeleteAsync(endpoint);


            //Then
            mockBusinesCategoria.Verify(m => m.Delete(listCategoria.FirstOrDefault().Id), Times.Once());
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
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
            var mockBusinesCategoria = new Mock<IBusinessCategoria>();
            var controller = new categoriasController(mockBusinesCategoria.Object);

            //When
            controller.Put(categoria.Id,categoria);
        
            //Then
            mockBusinesCategoria.Verify(c => c.Update(categoria),Times.Once());
        }

        // [Fact]
        // public void TestDelete2()
        // {
        //     //Given

        //     var categoria = new Categoria()
        //     {
        //         Id = Guid.NewGuid(),
        //         codigo = "1234",
        //         descricao = "name"
        //     };
        //     var endpoint = new Uri($"api/categorias/{categoria.Id}", UriKind.Relative);

        //     //When
        //     var client = factory.CreateClient();
        //     var result = client.DeleteAsync(endpoint).Result;
        //     //Then
        //     Assert.Equal();
        // }
    }
}