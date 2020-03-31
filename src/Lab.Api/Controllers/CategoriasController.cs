using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab.Business;
using Lab.Core.Model;
using Lab.Core;



namespace Lab.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class categoriasController : ControllerBase
    {
        private readonly IBusinessCategoria business;

        public categoriasController(IBusinessCategoria business)
        {
            this.business = business;
        }

        [HttpGet]
        public ActionResult Get()
        {
            List<Categoria> categorias = business.GetAll();
            return Ok(categorias);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            try
            {
                return Ok(business.GetById(id));
            }
            catch(Exception)
            {
                return NotFound();
            }
        }    
        [HttpGet("Search")]
        public ActionResult GetByDescriçao([FromQuery]string descricao)
        {
            return Ok(business.GetDescricao(descricao));
        }
        [HttpPost]
        public ActionResult Post([FromBody]Categoria categoria)
        {
            try
            {
                business.Add(categoria);
                return Ok();
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, Categoria categoria)
        {
            try
            {
                categoria.Id = id;
                business.Update(categoria);
                return Ok();
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
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

