using Microsoft.AspNetCore.Mvc;
using UnitOfWorkTest.Repositories;
using UnitOfWorkTest.Repositories.Classes;
using UnitOfWorkTest.Repositories.Interfaces;

namespace UnitOfWorkTest.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    public UserController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork as UnitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }


    [HttpGet("GetTopNUsers/{top}")]
    public async Task<IEnumerable<User>> GetTopNUsers(int top)
    {
        var users = await this._unitOfWork.UserRepository.GetTopNUsers(top);
        await this._unitOfWork.CommitAsync();
        return users;
    }

    [HttpGet("AddAsync")]
    public async Task<User> AddAsync()
    {
        User _user = new User() { Name = $"John - {DateTime.Now}" };
        var newUser = await this._unitOfWork.UserRepository.AddAsync(_user);
        await this._unitOfWork.ActiveUserRepository.AddAsync(new ActiveUser() { Id=1, Active = true });
        await this._unitOfWork.CommitAsync();
        return newUser;
    }

}
