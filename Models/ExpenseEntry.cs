
namespace ExpenseEntryAPI.Models;

public class ExpenseEntry
{
        public int id { get; set; }
        public string?  item { get; set; } 
        public double amount { get; set; } 
        public string? category { get; set; }
        public string? location { get; set; }
        public DateTime spendOn { get; set; }
        public DateTime createdOn { get; set; }
}