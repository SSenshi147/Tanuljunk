using Cats.Data;
using Cats.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cats.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CatController : ControllerBase
{
    private readonly CatContext catContext;

    public CatController(CatContext catContext)
    {
        this.catContext = catContext;
    }

    [HttpGet]
    public async Task<List<Cat>> GetCats()
    {
        return await this.catContext.Cats.ToListAsync(this.HttpContext.RequestAborted);
    }
}
