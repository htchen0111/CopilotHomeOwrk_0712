using FluentValidation;
using ExpenseSystem.Models;

namespace ExpenseSystem.Common.Validator;

public class ExpenseValidator : AbstractValidator<Expense>
{
    public ExpenseValidator()
    {
        RuleFor(expense => expense.Amount).GreaterThanOrEqualTo(0).WithMessage("���B�����j��ε��� 0�C");

        RuleFor(expense => expense.Date).Must(date => date >= DateTime.Now.AddYears(-1)).WithMessage("�������ߩ�@�~�e�C");

        RuleFor(expense => expense.Category).Must(category => new[] { "��", "��", "��", "��" }.Contains(category)).WithMessage("���O�u�ର ���B��B��B��C");
    }
}
