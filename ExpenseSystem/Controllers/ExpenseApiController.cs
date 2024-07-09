using ExpenseSystem.Data;
using ExpenseSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseApiController : ControllerBase
    {
        private readonly ExpenseDbContext _dbContext;

        public ExpenseApiController(ExpenseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(Expense expense)
        {
            _dbContext.Expenses.Add(expense);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Route("read")]
        public IActionResult Read()
        {
            var expenses = _dbContext.Expenses.OrderBy(e => e.Id);
            return Ok(expenses);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var expense = _dbContext.Expenses.FirstOrDefault(x => x.Id == id);
            if (expense == null)
            {
                return NotFound();
            }

            _dbContext.Expenses.Remove(expense);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Update(int id, [FromBody] Expense updatedExpense)
        {
            var expense = _dbContext.Expenses.FirstOrDefault(x => x.Id == id);
            if (expense == null)
            {
                return NotFound();
            }

            expense.Title = updatedExpense.Title;
            expense.Amount = updatedExpense.Amount;
            expense.Date = updatedExpense.Date;
            expense.Category = updatedExpense.Category;

            _dbContext.SaveChanges();

            return Ok();
        }
    }
}