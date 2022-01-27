using Microsoft.AspNetCore.Mvc;
using ExpenseEntryAPI.Models;
using System.Linq;
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

    [HttpGet(Name = "ExpenseEntries")]
    public IEnumerable<ExpenseEntry> Get()
    {
        return EntryList;
    }

    [HttpGet]
    [Route("{id:int}", Name = "GetById")]
    public ExpenseEntry Get(int id)
    {
        return EntryList.FirstOrDefault(p => p.id == id);
    }

    [HttpPost]
    public IActionResult Post(ExpenseEntry expenseEntry)
    {
        if (expenseEntry == null)
        {
            return BadRequest();
        }

        EntryList.Add(expenseEntry);
        return CreatedAtAction(nameof(Get), new { id = expenseEntry.id });
    }

    [HttpPut]
    public IActionResult Put(ExpenseEntry expenseEntry)
    {
        var entry = EntryList.First(p => p.id == expenseEntry.id);
        if (entry != null)
        {
            EntryList[entry.id].item = expenseEntry.item;
            EntryList[entry.id].amount = expenseEntry.amount;
            EntryList[entry.id].category = expenseEntry.category;
            EntryList[entry.id].location = expenseEntry.location;
            EntryList[entry.id].spendOn = expenseEntry.spendOn;
            EntryList[entry.id].createdOn = expenseEntry.createdOn;
            return Ok();
        }
        return BadRequest();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var entry = EntryList.FirstOrDefault(p => p.id == id);
        EntryList.Remove(entry);
        return Ok("Resource deleted successfully");
    }
}