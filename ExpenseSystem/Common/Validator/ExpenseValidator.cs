using FluentValidation;
using ExpenseSystem.Models;

namespace ExpenseSystem.Common.Validator;

public class ExpenseValidator : AbstractValidator<Expense>
{
    public ExpenseValidator()
    {
        RuleFor(expense => expense.Amount).GreaterThanOrEqualTo(0).WithMessage("金額必須大於或等於 0。");

        RuleFor(expense => expense.Date).Must(date => date >= DateTime.Now.AddYears(-1)).WithMessage("日期不能晚於一年前。");

        RuleFor(expense => expense.Category).Must(category => new[] { "食", "衣", "住", "行" }.Contains(category)).WithMessage("類別只能為 食、衣、住、行。");
    }
}
