using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.DTOs.Products;
using OnlineShop.Application.Interfaces.Products;

namespace OnlineShop.API.Controllers
{
	[Route("api/products")]
	public class ProductsController : ApiControllerBase
	{
		private readonly IProductService _productService;

		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateProductRequestDto productDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var productModelDTO = await _productService.CreateAsync(productDTO);

			return CreatedAtAction(nameof(GetById), new { id = productModelDTO.Id }, productModelDTO);
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetAll()
		{
			var products = await _productService.GetAllAsync();
			return Ok(products);
		}


		[HttpGet("{id:Guid}")]
		public async Task<IActionResult> GetById([FromRoute] Guid id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var existingProduct = await _productService.GetByIdAsync(id);

			if (existingProduct == null)
			{
				return NotFound("The product does not exist.");
			}

			return Ok(existingProduct);
		}

		[HttpDelete]
		[Route("{id:Guid}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var existingProduct = await _productService.DeleteAsync(id);

			if (existingProduct == null)
			{
				return NotFound("The product does not exist.");
			}

			return NoContent();
		}
	}
}
