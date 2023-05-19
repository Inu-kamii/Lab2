using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Persistance.Interfaces;

namespace API.Controllers;

public class UserProductController : BaseController
{
    private readonly IUserProductService _service;

    public UserProductController(IUserProductService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route(nameof(GetProductsByUserId))]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsByUserId(int userId)
    {
        var products = await _service.GetProductsByUserId(userId);
        return Ok(products);
    }

    [HttpGet]
    [Route(nameof(GetUsersByProductId))]
    public async Task<ActionResult<IEnumerable<User>>> GetUsersByProductId(int productId)
    {
        var users = await _service.GetUsersByProductId(productId);
        return Ok(users);
    }

    [HttpPost]
    [Route(nameof(AddUserProduct))]
    public async Task<ActionResult> AddUserProduct(int userId, int productId)
    {
        await _service.AddUserProduct(userId, productId);
        return Ok();
    }

    [HttpDelete]
    [Route(nameof(DeleteUserProduct))]
    public async Task<ActionResult> DeleteUserProduct(int userId, int productId)
    {
        await _service.DeleteUserProduct(userId, productId);
        return Ok();
    }
}