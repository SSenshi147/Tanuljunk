using Dogs.Data;
using Dogs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dogs.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DogController : ControllerBase
{
    private readonly DogContext dogContext;

    public DogController(DogContext dogContext)
    {
        this.dogContext = dogContext;
    }

    [HttpGet]
    public async Task<List<Dog>> GetDogs()
    {
        return await this.dogContext.Dogs.ToListAsync(this.HttpContext.RequestAborted);
    }

    [HttpGet("knownCats")]
    public async Task<List<KnownCat>> GetKnownCats()
    {
        return await this.dogContext.KnownCats.ToListAsync(this.HttpContext.RequestAborted);
    }
}
