using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Persistance.Interfaces;

namespace API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route(nameof(GetAllProducts))]
        public async Task<ActionResult> GetAllProducts()
        {
            var products = await _service.GetAllProducts();
            return Ok(products);
        }

        [HttpGet]
        [Route(nameof(GetProductById))]
        public async Task<ActionResult> GetProductById(int productId)
        {
            var product = await _service.GetProductById(productId);
            return Ok(product);
        }

        [HttpPost]
        [Route(nameof(AddProduct))]
        public async Task<ActionResult> AddProduct(DateTime expirationDate)
        {
            await _service.AddProduct(new Product() { ExpirationDate = expirationDate });
            return Ok();
        }

        [HttpPut]
        [Route(nameof(UpdateProduct))]
        public async Task<ActionResult> UpdateProduct(int productId, DateTime expirationDate)
        {
            await _service.UpdateProduct(new Product() { ProductId = productId, ExpirationDate = expirationDate });
            return Ok();
        }

        [HttpDelete]
        [Route(nameof(DeleteProduct))]
        public async Task<ActionResult> DeleteProduct(int productId)
        {
            await _service.DeleteProduct(productId);
            return Ok();
        }
    }
}