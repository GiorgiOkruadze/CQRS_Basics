using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.ApplicationServices.Commands.ProductCommands;
using CQRS.ApplicationServices.Handlers.ProductHandlers;
using CQRS.ApplicationServices.Querys.ProductQuerys;
using CQRS.ApplicationShared.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CQRS_Basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator = default;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> Get()
        {
            var readProductQueryHandler = await _mediator.Send(new ReadAllProductQuerys());
            return readProductQueryHandler;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ProductDto> Get(int id)
        {
            return await _mediator.Send(new ReadProductByIdQuery() { Id = id });
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommand value)
        {
            return Ok(await _mediator.Send(value));
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
