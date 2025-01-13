using Microsoft.AspNetCore.Mvc;
using UnitOfWorkTest.Repositories;
using UnitOfWorkTest.Repositories.classes;
using UnitOfWorkTest.Repositories.Interfaces;

namespace UnitOfWorkTest.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly MyDbContext _context;
    private readonly IUserRepository _userRepository;

    public UserController(
        ILogger<UserController> logger,
        MyDbContext context,
        IUserRepository userRepository)
    {
        this._logger = logger;
        this._context = context;
        this._userRepository = userRepository;
    }

    [HttpGet("GetTopNUsers/{top}")]
    public async Task<IEnumerable<User>> GetTopNUsers(int top)
    {
        return await this._userRepository.GetTopNUsers(top);
    }

    [HttpGet("GetByIdAsync/{id}")]
    public async Task<User> GetByIdAsync(int id)
    {
        return await this._userRepository.GetByIdAsync(id);
    }
}
