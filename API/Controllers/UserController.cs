using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Persistance.Interfaces;

namespace API.Controllers;

public class UserController : BaseController
{
    private IUserService _service;

    public UserController(IUserService service)
    {
        this._service = service;
    }

    [HttpGet]
    [Route(nameof(GetAllUsers))]
    public async Task<ActionResult> GetAllUsers()
    {
        var users = await _service.GetAllUsers();
        return Ok(users);
    }
    
    [HttpGet]
    [Route(nameof(GetUserById))]
    public async Task<ActionResult> GetUserById(int userId)
    {
        var user = await _service.GetUserById(userId);
        return Ok(user);
    }
    
    [HttpPost]
    [Route(nameof(Register))]
    public async Task<ActionResult> Register(string login, string password, string email, string phone, string type)
    {
        await _service.Register(new User() {Login = login, Email = email, Password = password, Phone = phone, Type = type});
        return Ok();
    }
    
    [HttpPut]
    [Route(nameof(Login))]
    public async Task<ActionResult> Login(string login, string password)
    {
        var user = await _service.Login(login, password);
        return Ok(user);
    }

    [HttpPut]
    [Route(nameof(UpdateUser))]
    public async Task<ActionResult> UpdateUser(int userId, string login, string password, string email, string phone, string type)
    {
        await _service.UpdateUser(new User() { Login = login, Email = email, Password = password, Phone = phone, Type = type, UserId = userId});
        return Ok();
    }

    [HttpDelete]
    [Route(nameof(DeleteUser))]
    public async Task<ActionResult> DeleteUser(int userId)
    {
        await _service.DeleteUser(userId);
        return Ok();
    }
}