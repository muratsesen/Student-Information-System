using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("user")]
[Authorize(Policy = "UserRole")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet("test")]
    public IEnumerable<int> Get()
    {
        return new int[] { 1, 2, 3 };
    }
}

