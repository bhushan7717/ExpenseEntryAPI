using Microsoft.AspNetCore.Mvc;
using ExpenseEntryAPI.Models;
namespace ExpenseEntryAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ExpenseEntryController : ControllerBase
{
    private static readonly List<ExpenseEntry> EntryList = new List<ExpenseEntry>() {
            new ExpenseEntry() { id = 1, item = "Pizza", amount = 20, category="Food", location="Pune", spendOn = DateTime.Now, createdOn = DateTime.Now },
            new ExpenseEntry() { id = 2, item = "Burger", amount = 10, category="Food", location="Pune", spendOn = DateTime.Now, createdOn = DateTime.Now  },
            new ExpenseEntry() { id = 3, item = "Fries", amount = 35, category="Food", location="Pune", spendOn = DateTime.Now, createdOn = DateTime.Now }
    };
    private readonly ILogger<WeatherForecastController> _logger;

    public ExpenseEntryController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "ExpenseEntry")]
    public IEnumerable<ExpenseEntry> Get()
    {
        return EntryList;
    }
}