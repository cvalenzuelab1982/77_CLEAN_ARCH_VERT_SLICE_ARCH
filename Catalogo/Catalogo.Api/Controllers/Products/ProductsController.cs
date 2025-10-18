using Catalogo.Application.Products.AllProducts;
using Catalogo.Application.Products.CreateProduct;
using Catalogo.Application.Products.SearchProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Api.Controllers.Products
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductsController(ISender sender)
        {
            _sender = sender;
        }


        [HttpGet("code/{value}")]
        public async Task<IActionResult> GetByCode(string value)
        {
            HttpContext context = HttpContext;
            var query = new SearchProductQuery { Code = value, Context = context };
            var product = await _sender.Send(query);
            return Ok(product); 
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            HttpContext context = HttpContext;
            var query = new AllProductsQuery { Context = context };
            var productDTOs = await _sender.Send(query);
            return Ok(productDTOs);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductRequest request)
        {
            var command = new CreateProductCmd(request.Nombre, request.Descripcion, request.Precio, request.CategoriaId);
            var resultado =  await _sender.Send(command);
            return Ok(resultado);   
        }
    }
}
