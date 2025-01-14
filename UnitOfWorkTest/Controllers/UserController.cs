using Microsoft.AspNetCore.Mvc;
using UnitOfWorkTest.DesignPatternRepository;
using UnitOfWorkTest.DesignPatternRepository.Classes;
using UnitOfWorkTest.DesignPatternRepository.Interfaces;
using UnitOfWorkTest.Data;

namespace UnitOfWorkTest.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    public UserController(
        ILogger<UserController> logger, 
        IUnitOfWork unitOfWork)
    {
        this._logger = logger;
        this._unitOfWork = unitOfWork;
    }


    [HttpGet("GetTopNUsers/{top}")]
    public async Task<IEnumerable<User>> GetTopNUsers(int top)
    {
        var users = await this._unitOfWork.UserRepository.GetTopNUsers(top);
        this._unitOfWork.Commit();
        return users;
    }

    [HttpPost("AddAsync")]
    public async Task<User> AddAsync([FromBody] User user)
    {
        var newUser = await this._unitOfWork.UserRepository.AddAsync(user);
        ActiveUser activeUser = new ActiveUser() { Id = newUser.Id, Active = true, User = newUser };
        await this._unitOfWork.ActiveUserRepository.AddAsync(activeUser);
        this._unitOfWork.Commit();
        return newUser;
    }


    [HttpDelete("DeleteAsync/{id}")]
    public async Task<User> DeleteAsync(int id)
    {
        var user = await this._unitOfWork.UserRepository.DeleteAsync(id);
        this._unitOfWork.Commit();
        return user;
    }
}
