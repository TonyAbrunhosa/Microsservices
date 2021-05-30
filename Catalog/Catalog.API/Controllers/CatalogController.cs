using Catalog.Domain.Contracts.IService;
using Catalog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Base.Entity;
using Shared.Base.Contracts;

namespace Catalog.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductService _service;

        public CatalogController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ICommandResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ICommandResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                ICommandResult result = await _service.GetProducts();

                if (result.Success)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResult(false, ex.Message + ex.StackTrace));                
            }
        }

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ICommandResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ICommandResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProducts(string id)
        {
            try
            {
                ICommandResult result = await _service.GetProduct(id);

                if (result.Success)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResult(false, ex.Message + ex.StackTrace));
            }
        }

        [HttpGet("[action]/{category}", Name = "GetProductByCategory")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ICommandResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ICommandResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProductByCategory(string category)
        {
            try
            {
                ICommandResult result = await _service.GetProductByCategory(category);

                if (result.Success)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResult(false, ex.Message + ex.StackTrace));
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ICommandResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ICommandResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            try
            {
                ICommandResult result = await _service.CreateProduct(product);

                if (result.Success)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResult(false, ex.Message + ex.StackTrace));
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ICommandResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ICommandResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            try
            {
                ICommandResult result = await _service.UpdateProduct(product);

                if (result.Success)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResult(false, ex.Message + ex.StackTrace));
            }
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ICommandResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ICommandResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            try
            {
                ICommandResult result = await _service.DeleteProduct(id);

                if (result.Success)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResult(false, ex.Message + ex.StackTrace));
            }
        }
    }
}
