using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Spender_v2.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class expensesController : ControllerBase
    {
        private static readonly List<expenses.ExpenseModel> _expenses = new List<expenses.ExpenseModel>()
        { 
            // Basic expense example.
            new expenses.ExpenseModel
            {
                Id = Guid.NewGuid(),
                Description = "Groceries",
                Amount = 500,
                Date = DateTime.UtcNow,
                Category = "Food"
            },
            
        };
        

        [HttpPost]
        public IActionResult Expense([FromBody] expenses.ExpenseModel requestModel)
        {
            if (!requestModel.IsValid())
            {
                return BadRequest("Invalid expense data.");
            }

            var expense = new expenses.ExpenseModel()
            {
                Id = requestModel.Id,
                Description = requestModel.Description,
                Amount = requestModel.Amount,
                Date = requestModel.Date,
                Category = requestModel.Category
            };

            _expenses.Add(expense);
            return CreatedAtAction(nameof(GetAllExpenses), expense);
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateExpense(Guid id, [FromBody] expenses.ExpenseModel requestModel)
        {
            //matches the given Id with the Id of expenses.
            var expense = _expenses.FirstOrDefault(e => e.Id == id);
            if (expense == null)
            {
                return NotFound();
            }

            if (!requestModel.IsValid())
            {
                return BadRequest("Invalid expense data.");
            }

            expense.Description = requestModel.Description;
            expense.Amount = requestModel.Amount;
            expense.Date = requestModel.Date;
            expense.Category = requestModel.Category;

            return Ok(expense);
        }



        [HttpGet]
        public List<expenses.ExpenseModel> GetAllExpenses()
        {
            return _expenses;
        }

        [HttpGet($"total-spent")]
        public IActionResult GetTotalExpenses()
        {
            //takes total spended money.
            decimal total = _expenses.Sum(expense => expense.Amount);
            var result = new expenses.TotalExpensesResponseModel { TotalExpenses = total };
            return Ok(result);
        }
        [HttpGet("monthly")]
        public IActionResult GetMonthlySpending([FromQuery] int month)
        {
            // Checks the input in between 1 and 12 because there are only 12 months.
            if (month < 1 || month > 12)
            {
                return BadRequest("Invalid month value. Month should be between 1 and 12.");
            }
            
            // match the month and gets the spending amount from that month.
            decimal totalSpending = _expenses
                .Where(expense => expense.Date.Month == month)
                .Sum(expense => expense.Amount);

            var result = new expenses.MonthlySpendingResponseModel
            {
                Month = month,
                TotalSpending = totalSpending
            };

            return Ok(result);
        }
        [HttpGet("category")]
        public IActionResult GetExpensesByCategory([FromQuery] string category)
        {
            //Match the given category
            var expensesByCategory = _expenses.Where(e => e.Category == category).ToList();
            return Ok(expensesByCategory);
        }
        
        [HttpPost("summary")]
        public IActionResult GetMonthlyExpenseSummary([FromBody] expenses.MonthlyExpenseSummary requestModel)
        {
            // Extract the year and month from the Model
            int year = requestModel.Year;
            int month = requestModel.Month;

            // Filter the expenses based on the year and month
            var monthlyExpenses = _expenses.Where(e => e.Date.Year == year && e.Date.Month == month);

            // Calculate the total expenses
            var expenseModels = monthlyExpenses.ToList();
            decimal totalExpenses = expenseModels.Sum(e => e.Amount);

            // Calculate the average expenses
            decimal averageExpenses = expenseModels.Any() ? totalExpenses / expenseModels.Count() : 0;

            // Create the response model with the summary data
            var responseModel = new expenses.MonthlyExpenseSummary
            {
                Year = year,
                Month = month,
                TotalExpenses = totalExpenses,
                AverageExpenses = averageExpenses
                // Add other summary properties as needed
            };

            return Ok(responseModel);
        }




    }
    
    
    
    
    
}
