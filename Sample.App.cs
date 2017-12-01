using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class EmploymentPosition
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal BaseSalary { get; set; }
}

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<EmploymentPosition> EmploymentPositions { get; set; }
}

[Route("api/[controller]")]
public class EmploymentPositionsController : Controller
{
    readonly ApplicationDbContext _context;
    public EmploymentPositionsController(ApplicationDbContext context) =>
        _context = context;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var data = await _context.EmploymentPositions.ToListAsync();
        return Ok(data);
    }
}
