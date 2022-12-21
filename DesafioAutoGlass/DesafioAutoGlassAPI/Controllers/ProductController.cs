using DesafioAutoGlass.Application.DTOs;
using DesafioAutoGlass.Core.DTOs;
using DesafioAutoGlass.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioAutoGlass.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] ProductDto product)
        {
            var result = await _productService.AddAsync(product);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _productService.RemoveAsync(id);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ProductDto product)
        {
            var result = await _productService.UpdateAsync(product);

            return Ok(result);
        }

        [HttpGet]
        public ActionResult Get(int id)
        {
            var result = _productService.GetById(id);

            return Ok(result);
        }

        [HttpPost("Filter")]
        public ActionResult GetFilter([FromBody] ProductSearchDto filter)
        {
            var result = _productService.GetByFilterAsync(filter);

            return Ok(result);
        }
    }
}
