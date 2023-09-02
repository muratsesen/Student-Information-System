using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Data.Models;
using Api.Data.Models.ViewModels;

namespace Api.Controllers;

[ApiController]
[Route("student")]
[Authorize]
public class StudentController : ControllerBase
{


    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger)
    {
        _logger = logger;
    }

    [HttpPost("create")]
    [Authorize(Policy = "AdminRole")]
    public StudentCreateModel Post(StudentCreateModel model)
    {
        return model;
    }

}

