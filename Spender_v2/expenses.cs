namespace Spender_v2;
using System.ComponentModel.DataAnnotations;
public class expenses
{
    public class ExpenseModel
    {
        [Key]
        public Guid Id { get; init; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Description)
                   && Amount > 0
                   && !string.IsNullOrWhiteSpace(Category);
        }
        
    }
    public class MonthlySpendingResponseModel
        {
            public int Month { get; set; }
            public decimal TotalSpending { get; set; }
        }
    public class MonthlyExpenseSummary
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal AverageExpenses { get; set; }
    }
    public class TotalExpensesResponseModel
    {
        public decimal TotalExpenses { get; set; }
    }
    
}