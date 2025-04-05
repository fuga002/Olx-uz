using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Olx_uz.API.Data;

namespace Olx_uz.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    ApiDbContext _dbContext = new ApiDbContext();

    [HttpGet]
    [Authorize] 
    public IActionResult Get()
    {
        return Ok(_dbContext.Categories);
    }
}