using ExpenseSystem.Data;

namespace ExpenseSystem.Models
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ExpenseDbContext _context;

        public DatabaseInitializer(ExpenseDbContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            if (_context.Expenses.Any())
            {
                return; // 如果資料庫已經有資料，則不進行初始化
            }

            var fakeData = new List<Expense>
                {
                    new Expense { Id = 1, Title = "Lunch", Amount = 50, Date = DateTime.Parse("2023-10-01"), Category = "食" },
                    new Expense { Id = 2, Title = "Shirt", Amount = 100, Date = DateTime.Parse("2023-10-02"), Category = "衣" },
                    new Expense { Id = 3, Title = "Rent", Amount = 500, Date = DateTime.Parse("2023-10-03"), Category = "住" },
                    new Expense { Id = 4, Title = "Bus Ticket", Amount = 20, Date = DateTime.Parse("2023-10-04"), Category = "行" }
                };

            _context.Expenses.AddRange(fakeData);
            _context.SaveChanges();
        }
    }
}
