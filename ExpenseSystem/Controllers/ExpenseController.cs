using Microsoft.AspNetCore.Mvc;

namespace ExpenseSystem.Controllers
{
    [Route("Expense")]
    public class ExpenseController : Controller
    {
        // GET: Expense/Create
        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        // GET: Expense/Index
        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
