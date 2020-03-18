using Microsoft.AspNetCore.Mvc;
using Lab.Core;
using System;
using Lab.Core.Model;
using System.Collections.Generic;

namespace Lab.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class produtosController : ControllerBase
    {
        private readonly IBusinessProduto business;
        public produtosController(IBusinessProduto business)
        {
            this.business = business;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            List<Produto> produtos = business.GetAll();
            return Ok(produtos);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            return Ok(business.GetById(id));
        }
        [HttpGet("Search")]
        public ActionResult GetByDescricao(String descricao)
        {
            return Ok(business.GetDescricao(descricao));
        }
        [HttpPost]
        public ActionResult Post([FromBody]Produto produto)
        {
            business.Add(produto);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(Produto produto)
        {
            business.Update(produto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            business.Delete(id);
            return Ok();
        }

    }
}