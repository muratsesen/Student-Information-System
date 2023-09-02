using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("admin")]
[Authorize(Policy = "AdminRole")]
public class AdminController : ControllerBase
{


    private readonly ILogger<AdminController> _logger;

    public AdminController(ILogger<AdminController> logger)
    {
        _logger = logger;
    }

    [HttpGet("test")]
    public IEnumerable<int> Get()
    {
        return new int[] { 1, 2, 3 };
    }

}

