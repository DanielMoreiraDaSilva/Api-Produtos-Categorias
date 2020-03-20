using Microsoft.AspNetCore.Mvc;
using Lab.Core;
using System;
using Lab.Core.Model;
using System.Collections.Generic;
using Lab.Core.Mv;

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
            List<ProdutoViewModel> produtos = business.GetAll();
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
        public ActionResult Post([FromBody]ProdutoViewModel produto)
        {
            try
            {
                business.Add(produto);
                return Ok();
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(ProdutoViewModel produtoViewModel)
        {
            try
            {
                business.Update(produtoViewModel);
                return Ok();
            }
            catch (BusinessException Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            business.Delete(id);
            return Ok();
        }

    }
}